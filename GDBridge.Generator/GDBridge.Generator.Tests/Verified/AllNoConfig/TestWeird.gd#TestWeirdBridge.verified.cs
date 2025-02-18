//HintName: TestWeirdBridge.cs
using GDBridge;
using Godot;

public partial class TestWeirdBridge : GDScriptBridge
{
    public const string GDClassName = "TestWeird";
    public Godot.Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<Godot.Variant>();
        set => GdObject.Set("chooseDeck", Godot.Variant.From(value));
    }

    public TestWeirdBridge(GodotObject gdObject) : base(gdObject) {}

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}