using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GDParser;
using Microsoft.CodeAnalysis;
using SourceGeneratorUtils;
using System.Text.Json;

namespace GDBridge.Generator;

[Generator]
public class GDBridgeIncrementalSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var scriptSources = context.AdditionalTextsProvider
            .Where(t => t.Path.EndsWith(".gd"))
            .Select((t, ct) => t.GetText(ct)?.ToString()!)
            .Where(t => t is not null)
            .Collect();

        var configuration = context.AdditionalTextsProvider
            .Where(t => t.Path.EndsWith("GDBridgeConfiguration.json"))
            .Select((t, ct) => t.GetText(ct)?.ToString()!)
            .Where(t => t is not null)
            .Collect();

        IncrementalValueProvider<((ImmutableArray<string> scripts, Compilation compilation) scriptAndCompilation, ImmutableArray<string> configuration)> providers = scriptSources
            .Combine(context.CompilationProvider)
            .Combine(configuration);

        context.RegisterSourceOutput(providers, (c, p) => Generate(c, p.scriptAndCompilation.compilation, p.scriptAndCompilation.scripts, p.configuration));
    }

    static void Generate(SourceProductionContext context, Compilation compilation, ImmutableArray<string> scripts, ImmutableArray<string> configurations)
    {
        var configuration = ReadConfiguration(configurations.FirstOrDefault());

        var availableTypes = GetAvailableTypes(compilation);

        foreach (var script in scripts)
        {
            var gdClass = ClassParser.Parse(script);
            if (gdClass?.ClassName is null)
                continue;

            var className = $"{gdClass.ClassName}Bridge";
            var source = GenerateClass(gdClass, className, availableTypes, configuration);

            context.AddSource(className, source);
        }
    }
    static List<AvailableType> GetAvailableTypes(Compilation compilation)
    {
        var godotAssembly = compilation.SourceModule.ReferencedAssemblySymbols
            .FirstOrDefault(e => e.Name == "GodotSharp");

        var availableGodotTypes = new List<AvailableType>();

        if (godotAssembly is not null)
            availableGodotTypes = godotAssembly.GlobalNamespace
                .GetNamespaceMembers().First(n => n.Name == "Godot")
                .GetMembers()
                .Where(m => m.IsType)
                .Select(m => new AvailableType(m.Name, "Godot"))
                .ToList();

        var availableTypes = compilation.Assembly.TypeNames
            .Select(tn => new AvailableType(tn, ResolveNamespace(compilation.GetSymbolsWithName(tn, SymbolFilter.Type).Single().ContainingNamespace)))
            .ToList()
            .Concat(availableGodotTypes)
            .ToList();

        return availableTypes;
    }
    static Configuration ReadConfiguration(string? configurationFile)
    {
        Configuration? configuration = null;

        if (configurationFile is not null)
        {
            try
            {
                configuration = JsonSerializer.Deserialize<Configuration>(configurationFile);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        configuration ??= new Configuration();
        return configuration;
    }

    static string ResolveNamespace(INamespaceSymbol? symbol, string childNamespace = "")
    {
        while (symbol is { IsGlobalNamespace: false })
        {
            if (childNamespace == "")
                childNamespace = symbol.Name;
            else
                childNamespace = $"{symbol.Name}.{childNamespace}";

            symbol = symbol.ContainingNamespace;
        }
        return childNamespace;
    }

    static string GenerateClass(GdClass gdClass, string className, ICollection<AvailableType> availableTypes, Configuration configuration)
    {
        var source = new SourceWriter();
        var bridgeWriter = new BridgeWriter(availableTypes, source, configuration);

        source.WriteLine(
                $"""
                 using GDBridge;
                 using Godot;

                 public partial class {className} : GDScriptBridge
                 """)
            .OpenBlock()
            .WriteLine($"""public const string GDClassName = "{gdClass.ClassName}";""");
        bridgeWriter.Variables(gdClass.Variables)
            .WriteLine($"public {className}(GodotObject gdObject) : base(gdObject) {{}}");
        bridgeWriter.Functions(gdClass.Functions, gdClass.Variables)
            .CloseBlock();

        return source.ToString();
    }
}