using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Higher_or_lower
{
    public class Game
    {
        public string[] ACCEPTED_INPUT = {
            "H",
            "HIGHER",
            "L",
            "LOWER",
            "S",
            "SAME"
        };

        Player Player1 { get; set; }
        Player Player2 { get; set; }
        Player? ActivePlayer {  get; set; }
        Deck GameDeck { get; set; }

        public Game(Player player1, Player player2, Deck gameDeck)
        {
            Player1 = player1;
            Player2 = player2;
            GameDeck = gameDeck;
        } 

        public void StartGameLoop()
        {
            Console.WriteLine("Welcome to the game Higher Or Lower!\n");
            Console.WriteLine("Let's begin, shuffling the deck...\n");

            GameDeck.Shuffle();

            Console.WriteLine("Randomly selecting a player to go first...\n");

            ActivePlayer = SelectPlayer();

            GameDeck.CardFlip();

            int currentCardValue = (int)GameDeck.FaceUp.GetCardValue();

            bool gameActive = true;

            while (gameActive)
            {
                var playerGuess = GetGuess();

                GameDeck.CardFlip();

                GuessResult guessResult = EvaluateGuess(playerGuess, currentCardValue);

                currentCardValue = (int)GameDeck.FaceUp.GetCardValue();

                if(guessResult != GuessResult.Wrong)
                {
                    Console.WriteLine($"CORRRRRRRRRRECT! {(int)guessResult} point{(guessResult == GuessResult.Same ? "s" : "")} to {ActivePlayer.GetName()}");
                    ActivePlayer.SetPoints(ActivePlayer.GetPoints() + (int)guessResult );
                } 
                else
                {
                    Console.WriteLine("you're fucking wrong aint you u shit. take a drink NOWWWWWWww");
                }

                if (GameDeck.GetCardCount() <= 0)
                {
                    gameActive = false;
                    break;
                }

                SwitchActivePlayer();
            }

            // Provide results and end the game
            EndGame();
        }

        // Randomly select a player to go first
        public Player SelectPlayer()
        {
            int rnd = new Random().Next(0, 1);
            if (rnd == 0)
            {
                return Player1;
            }
            return Player2;
        }
        
        public string GetGuess()
        {
            // If for some reason the ActivePlayer is null, we'll just return a higher guess.
            string ret = "H";

            if (ActivePlayer != null)
            {
                // Take in player who's go it is' guess.
                Console.WriteLine($"{ActivePlayer.GetName()}'s go. Please choose Higher (h), Lower (L), or Same (S):");
                var playerGuess = Console.ReadLine();

                // Check that the guess is a legitmate input
                ret = playerGuess.ToString().ToUpper();

                var validInput = false;

                while (!validInput)
                {
                    foreach (var item in ACCEPTED_INPUT)
                    {
                        if (ret == item)
                        {
                            validInput = true;
                            break;
                        }
                    }

                    if (!validInput)
                    {
                        Console.WriteLine("That isn't a valid input you fuck. Please enter 'Higher', 'Lower' or 'Same'");
                        playerGuess = Console.ReadLine();
                        ret = playerGuess.ToString().ToUpper();
                    }
                }
            }

            return ret;
        }

        // Return true if the player is correct, false if they're wrong
        public GuessResult EvaluateGuess(string guess, int previousCardValue)
        {
            // We want to evaluate whether or not the players guess of 'Higher' or 'Lower' or 'Same'
            // In the format of 'H', 'HIGHER' or 'L', 'LOWER', 'S' or 'SAME' is correct or not
            // If so, give the player a point
            // If not, player gets no points and takes a drink
            // Added functionality: If same the player should get 5 points as this is more rare and a riskier guess.

            var guessResult = new GuessResult();

            // Cast enum to an int for comparisons
            int cardValue = (int)GameDeck.FaceUp.GetCardValue();

            var correctAnswer = new List<string>();

            // Check the actual answer
            if (cardValue >  previousCardValue)
            {
                correctAnswer.AddRange("H", "HIGHER");
                guessResult = GuessResult.Higher;
            }
            else if (cardValue < previousCardValue)
            {
                correctAnswer.AddRange("L", "LOWER");
                guessResult = GuessResult.Lower;
            }
            else
            {
                correctAnswer.AddRange("S", "SAME");
                guessResult = GuessResult.Same;
            }

            // Check if actual answer matches player guess
            foreach (var item in correctAnswer)
            {
                if (item == guess)
                {
                    return guessResult;
                }
            }

            return GuessResult.Wrong;

        }

        public void EndGame()
        {
            Console.WriteLine("All cards in the deck have been flipped!\n");
            Console.WriteLine($"{Player1.GetName()} finished with {Player1.GetPoints()} Points.\n");
            Console.WriteLine($"{Player2.GetName()} finished with {Player2.GetPoints()} Points.\n");

            var winner = Player1.GetPoints() > Player2.GetPoints() ? Player1 : Player2;

            Console.WriteLine($"THEREFORE THE WINNER IS {winner.GetName()}! Congratulations you fuck.\n");

            Console.WriteLine("Game over.");
        }

        private void SwitchActivePlayer()
        {
            if (ActivePlayer != null)
            {
                Console.WriteLine("Switching Players...");
                ActivePlayer = ActivePlayer == Player1 ? Player2 : Player1;
            } 
            else
            {
                Console.WriteLine("No active player set");
            }
        }
    }
}
