using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLLD.Model
{
    internal class Board
    {
        private int _size;
        private Piece?[][] _board;
        public Board(int size)
        {
            _size = size;
            _board = new Piece?[size][];
            for (int i = 0; i < size; i++)
                _board[i] = new Piece?[size];
        }

        public int Size  => _size; 

        public void AddPiece(int row, int col, Piece piece)
        {
            if (_board[row][col] != null)
                throw new Exception($"The position {row} {col} is not empty");

            _board[row][col] = piece;
        }

        public List<Tuple<int, int>> GetFreeCells()
        {
            List<Tuple<int, int>> freeCells = new List<Tuple<int, int>>();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_board[i][j] == null)
                    {
                        Tuple<int, int> rowColumn = new Tuple<int, int>(i, j);
                        freeCells.Add(rowColumn);
                    }
                }
            }



            return freeCells;
        }

        public bool EntireRowContainsPiece(int row, Piece piece)
        {
            for (int i = 0; i < _size; i++)
            {

                if (_board[row][i] == null || _board[row][i] != piece)
                {
                     return false;
                }
            }

            return true;
        }

        public bool EntireColContainsPiece(int column, Piece piece)
        {
            for (int i = 0; i < _size; i++)
            {

                if (_board[i][column] == null || _board[i][column] != piece)
                {
                    return false;
                }
            }

            return true;
        }

        public bool EntireLeadingDiagonalContainsPiece(Piece piece)
        {
            for (int i = 0, j = 0; i < _size; i++, j++)
            {
                if (_board[i][j] == null || _board[i][j] != piece)
                {
                    return false;
                }
            }

            return true;
        }

        public bool EntireAntiDiagonalContainsPiece(Piece piece)
        {
            for (int i = 0, j = _size - 1; i < _size; i++, j--)
            {
                if (_board[i][j] == null || _board[i][j] != piece)
                {
                    return false;
                }
            }

            return true;
        }

        public void PrintBoard()
        {

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_board[i][j] != null)
                    {
                        Console.Write(_board[i][j]!.Value.ToString() + "   ");
                    }
                    else
                    {
                        Console.Write("    ");

                    }
                    Console.Write(" | ");
                }
                
                Console.WriteLine();
            }
        }

    }
}
