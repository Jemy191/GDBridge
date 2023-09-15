using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GDBridge.Generator.Tests;

public class SimpleAdditionalText : AdditionalText
{
    readonly string text;

    public override string Path { get; }

    public SimpleAdditionalText(string path, string text)
    {
        Path = path;
        this.text = text;
    }

    public override SourceText GetText(CancellationToken cancellationToken = new CancellationToken()) => SourceText.From(text);
}