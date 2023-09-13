extends ConfigurableScene

class_name Arena

@onready var _game_startup : GameStartup = get_node(game_startup)
@export_node_path("GameStartup") var game_startup: NodePath

func _ready() -> void:
	configure.connect(on_configure)

func on_configure(deck_id_in):
    var deck_id := 0
	if deck_id_in is int:
		deck_id = deck_id_in
	_game_startup.StartGame(deck_id)
