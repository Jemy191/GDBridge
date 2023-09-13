class_name Hand extends Node2D

@export var card_scene: PackedScene
@export var card_container: Node

func _add_card(id: int):
	card_container.add_child(card_scene.instantiate())
