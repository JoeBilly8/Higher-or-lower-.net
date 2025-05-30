using System.Collections;

namespace Higher_or_lower
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create the players, deck and then game instance
            Player Player1 = new Player("Player1", 0, false);
            Player Player2 = new Player("Player2", 0, false);
            Deck gameDeck = new Deck();

            Game game = new Game(Player1, Player2, gameDeck);

            // Begin the game
            game.StartGameLoop();
        }
    }
}
