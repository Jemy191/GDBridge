using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using VerifyTests;
using Xunit;
using VerifyXunit;
using static VerifyXunit.Verifier;

namespace GDBridge.Generator.Tests;

[UsesVerify]
public class GDBridgeIncrementalSourceGeneratorTests
{
    static GDBridgeIncrementalSourceGeneratorTests() => VerifySourceGenerators.Initialize();

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
    public Task GenerateTest(string path)
    {
        var driver = GeneratorDriver(path, File.ReadAllText(path));

        var setting = new VerifySettings();
        setting.UseFileName(Path.GetFileName(path));
        setting.UseDirectory("Verified");

        return Verify(driver, setting);
    }

    static GeneratorDriver GeneratorDriver(string path, string script)
    {
        var compilation = CSharpCompilation.Create("Test");
        var generator = new GDBridgeIncrementalSourceGenerator();

        var driver = CSharpGeneratorDriver.Create(generator)
            .AddAdditionalTexts(new[] { (AdditionalText)new ScriptAdditionalText(path, script) }.ToImmutableArray());

        return driver.RunGenerators(compilation);
    }
}