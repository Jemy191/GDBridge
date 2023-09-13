@tool @static_unload
class_name CardPath extends Path2D

@export var width: int:
	set(new_width):
		width = new_width
		_update_curve()
		
@export var height: int:
	set(new_height):
		height = new_height
		_update_curve()
		
@export_range(-1, 1) var curve_ratio: float = 0:
	set(new_curve_ratio):
		curve_ratio = new_curve_ratio
		_update_curve()
		
@export_range(0, 0.3) var separation: float = 0.1:
	set(new_separation):
		separation = new_separation
		_update_card_position()
		
@export_range(0, 0.3) var padding: float = 0.1:
	set(new_padding):
		padding = new_padding
		_update_card_position()

func _init() -> void:
	curve = Curve2D.new()
	_update_curve()
	
func _ready() -> void:
	child_entered_tree.connect(_card_added)

func _update_curve() -> void:
	curve.clear_points()
	curve.add_point(Vector2(-width/2.0, 0), Vector2.ZERO, Vector2(width/2.0 * curve_ratio, height))
	curve.add_point(Vector2(width/2.0, 0), Vector2(-(width/2.0 * curve_ratio), height), Vector2.ZERO)
	curve.changed.emit()
	_update_card_position()

func _card_added(_node):
	_update_card_position()
func _update_card_position() -> void:
	var card_count = get_child_count()
	
	for child in get_children():
		if not child is PathFollow2D:
			continue
		var card = child as PathFollow2D
		var index = card.get_index()
		
		card.progress_ratio = _compute_card_position(index, card_count)
		
func _compute_card_position(index: float, count: float) -> float:
	var distance = separation
	var path_length = 1.0 - 2.0 * padding
	
	if((count-1.0) * distance > path_length):
		distance -= ((count-1.0) * distance - path_length) / count
		
	var offset = (path_length - (distance * (count - 1.0))) / 2.0
	return padding + offset + (distance * index)
