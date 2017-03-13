using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesForTestingAI
{
    class PlayerTTTRandom : IPlayerTTT
    {
        TicTacToeBoard board;
        int[] boardstate;

        public PlayerTTTRandom(TicTacToeBoard board)
        {
            this.board = board;
            boardstate = board.Board;
        }

        public void Play()
        {
            Random rnd = new Random();
            int moveHere = rnd.Next(0, 8);
            while (boardstate[moveHere] != 0)
            {
                moveHere = rnd.Next(0, 9);
            }
            board.PlacePiece(moveHere);
        }
    }
}
