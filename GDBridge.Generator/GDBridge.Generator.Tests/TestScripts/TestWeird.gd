extends Control

@export var chooseDeck: ChooseDeck

func _ready
() -> void:
	var deckData := DataAccess.new().GetDeckDatas() as Array
	
	var decks : Array[DeckData]
	decks.assign(deckData)
	
	chooseDeck.setup(decks)

func\
_on_start_game_pressed
()\
->\
void\
:
	var deckId = await chooseDeck.choose_deck()
	SceneLoader.goto_arena(deckId)

func _on_edit_deck_pressed():
	SceneLoader.goto_deckbuilder(false)
