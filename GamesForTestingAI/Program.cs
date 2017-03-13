using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesForTestingAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Program MyProgram = new Program();
            MyProgram.RunTTT();

            Console.Write("Tell me what you want: ");
            string input = Console.ReadLine();
            while (input != "")
            {
                switch (input)
                {
                    case "t":
                        MyProgram.RunTTT();
                        break;
                    default:
                        break;
                }
                Console.Write("Tell me what you want: ");
                input = Console.ReadLine();
            }
        }

        public void RunTTT()
        {
            TicTacToeBoard board = new TicTacToeBoard();

            board.StartGame(1000);

            int player1wins = 0;
            int player2wins = 0;
            int draw = 0;
            foreach (var item in board.Winners)
            {
                switch (item)
                {
                    case 0:
                        draw++;
                        break;
                    case 1:
                        player1wins++;
                        break;
                    case 2:
                        player2wins++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Player 1 wins: " + player1wins);
            Console.WriteLine("Player 2 wins: " + player2wins);
            Console.WriteLine("Draw: " + draw);
        }
    }
}
