using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLLD.Model
{
    internal class Player
    {
        private readonly string _name;
        private readonly Piece _piece;

        public Player(string name, Piece piece)
        {
            _name = name;
            _piece = piece;
        }

        public string Name => _name;
        public Piece Piece => _piece;
    }
}
