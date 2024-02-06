namespace TicTacToeLLD
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            
            ticTacToeGame.initializeGame();

            Console.WriteLine("game winner is: " + ticTacToeGame.StartGame());
        }
    }
}
