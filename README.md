# GDBridge
Simple package to simplify C# -> GDScript interoperability.
It comes in two part the bridge code and the source generator.
The generator will parse all the GDScript in the project and generate a C# GDBridge class for each of them.
It aims to reduce or remove the need to use string and untyped way of communicating with GDScript from C#.

### How to use(See [Sample](https://github.com/TheJemy191/GDBridge/blob/main/GDBridge.Generator/GDBridge.Generator.Sample/Test.cs))
```csharp
using GdBridge;
using GDScript.Bridge;

var myGDScript = new GdScriptBridgeFactory(this).ResolveNode<Arena>(arena);

myGDScript.OnConfigure(42);
```

### Feel free to ask for feature support, doing a feature Pull Request or if you have question.