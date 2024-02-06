using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using TicTacToeLLD.Model;

namespace TicTacToeLLD
{
    internal class TicTacToeGame
    {

        LinkedList<Player> players;
        Board gameBoard;


        public void initializeGame()
        {

            //creating 2 Players
            players = new LinkedList<Player>();
            Player player1 = new Player("Player1", Piece.X);

            Player player2 = new Player("Player2", Piece.O);

            players.AddLast(player1);
            players.AddLast(player2);

            //initializeBoard
            gameBoard = new Board(3);
        }

        public String StartGame()
        {
            bool gotAWinner = false;
            while (!gotAWinner)
            {
                //take out the player whose turn is and also put the player in the list back
                Player playerTurn = players.First();
                players.RemoveFirst();

                //get the free space from the board
                gameBoard.PrintBoard();
                List<Tuple<int, int>> freeSpaces = gameBoard.GetFreeCells();
                if (!freeSpaces.Any())
                {
                    gotAWinner = false;
                    continue;
                }

                //read the user input
                Console.Write("Player:" + playerTurn.Name + " Enter row,column: ");
                String s = Console.ReadLine();
                String[] values = s.Split(",");
                int inputRow = Int32.Parse(values[0]);
                int inputColumn = Int32.Parse(values[1]);


                //place the piece
                try
                {
                    gameBoard.AddPiece(inputRow, inputColumn, playerTurn.Piece);
                }
                catch(Exception ex) { 
                    //player can not insert the piece into this cell, player has to choose another cell
                    Console.WriteLine("Incorred possition chosen, try again");
                    players.AddFirst(playerTurn);
                    continue;
                }
                players.AddLast(playerTurn);

                bool winner = IsThereWinner(inputRow, inputColumn, playerTurn.Piece);
                if (winner)
                {
                    return playerTurn.Name;
                }
            }

            return "tie";
        }

        public bool IsThereWinner(int row, int column, Piece piece)
        {

            bool rowMatch = gameBoard.EntireRowContainsPiece(row, piece);
            bool columnMatch = gameBoard.EntireColContainsPiece(column, piece);
            bool diagonalMatch = gameBoard.EntireLeadingDiagonalContainsPiece(piece);
            bool antiDiagonalMatch = gameBoard.EntireAntiDiagonalContainsPiece(piece);

            return rowMatch || columnMatch || diagonalMatch || antiDiagonalMatch;
        }
    }
}

