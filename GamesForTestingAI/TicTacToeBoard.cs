using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesForTestingAI
{
    class TicTacToeBoard
    {
        IPlayerTTT Player1;
        IPlayerTTT Player2;
        public int[] Board { get; private set; }
        int CurrentPlayer = 0;
        int Winner = -1; // 0 = draw 1 = player1 2 = player2
        bool MoveAccepted = false;
        int TurnCounter = 0;
        public List<int> Winners { get; private set; }

        public TicTacToeBoard()
        {
            Winners = new List<int>();
            Board = new int[9];
            ResetBoard();
            Player1 = new PlayerTTTRandom(this);
            Player2 = new PlayerTTTRandom(this);
        }

        private void ResetBoard()
        {
            Winner = -1;
            TurnCounter = 0;
            CurrentPlayer = 0;

            for (int i = 0; i < 9; i++)
            {
                Board[i] = 0;
            }
        }

        public bool PlacePiece(int place)
        {
            if (Board[place] != 0)
            {
                MoveAccepted = false;
                return false;
            }
            Board[place] = CurrentPlayer;
            MoveAccepted = true;
            return true;
        }

        private void CheckForWin()
        {
            // 0,1,2
            if (Board[0] == Board[1] && Board[0] == Board[2] && Board[0] != 0)
            {
                Winner = Board[0];
            }
            // 3,4,5
            if (Board[3] == Board[4] && Board[3] == Board[5] && Board[3] != 0)
            {
                Winner = Board[3];
            }
            // 6,7,8
            if (Board[6] == Board[7] && Board[6] == Board[8] && Board[6] != 0)
            {
                Winner = Board[6];
            }
            // 0,3,6
            if (Board[0] == Board[3] && Board[0] == Board[6] && Board[0] != 0)
            {
                Winner = Board[0];
            }
            // 1,4,7
            if (Board[1] == Board[4] && Board[1] == Board[7] && Board[1] != 0)
            {
                Winner = Board[1];
            }
            // 2,5,8
            if (Board[2] == Board[5] && Board[2] == Board[8] && Board[2] != 0)
            {
                Winner = Board[2];
            }
            // 0,4,8
            if (Board[0] == Board[4] && Board[0] == Board[8] && Board[0] != 0)
            {
                Winner = Board[0];
            }
            // 2,4,6
            if (Board[2] == Board[4] && Board[2] == Board[6] && Board[2] != 0)
            {
                Winner = Board[2];
            }
        }

        public void StartGame(int playThrougs)
        {
            for (int i = 0; i < playThrougs; i++)
            {
                while (Winner == -1)
                {
                    if (CurrentPlayer == 0) // first move
                    {
                        CurrentPlayer = 1;
                    }
                    if (CurrentPlayer == 1) // if player1
                    {
                        Player1.Play();
                    }
                    if (CurrentPlayer == 2) // if player2
                    {
                        Player2.Play();
                    }
                    if (MoveAccepted && CurrentPlayer == 1)
                    {
                        CurrentPlayer = 2;
                        TurnCounter++;
                    }
                    else if(MoveAccepted)
                    {
                        CurrentPlayer = 1;
                        TurnCounter++;
                    }
                    CheckForWin();
                    if (TurnCounter == 9 && Winner == -1)
                    {
                        Winner = 0;
                    }
                    //VisualizeShit();
                }
                Winners.Add(Winner);
                ResetBoard();
            }
        }

        private void VisualizeShit()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.Write(Board[i] + " ");
            }
            Console.WriteLine();
            for (int i = 3; i < 6; i++)
            {
                Console.Write(Board[i] + " ");
            }
            Console.WriteLine();
            for (int i = 6; i < 9; i++)
            {
                Console.Write(Board[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Turn: " + TurnCounter);
            Console.WriteLine();
            Console.WriteLine("Games played: " + Winners.Count);
            for (int i = 0; i < Winners.Count; i++)
            {
                string temp = " won by Player " + Winners[i].ToString();
                if (Winners[i] == 0)
                {
                    temp = "was draw";
                }
                Console.WriteLine("Game " + (i+1) + temp);
            }

            Thread.Sleep(1000); // smooooooth gameplay........
        }
    }
}
