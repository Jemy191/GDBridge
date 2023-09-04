extends ConfigurableScene

var createNewDeck: bool = false

func _ready() -> void:
	configure.connect(on_configure)

func on_configure(args):
	if args is bool:
		createNewDeck = args


func _on_exit_button_pressed() -> void:
	SceneLoader.goto_menu()
