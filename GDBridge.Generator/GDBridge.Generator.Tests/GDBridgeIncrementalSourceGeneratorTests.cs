using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Godot;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using VerifyTests;
using Xunit;
using static VerifyXunit.Verifier;

namespace GDBridge.Generator.Tests;

public class GDBridgeIncrementalSourceGeneratorTests
{
    static GDBridgeIncrementalSourceGeneratorTests() => VerifySourceGenerators.Initialize();

    const string ConfigTestPath = "./ConfigTest.gd";
    const string ConfigTestScript =
        """
        class_name ConfigTest

        var snake_case_variable;
        var property_var;

        func snake_case_function()
            pass
        
        func get_property_var()
            pass
        """;

    public static TheoryData<string> GetFiles()
    {
        var data = new TheoryData<string>();

        var scriptPaths = Directory.GetFiles("./TestScripts")
            .Where(f => f.EndsWith(".gd"))
            .ToList();

        foreach (var path in scriptPaths)
        {
            data.Add(path);
        }

        return data;
    }

    [Theory]
    [MemberData(nameof(GetFiles))]
    public Task AllNoConfig(string path)
    {
        var driver = GeneratorDriver(path, File.ReadAllText(path));

        var setting = new VerifySettings();
        setting.UseFileName(Path.GetFileName(path));
        setting.UseDirectory("Verified/AllNoConfig");

        return Verify(driver, setting);
    }

    [Fact]
    public Task UsePascalCaseConfig()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, true, true);

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UsePascalCaseConfig));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }
    
    [Fact]
    public Task DontUsePascalCaseConfig()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, true, false);

        var setting = new VerifySettings();
        setting.UseFileName(nameof(DontUsePascalCaseConfig));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }
    
    [Fact]
    public Task UseGenerateOnlyForMatchingBridgeClassConfigWithMatchingClass()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, true, false, true, true);

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UseGenerateOnlyForMatchingBridgeClassConfigWithMatchingClass));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    [Fact]
    public Task UseGenerateOnlyForMatchingBridgeClassConfigWithNoMatchingClass()
    {
        var driver = GeneratorDriver(ConfigTestPath, ConfigTestScript, true, false, true, false);

        var setting = new VerifySettings();
        setting.UseFileName(nameof(UseGenerateOnlyForMatchingBridgeClassConfigWithNoMatchingClass));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    static GeneratorDriver GeneratorDriver(string path, string script, bool useConfiguration = false, bool usePascalCase = false, bool onlyGenMatchingClass = false, bool addMatchingConfigCSharpClass = false)
    {
        var testCodePaths = Directory.GetFiles("./TestProjectClasses")
            .Where(f => f.EndsWith(".cs"))
            .ToList();
        var compilation = CSharpCompilation.Create("Test")
            .AddReferences(MetadataReference.CreateFromFile(typeof(Node).Assembly.Location));// Will throw an exception if a breakpoint is hit when debugging

        if(addMatchingConfigCSharpClass)
            testCodePaths.Add("./ExtraTestFiles/TestConfigMatchingPartialClass.cs");
        
        foreach (var testCodePath in testCodePaths)
        {
            compilation = compilation.AddSyntaxTrees(CSharpSyntaxTree.ParseText(File.ReadAllText(testCodePath)));
        }
        
        var generator = new GDBridgeIncrementalSourceGenerator();

        var additionalTexts = new List<AdditionalText>
        {
            new SimpleAdditionalText(path, script)
        };
        
        if(useConfiguration)
            additionalTexts.Add(CreateConfigurationFile(usePascalCase, onlyGenMatchingClass));
        
        var driver = CSharpGeneratorDriver.Create(generator)
            .AddAdditionalTexts(additionalTexts.ToImmutableArray());

        return driver.RunGenerators(compilation);
    }

    static AdditionalText CreateConfigurationFile(bool usePascalCase, bool onlyGenMatchingClass)
    {
        var json = JsonSerializer.Serialize(new
        {
            UsePascalCase = usePascalCase,
            GenerateOnlyForMatchingBridgeClass = onlyGenMatchingClass
        });
        return new SimpleAdditionalText("./GDBridgeConfiguration.json", json);
    }
}