[![Test](https://github.com/TheJemy191/GDBridge/actions/workflows/Test.yml/badge.svg)](https://github.com/TheJemy191/GDBridge/actions/workflows/Test.yml)
# GDBridge

Simple package to simplify C# -> GDScript interoperability.
It comes in two part the bridge code and the source generator.
The generator will parse all the GDScript in the project and generate a C# GDBridge class for each of them.
It aims to reduce or remove the need to use string and untyped way of communicating with GDScript from C#.

### How to use(See [Sample](https://github.com/TheJemy191/GDBridge/blob/main/GDBridge.Generator/GDBridge.Generator.Sample/Test.cs))

```csharp
using GdBridge;

var myGDScript = new GdScriptBridgeFactory(this).ResolveNode<ArenaBridge>(arena);

myGDScript.on_configure(42);
```

The bridge class is partial, so you can extend it if needed.  
The bridge class is in the global namespace.  
You can extend it like this:
```csharp
partial class ArenaBridge
{
    public void DoSomethingElse(int deckId) => on_configure(deckId);
}
```

The generator can be gotten from [here](https://www.nuget.org/packages/GDBridge.Generator)

### Feel free to ask for feature support, doing a feature Pull Request or if you have question.
