//HintName: CardPathBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class CardPathBridge : GDScriptBridge
{
    public const string ClassName = "CardPathBridge";
    public long width
    {
        get => GdObject.Get("width").As<long>();
        set => GdObject.Set("width", value);
    }

    public long height
    {
        get => GdObject.Get("height").As<long>();
        set => GdObject.Set("height", value);
    }

    public double curve_ratio
    {
        get => GdObject.Get("curve_ratio").As<double>();
        set => GdObject.Set("curve_ratio", value);
    }

    public double separation
    {
        get => GdObject.Get("separation").As<double>();
        set => GdObject.Set("separation", value);
    }

    public double padding
    {
        get => GdObject.Get("padding").As<double>();
        set => GdObject.Set("padding", value);
    }

    public CardPathBridge(GodotObject gdObject) : base(gdObject) {}
}