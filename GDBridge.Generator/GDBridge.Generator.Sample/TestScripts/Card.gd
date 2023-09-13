class_name Card extends PathFollow2D

@export var name_label: Label
@export var cost_label: Label

func setup(name: String, cost: String):
	name_label.text = name
	cost_label.text = cost
