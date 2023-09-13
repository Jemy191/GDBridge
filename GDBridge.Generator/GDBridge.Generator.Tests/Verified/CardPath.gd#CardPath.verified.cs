//HintName: CardPath.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class CardPath : GdScriptBridge
{
    public const string ClassName = "CardPath";
    long width
    {
        get => GdObject.Get("width").As<long>();
        set => GdObject.Set("width", value);
    }

    long height
    {
        get => GdObject.Get("height").As<long>();
        set => GdObject.Set("height", value);
    }

    double curve_ratio
    {
        get => GdObject.Get("curve_ratio").As<double>();
        set => GdObject.Set("curve_ratio", value);
    }

    double separation
    {
        get => GdObject.Get("separation").As<double>();
        set => GdObject.Set("separation", value);
    }

    double padding
    {
        get => GdObject.Get("padding").As<double>();
        set => GdObject.Set("padding", value);
    }

    public CardPath(GodotObject gdObject) : base(gdObject) {}
}