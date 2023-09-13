class_name LocalPlayer extends Control

var _controller: LocalPlayerView

func _setup(controller: LocalPlayerView) -> void:
	_controller = controller

func ready_to_play() -> void:
	_controller.ReadyToPlay()
	$ReadyToPlay.visible = false
