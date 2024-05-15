class_name ScriptWithPropertyAndGetSetFunc

@export var limit_target = NodePath(""):
	set = set_limit_target,
	get = get_limit_target

func set_limit_target(value: NodePath) -> void:
	pass
	
func get_limit_target() -> NodePath:
	pass