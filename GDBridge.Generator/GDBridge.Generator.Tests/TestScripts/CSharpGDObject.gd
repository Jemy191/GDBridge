extends ConfigurableScene

class_name CSharpGDObject

var test_object : TestGDObject

func on_configure(test_object: TestGDObject) -> void:
    var deck_id := 0
	if deck_id_in is int:
		deck_id = deck_id_in
	_game_startup.StartGame(deck_id)
