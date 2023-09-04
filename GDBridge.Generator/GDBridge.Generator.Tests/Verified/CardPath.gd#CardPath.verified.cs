//HintName: CardPath.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class CardPath : GdScriptBridge
{
    int width
    {
        get => GdObject.Get("width");
        set => GdObject.Set("width", value);
    }

    int height
    {
        get => GdObject.Get("height");
        set => GdObject.Set("height", value);
    }

    float curve_ratio
    {
        get => GdObject.Get("curve_ratio");
        set => GdObject.Set("curve_ratio", value);
    }

    float separation
    {
        get => GdObject.Get("separation");
        set => GdObject.Set("separation", value);
    }

    float padding
    {
        get => GdObject.Get("padding");
        set => GdObject.Set("padding", value);
    }

    public CardPath(GodotObject gdObject) : base(gdObject) {}
}