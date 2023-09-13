class_name SceneLoader extends Node

@export var menuScene: PackedScene
@export var arenaScene: PackedScene
@export var deckbuilderScene: PackedScene

var current_scene: Node = null

func _ready():
	var root = get_tree().root
	current_scene = root.get_child(root.get_child_count() - 1)

func goto_menu():
	call_deferred("_deferred_goto_scene", menuScene, null)
	
func goto_arena(player_deck_id: int):
	call_deferred("_deferred_goto_scene", arenaScene, player_deck_id)
	
func goto_deckbuilder(createNewDeck: bool):
	call_deferred("_deferred_goto_scene", deckbuilderScene, null)

func _deferred_goto_scene(scene: PackedScene, args):
	
	current_scene = scene.instantiate()
	get_tree().unload_current_scene()
	
	call_deferred("_configure_scene", args)

	get_tree().root.add_child(current_scene)
	get_tree().current_scene = current_scene

func _configure_scene(args):
	var configurableScene : ConfigurableScene = current_scene as ConfigurableScene
	if configurableScene:
		configurableScene.configure.emit(args)
