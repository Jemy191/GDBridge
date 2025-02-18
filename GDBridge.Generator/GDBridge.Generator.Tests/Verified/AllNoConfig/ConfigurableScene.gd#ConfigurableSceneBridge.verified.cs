//HintName: ConfigurableSceneBridge.cs
using GDBridge;
using Godot;

public partial class ConfigurableSceneBridge : GDScriptBridge
{
    public const string GDClassName = "ConfigurableScene";
    public ConfigurableSceneBridge(GodotObject gdObject) : base(gdObject) {}

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
        //
        // Summary:
        //     Cached name for the 'configure' signal.
        public static readonly StringName configure = "configure";
    }
    public event System.Action<Variant> configure
    {
        add
        {
            Connect(SignalName.configure, global::Godot.Callable.From(value));
        }
        remove
        {
            Disconnect(SignalName.configure, global::Godot.Callable.From(value));
        }
    }
}