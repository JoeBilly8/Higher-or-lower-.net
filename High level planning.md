# Higher/Lower Card Game Engine

## Overview of the general high level functionality:
	1) 2 Players (for now to keep things simple)
	2) 1 deck of shuffled cards in the middle, face down
	3) First card is flipped
	4) Random player picked to go first
	5) Player who's go it is has to decide will the next card flipped be higher or lower than the one currently face down
	6) Next card is flipped
	7) If the player who guessed is correct, they get a point
	8) If they are wrong they don't get a point
	9) Switch goes to the other player
	10) Repeat steps 5-9 until all the cards have been flipped
	11) Compare the points tally of both players and declare the winner is the one with the most points (or a draw if points are tied)
	
	
## High level design:
Classes we'll need:
	* Player:
		- Points
		- IsGo boolean value (is it this players go or not)
	* Card:
		- Suit
		- Value (2 through to Ace)
	* Deck:
		- Array of 52 cards
		- Shuffle method
		- Card flip method
		- Face down value
		- Current face up card
	* Game:
		- 2 Player instances
		- 1 Deck instance
		

## Main game method function:
	* Construct a game instance which will contain 2 player objects and 1 deck object
	* Shuffle the deck
	* Call card flip method for the first card
	* Randomly select a player instance to go first
	* While the deck still has face down cards:
		- Ask the player who's go it is for a guess: 'Higher or lower?'
		- Take in player input
		- Call card flip method
		- Compare new card with old card to determine actual higher or lower value
		- Compare actual higher or lower value with players guess
		- If correct, award a point, otherwise don't
		- Set the 'go' to the other player