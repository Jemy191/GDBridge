﻿//HintName: ConfigurableScene.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class ConfigurableScene : GdScriptBridge
{
    public ConfigurableScene(GodotObject gdObject) : base(gdObject) {}
}