using System;

namespace TicTacToe {
    
    public class Game {

        private Board b;
        private int player = 1;
        private bool hasQuit;
        
        public Game(Board b) {
            this.b = b;
        }

        public void Start() {
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            Console.WriteLine("Here's the current board:\n");
            b.Display();
            while (!HasFinished()) {
                InputChoice();
            }
            if (HasWin()) {
                Console.WriteLine("Move accepted, well done Player {0}, you've won the game!", player);
            } else if (HasDrawn()) {
                Console.WriteLine("Move accepted, the game has ended in a draw.");
            } else {
                Console.WriteLine("Player {0} has quit the game. Player {1} wins!", player, 3 - player);
            }
        }

        private void InputChoice() {
            Console.Write("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", player, player == 1? "X" : "O");
            ProcessInput(Console.ReadLine());
        }

        private void ProcessInput(string s) {
            if (s == "q") {
                hasQuit = true;
            } else if (s.Length != 3 || s[1] != ','
                                     || !int.TryParse(s[0].ToString(), out var x)
                                     || !int.TryParse(s[2].ToString(), out var y)
                                     || x < 1 || x > 3
                                     || y < 1 || y > 3) {
                Console.WriteLine("Invalid input");
                InputChoice();
            }
            else if (b.Get(x, y) == '.') {
                    b.Set(x, y, player == 1 ? 'X' : 'O');
                    Console.WriteLine("Move accepted, here's the current board:\n");
                    b.Display();
                    player = 3 - player; // Switches player between 1 and 2
            } else {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...\n");
            }
        }

        private bool HasFinished() {
            return HasWin() || HasDrawn() || hasQuit;
        }

        private bool HasWin() {
            return b.HasDiagonal() || b.HasHorizontal() || b.HasVertical();
        }

        private bool HasDrawn() {
            return b.IsFull() && !HasWin();
        }
         
    }
}