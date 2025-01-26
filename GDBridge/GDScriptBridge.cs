using Godot;
using Godot.Collections;

namespace GDBridge;

public abstract class GDScriptBridge : GodotObject
{
    protected readonly GodotObject GdObject;

    protected GDScriptBridge(GodotObject gdObject) => GdObject = gdObject;

    public new void Notification(int what, bool reversed = false) => GdObject.Notification(what, reversed);

    public new ulong GetInstanceId() => GdObject.GetInstanceId();
    //
    // Summary:
    //     Emits the given signal by name. The signal must exist, so it should be a built-in
    //     signal of this class or one of its inherited classes, or a user-defined signal
    //     (see Godot.GodotObject.AddUserSignal(System.String,Godot.Collections.Array)).
    //     This method supports a variable number of arguments, so parameters can be passed
    //     as a comma separated list.
    //
    //     Returns Godot.Error.Unavailable if signal does not exist or the parameters are
    //     invalid.
    //
    //     EmitSignal(SignalName.Hit, "sword", 100);
    //     EmitSignal(SignalName.GameOver);
    //
    //     Note: In C#, signal must be in snake_case when referring to built-in Godot signals.
    //     Prefer using the names exposed in the SignalName class to avoid allocating a
    //     new Godot.StringName on each call.
    public new Error EmitSignal(StringName signal, params Variant[] args) => GdObject.EmitSignal(signal, args);

    //
    // Summary:
    //     Returns true if the given signal name exists in the object.
    //
    //     Note: In C#, signal must be in snake_case when referring to built-in Godot methods.
    //     Prefer using the names exposed in the SignalName class to avoid allocating a
    //     new Godot.StringName on each call.
    public new bool HasSignal(StringName signal) => GdObject.HasSignal(signal);

    //
    // Summary:
    //     Returns the list of existing signals as an Godot.Collections.Array of dictionaries.
    //
    //
    //     Note: Due of the implementation, each Godot.Collections.Dictionary is formatted
    //     very similarly to the returned values of Godot.GodotObject.GetMethodList.
    public new Array<Dictionary> GetSignalList() => GdObject.GetSignalList();

    //
    // Summary:
    //     Returns an Godot.Collections.Array of connections for the given signal name.
    //     Each connection is represented as a Godot.Collections.Dictionary that contains
    //     three entries:
    //
    //     - signal is a reference to the Godot.Signal;
    //
    //     - callable is a reference to the connected Godot.Callable;
    //
    //     - flags is a combination of Godot.GodotObject.ConnectFlags.
    public new Array<Dictionary> GetSignalConnectionList(StringName signal) => GdObject.GetSignalConnectionList(signal);

    //
    // Summary:
    //     Returns an Godot.Collections.Array of signal connections received by this object.
    //     Each connection is represented as a Godot.Collections.Dictionary that contains
    //     three entries:
    //
    //     - signal is a reference to the Godot.Signal;
    //
    //     - callable is a reference to the Godot.Callable;
    //
    //     - flags is a combination of Godot.GodotObject.ConnectFlags.
    public new Array<Dictionary> GetIncomingConnections() => GdObject.GetIncomingConnections();

    //
    // Summary:
    //     Connects a signal by name to a callable. Optional flags can be also added to
    //     configure the connection's behavior (see Godot.GodotObject.ConnectFlags constants).
    //
    //
    //     A signal can only be connected once to the same Godot.Callable. If the signal
    //     is already connected, this method returns Godot.Error.InvalidParameter and pushes
    //     an error message, unless the signal is connected with Godot.GodotObject.ConnectFlags.ReferenceCounted.
    //     To prevent this, use Godot.GodotObject.IsConnected(Godot.StringName,Godot.Callable)
    //     first to check for existing connections.
    //
    //     If the callable's object is freed, the connection will be lost.
    //
    //     Examples with recommended syntax:
    //
    //     Connecting signals is one of the most common operations in Godot and the API
    //     gives many options to do so, which are described further down. The code block
    //     below shows the recommended approach.
    //
    //     public override void _Ready()
    //     {
    //     var button = new Button();
    //     // C# supports passing signals as events, so we can use this idiomatic construct:
    //
    //     button.ButtonDown += OnButtonDown;
    //     // This assumes that a `Player` class exists, which defines a `Hit` signal.
    //     var player = new Player();
    //     // We can use lambdas when we need to bind additional parameters.
    //     player.Hit += () => OnPlayerHit("sword", 100);
    //     }
    //     private void OnButtonDown()
    //     {
    //     GD.Print("Button down!");
    //     }
    //     private void OnPlayerHit(string weaponType, int damage)
    //     {
    //     GD.Print($"Hit with weapon {weaponType} for {damage} damage.");
    //     }
    //
    //     Object.connect() or Signal.connect()?
    //
    //     As seen above, the recommended method to connect signals is not Godot.GodotObject.Connect(Godot.StringName,Godot.Callable,System.UInt32).
    //     The code block below shows the four options for connecting signals, using either
    //     this legacy method or the recommended Signal.connect, and using either an implicit
    //     Godot.Callable or a manually defined one.
    //
    //     public override void _Ready()
    //     {
    //     var button = new Button();
    //     // Option 1: In C#, we can use signals as events and connect with this idiomatic
    //     syntax:
    //     button.ButtonDown += OnButtonDown;
    //     // Option 2: GodotObject.Connect() with a constructed Callable from a method
    //     group.
    //     button.Connect(Button.SignalName.ButtonDown, Callable.From(OnButtonDown));
    //     // Option 3: GodotObject.Connect() with a constructed Callable using a target
    //     object and method name.
    //     button.Connect(Button.SignalName.ButtonDown, new Callable(this, MethodName.OnButtonDown));
    //
    //     }
    //     private void OnButtonDown()
    //     {
    //     GD.Print("Button down!");
    //     }
    //
    //     While all options have the same outcome (button's Godot.BaseButton.ButtonDown
    //     signal will be connected to _on_button_down), option 3 offers the best validation:
    //     it will print a compile-time error if either the button_down Godot.Signal or
    //     the _on_button_down Godot.Callable are not defined. On the other hand, option
    //     2 only relies on string names and will only be able to validate either names
    //     at runtime: it will print a runtime error if "button_down" doesn't correspond
    //     to a signal, or if "_on_button_down" is not a registered method in the object
    //     self. The main reason for using options 1, 2, or 4 would be if you actually need
    //     to use strings (e.g. to connect signals programmatically based on strings read
    //     from a configuration file). Otherwise, option 3 is the recommended (and fastest)
    //     method.
    //
    //     Binding and passing parameters:
    //
    //     The syntax to bind parameters is through Callable.bind, which returns a copy
    //     of the Godot.Callable with its parameters bound.
    //
    //     When calling Godot.GodotObject.EmitSignal(Godot.StringName,Godot.Variant[]) or
    //     Signal.emit, the signal parameters can be also passed. The examples below show
    //     the relationship between these signal parameters and bound parameters.
    //
    //     public override void _Ready()
    //     {
    //     // This assumes that a `Player` class exists, which defines a `Hit` signal.
    //     var player = new Player();
    //     // Using lambda expressions that create a closure that captures the additional
    //     parameters.
    //     // The lambda only receives the parameters defined by the signal's delegate.
    //
    //     player.Hit += (hitBy, level) => OnPlayerHit(hitBy, level, "sword", 100);
    //     // Parameters added when emitting the signal are passed first.
    //     player.EmitSignal(SignalName.Hit, "Dark lord", 5);
    //     }
    //     // We pass two arguments when emitting (`hit_by`, `level`),
    //     // and bind two more arguments when connecting (`weapon_type`, `damage`).
    //     private void OnPlayerHit(string hitBy, int level, string weaponType, int damage)
    //
    //     {
    //     GD.Print($"Hit by {hitBy} (level {level}) with weapon {weaponType} for {damage}
    //     damage.");
    //     }
    public new Error Connect(StringName signal, Callable callable, uint flags = 0u) => GdObject.Connect(signal, callable, flags);

    //
    // Summary:
    //     Disconnects a signal by name from a given callable. If the connection does not
    //     exist, generates an error. Use Godot.GodotObject.IsConnected(Godot.StringName,Godot.Callable)
    //     to make sure that the connection exists.
    public new void Disconnect(StringName signal, Callable callable) => GdObject.Disconnect(signal, callable);

    //
    // Summary:
    //     Returns true if a connection exists between the given signal name and callable.
    //
    //
    //     Note: In C#, signal must be in snake_case when referring to built-in Godot methods.
    //     Prefer using the names exposed in the SignalName class to avoid allocating a
    //     new Godot.StringName on each call.
    public new bool IsConnected(StringName signal, Callable callable) => GdObject.IsConnected(signal, callable);

    //
    // Summary:
    //     If set to true, the object becomes unable to emit signals. As such, Godot.GodotObject.EmitSignal(Godot.StringName,Godot.Variant[])
    //     and signal connections will not work, until it is set to false.
    public new void SetBlockSignals(bool enable) => GdObject.SetBlockSignals(enable);

    //
    // Summary:
    //     Returns true if the object is blocking its signals from being emitted. See Godot.GodotObject.SetBlockSignals(System.Boolean).
    public new bool IsBlockingSignals() => GdObject.IsBlockingSignals();
}