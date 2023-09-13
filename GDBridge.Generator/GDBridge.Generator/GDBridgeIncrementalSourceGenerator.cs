using System.Collections.Immutable;
using GDParser;
using Microsoft.CodeAnalysis;
using SourceGeneratorUtils;

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

        context.RegisterSourceOutput(scriptSources, Generate);
    }

    static void Generate(SourceProductionContext context, ImmutableArray<string> scripts)
    {
        foreach (var script in scripts)
        {
            var gdClass = ClassParser.Parse(script);
            if (gdClass?.ClassName is null)
                continue;

            var source = GenerateClass(gdClass);

            context.AddSource(gdClass.ClassName, source);
        }
    }
    static string GenerateClass(GdClass gdClass)
    {
        var source = new SourceWriter();
        source.WriteLine(
                $$"""
                  using Godot;
                  using GdBridge;

                  namespace GDScript.Bridge;

                  [GlobalClass]
                  public partial class {{gdClass.ClassName}} : GdScriptBridge
                  """)
            .OpenBlock()
            .Variables(gdClass.Variables)
            .WriteLine($"public {gdClass.ClassName}(GodotObject gdObject) : base(gdObject) {{}}")
            .Functions(gdClass.Functions)
            .CloseBlock();

        return source.ToString();
    }

}