using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeSmart
{
    class Program
    {
        static string[] board = { " ", " ", " ",
                                  " ", " ", " ",
                                  " ", " ", " " };
        static void Main(string[] args)
        {
            PrintBoard();
            Console.WriteLine("Hello. Lets play tic-tac-toe!");
            Console.WriteLine("You go first.");
            Play();
        }

        static void Play()
        {
            Console.WriteLine("Enter a spot. \"x,y\"");
            char[] delim = { ',' };
            string[] positions = Console.ReadLine().Split(delim); // --> "1, 1" -> ["1", "2"]
            int x = Int32.Parse(positions[0]);
            int y = Int32.Parse(positions[1]);
            if (!(validateInput(x) && validateInput(y)))
            {
                Play();
            }

            int index = GetIndex(x, y);
            if (isSpotOpen(index))
            {
                board[index] = "X";
            }
            else
            {
                Play();
            }

            if (checkForWinner())
            {
                PrintBoard();
                Console.WriteLine("Congratulations!! You are the winner.");
                resetBoard();
            }
            else
            {
                checkCatScratch();
            }

            opponentMove();
            PrintBoard(); 

            Play();

        }

        static void opponentMove()
        {
            int[] openSpots = { -1, -1, -1, -1, -1, -1, -1, -1 };
            int count = 0;
            for (int i = 0; i <= 8; i++)
            {
                if (board[i] == " ")
                {
                    openSpots[count] = i;
                    count += 1;
                }
            }

            int winningIndex;
            winningIndex = checkWinningMove("O");
            if (winningIndex != -1)
            {
                board[winningIndex] = "O";
            }

            winningIndex = checkWinningMove("X");
            if (winningIndex != -1)
            {
                board[winningIndex] = "O";
            }

            if (winningIndex == -1)
            {
                Random rnd = new Random();
                int randomInteger = rnd.Next(0, count);
                board[openSpots[randomInteger]] = "O";
            }

            if (checkForWinner())
            {
                PrintBoard();
                Console.WriteLine("You lose!");
                resetBoard();
                Play();
            }
        }

        static int GetIndex(int x, int y)
        {
            return (x - 1) + (y - 1) * 3;
        }

        static void PrintBoard()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("| {0} | {1} | {2} |", board[0], board[1], board[2]);
            Console.WriteLine("| {0} | {1} | {2} |", board[3], board[4], board[5]);
            Console.WriteLine("| {0} | {1} | {2} |", board[6], board[7], board[8]);
            Console.WriteLine("-------------");
        }

        static bool validateInput(int z)
        {
            if (z > 0 && z <= 3)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Oops! Invalid move. Try again.");
                return false;
            }
        }

        static bool isSpotOpen(int i)
        {
            if (board[i] == "X" || board[i] == "O")
            {
                Console.WriteLine("Oops, that spot is taken. Try again.");
                return false;
            }
            else
            {
                return true;
            }
        }

        static int checkWinningMove(string move)
        {
            if (board[0] == move && board[1] == move && board[2] == " ")
            {
                return 2;
            }
            else if (board[0] == " " && board[1] == move && board[2] == move)
            {
                return 0;
            }
            else if (board[0] == move && board[1] == " " && board[2] == move)
            {
                return 1;
            }
            else if (board[3] == move && board[4] == move && board[5] == " ")
            {
                return 5;
            }
            else if (board[3] == " " && board[4] == move && board[5] == move)
            {
                return 3;
            }
            else if (board[3] == move && board[4] == " " && board[5] == move)
            {
                return 4;
            }
            else if (board[6] == move && board[7] == move && board[8] == " ")
            {
                return 8;
            }
            else if (board[6] == " " && board[7] == move && board[8] == move)
            {
                return 6;
            }
            else if (board[6] == move && board[7] == " " && board[8] == move)
            {
                return 7;
            }
            else if (board[0] == move && board[4] == move && board[8] == " ")
            {
                return 8;
            }
            else if (board[0] == " " && board[4] == move && board[8] == move)
            {
                return 0;
            }
            else if (board[0] == move && board[4] == " " && board[8] == move)
            {
                return 4;
            }
            else if (board[2] == move && board[4] == move && board[6] == " ")
            {
                return 6;
            }
            else if (board[2] == " " && board[4] == move && board[6] == move)
            {
                return 2;
            }
            else if (board[2] == move && board[4] == " " && board[6] == move)
            {
                return 4;
            }
            else if (board[0] == move && board[3] == move && board[6] == " ")
            {
                return 6;
            }
            else if (board[0] == " " && board[3] == move && board[6] == move)
            {
                return 0;
            }
            else if (board[0] == move && board[3] == " " && board[6] == move)
            {
                return 3;
            }
            else if (board[1] == move && board[4] == move && board[7] == " ")
            {
                return 7;
            }
            else if (board[1] == " " && board[4] == move && board[7] == move)
            {
                return 1;
            }
            else if (board[1] == move && board[4] == " " && board[7] == move)
            {
                return 4;
            }
            else if (board[2] == move && board[5] == move && board[8] == " ")
            {
                return 8;
            }
            else if (board[2] == " " && board[5] == move && board[8] == move)
            {
                return 2;
            }
            else if (board[2] == move && board[5] == " " && board[8] == move)
            {
                return 5;
            }
            else
            {
                return -1;
            }
        }
    

        static bool checkForWinner()
        {
            if (
                (board[0] == board[1] && board[1] == board[2] && board[2] != " ") ||
                (board[3] == board[4] && board[4] == board[5] && board[5] != " ") ||
                (board[6] == board[7] && board[7] == board[8] && board[8] != " ") ||
                (board[0] == board[4] && board[4] == board[8] && board[8] != " ") ||
                (board[2] == board[4] && board[4] == board[6] && board[6] != " ") ||
                (board[0] == board[3] && board[3] == board[6] && board[6] != " ") ||
                (board[1] == board[4] && board[4] == board[7] && board[7] != " ") ||
                (board[2] == board[5] && board[5] == board[8] && board[8] != " ")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool checkCatScratch()
        {
            if ((board[0] != " " && checkForWinner() == false) &&
                (board[1] != " " && checkForWinner() == false) &&
                (board[2] != " " && checkForWinner() == false) &&
                (board[3] != " " && checkForWinner() == false) &&
                (board[4] != " " && checkForWinner() == false) &&
                (board[5] != " " && checkForWinner() == false) &&
                (board[6] != " " && checkForWinner() == false) &&
                (board[7] != " " && checkForWinner() == false) &&
                (board[8] != " " && checkForWinner() == false))
            {
                Console.WriteLine("Catscratch!! There is no winner.");
                resetBoard();
                return true;
            }
            else
            {
                return false;
            }
        }

        static void resetBoard()
        {
            Console.WriteLine("Would you like to play again? (y/n)");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                board[0] = " ";
                board[1] = " ";
                board[2] = " ";
                board[3] = " ";
                board[4] = " ";
                board[5] = " ";
                board[6] = " ";
                board[7] = " ";
                board[8] = " ";
                PrintBoard();
                Play();
            }
            else
            {
                System.Environment.Exit(0);
            }
        }
    }
}
