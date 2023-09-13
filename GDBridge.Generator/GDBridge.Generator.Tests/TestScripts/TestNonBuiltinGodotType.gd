extends ConfigurableScene

class_name TestNonBuiltinGodotType

var node : Node2D

func on_configure(node: Node2D) -> void:
    var deck_id := 0
	if deck_id_in is int:
		deck_id = deck_id_in
	_game_startup.StartGame(deck_id)
