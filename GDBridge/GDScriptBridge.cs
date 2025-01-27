using Godot;
using Godot.Collections;

namespace GDBridge;

public abstract class GDScriptBridge : GodotObject
{
    protected readonly GodotObject GdObject;

    protected GDScriptBridge(GodotObject gdObject) => GdObject = gdObject;

    /// <inheritdoc cref="GodotObject.Notification"/>
    public new void Notification(int what, bool reversed = false) => GdObject.Notification(what, reversed);

    /// <inheritdoc cref="GodotObject.GetInstanceId"/>
    public new ulong GetInstanceId() => GdObject.GetInstanceId();
    

    /// <inheritdoc cref="GodotObject.EmitSignal"/>
    public new Error EmitSignal(StringName signal, params Variant[] args) => GdObject.EmitSignal(signal, args);

    /// <inheritdoc cref="GodotObject.HasSignal"/>
    public new bool HasSignal(StringName signal) => GdObject.HasSignal(signal);

    /// <inheritdoc cref="GodotObject.GetSignalList"/>
    public new Array<Dictionary> GetSignalList() => GdObject.GetSignalList();

    /// <inheritdoc cref="GodotObject.GetSignalConnectionList"/>
    public new Array<Dictionary> GetSignalConnectionList(StringName signal) => GdObject.GetSignalConnectionList(signal);

    /// <inheritdoc cref="GodotObject.GetIncomingConnections"/>
    public new Array<Dictionary> GetIncomingConnections() => GdObject.GetIncomingConnections();


    /// <inheritdoc cref="GodotObject.Connect"/>
    public new Error Connect(StringName signal, Callable callable, uint flags = 0u) => GdObject.Connect(signal, callable, flags);

    /// <inheritdoc cref="GodotObject.Disconnect"/>
    public new void Disconnect(StringName signal, Callable callable) => GdObject.Disconnect(signal, callable);

    /// <inheritdoc cref="GodotObject.IsConnected"/>
    public new bool IsConnected(StringName signal, Callable callable) => GdObject.IsConnected(signal, callable);


    /// <inheritdoc cref="GodotObject.SetBlockSignals"/>
    public new void SetBlockSignals(bool enable) => GdObject.SetBlockSignals(enable);

    /// <inheritdoc cref="GodotObject.IsBlockingSignals"/>
    public new bool IsBlockingSignals() => GdObject.IsBlockingSignals();
}