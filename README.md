[![Test](https://github.com/TheJemy191/GDBridge/actions/workflows/Test.yml/badge.svg)](https://github.com/TheJemy191/GDBridge/actions/workflows/Test.yml)
# GDBridge
## ⚠Not feature complete
Some thing can change but not that much.

Simple package to simplify C# -> GDScript interoperability.  
It comes in two part the bridge code and the source generator.  
The generator will parse all the GDScript in the project and generate a C# GDBridge class for each of them.  
It aims to reduce or remove the need to use string and untyped way of communicating with GDScript from C#.  

#### Get it here -> https://www.nuget.org/packages/GDBridge and here -> https://www.nuget.org/packages/GDBridge.Generator

## Feature
- [X] Call GDScript from C#.
- [X] Use your C# class in the generated code(Even the bridge themselve).
- [X] Respect the _private method and field.
- [X] Configurable.
- [X] GodotObject support.
- [ ] Signal support.
And more to come.

### How to use(See [Sample](https://github.com/TheJemy191/GDBridge/blob/main/GDBridge.Generator/GDBridge.Generator.Sample/Sample.cs))

Make sure to instal both GDBridge and GDBridge.Generator.  
Only script with class_name will be bridged.  
Variable and function starting with _ are not expose in the bridge by default.

Add this to your .csproj:
```xml
  <ItemGroup>
    <AdditionalFiles Include="**/*.gd"/>
    <!-- Add this if you want to exclude GDScript in addons -->
    <!--<AdditionalFiles Remove="addons\**"/>-->
  </ItemGroup>
```

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

### How to configure(Optional)
Create the `GDBridgeConfiguration.json` in the root directory and add this to it:
```json
{
    "UsePascalCase": true
}
```
The schema is here: [Configuration.cs](GDBridge.Generator/GDBridge.Generator/Configuration.cs)

#### Feel free to ask for feature or question.
[What do you want?](https://github.com/TheJemy191/GDBridge/discussions/1)
#### Pull Request are welcome.
