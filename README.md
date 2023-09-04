# GDBridge
Simple package to simplify C# -> GDScript interoperability.
It come in two part the bridge code and the source generator.
The generator will parse all the GDScript in the project and generate a C# GDBridge class for each of them.
It aim to reduce or remove the need to use string and untyped way of communicating with GDScript from C#.
