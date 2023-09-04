class_name DeckEntry
extends Button

var deckId: int
var chooseDeck: ChooseDeck

func setup(deckName: String, deckId: int, chooseDeck: ChooseDeck):
	text = deckName
	self.deckId = deckId
	self.chooseDeck = chooseDeck

func _on_pressed():
	chooseDeck.deck_choosen.emit(deckId)
