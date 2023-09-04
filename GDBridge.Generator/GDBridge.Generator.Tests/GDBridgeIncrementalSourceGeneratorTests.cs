using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace GDBridge.Generator.Tests;

public class GDBridgeIncrementalSourceGeneratorTests
{
    [Fact]
    public void GenerateReportMethod()
    {
        //// Create an instance of the source generator.
        //var generator = new GDBridgeIncrementalSourceGenerator();
//
        //// Source generators should be tested using 'GeneratorDriver'.
        //var driver = CSharpGeneratorDriver.Create(generator);
//
        //// We need to create a compilation with the required source code.
        //var compilation = CSharpCompilation.Create(nameof(SampleSourceGeneratorTests),
        //    new[] { CSharpSyntaxTree.ParseText(VectorClassText) },
        //    new[]
        //    {
        //        // To support 'System.Attribute' inheritance, add reference to 'System.Private.CoreLib'.
        //        MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
        //    });
//
        //// Run generators and retrieve all results.
        //var runResult = driver.RunGenerators(compilation).GetRunResult();
//
        //// All generated files can be found in 'RunResults.GeneratedTrees'.
        //var generatedFileSyntax = runResult.GeneratedTrees.Single(t => t.FilePath.EndsWith("Vector3.g.cs"));
//
        //// Complex generators should be tested using text comparison.
        //Assert.Equal(ExpectedGeneratedClassText, generatedFileSyntax.GetText().ToString(),
        //    ignoreLineEndingDifferences: true);
    }
}