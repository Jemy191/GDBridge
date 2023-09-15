﻿//HintName: ArenaBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class ArenaBridge : GDScriptBridge
{
    public const string GDClassName = "Arena";
    public NodePath game_startup
    {
        get => GdObject.Get("game_startup").As<NodePath>();
        set => GdObject.Set("game_startup", value);
    }

    public ArenaBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant on_configure(Variant deck_id_in) => GdObject.Call("on_configure", deck_id_in);
}