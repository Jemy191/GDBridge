//HintName: CardPathBridge.cs
using GDBridge;
using Godot;

public partial class CardPathBridge : GDScriptBridge
{
    public const string GDClassName = "CardPath";
    public long width
    {
        get => GdObject.Get("width").As<long>();
        set => GdObject.Set("width", Godot.Variant.From(value));
    }

    public long height
    {
        get => GdObject.Get("height").As<long>();
        set => GdObject.Set("height", Godot.Variant.From(value));
    }

    public double curve_ratio
    {
        get => GdObject.Get("curve_ratio").As<double>();
        set => GdObject.Set("curve_ratio", Godot.Variant.From(value));
    }

    public double separation
    {
        get => GdObject.Get("separation").As<double>();
        set => GdObject.Set("separation", Godot.Variant.From(value));
    }

    public double padding
    {
        get => GdObject.Get("padding").As<double>();
        set => GdObject.Set("padding", Godot.Variant.From(value));
    }

    public CardPathBridge(GodotObject gdObject) : base(gdObject) {}
}