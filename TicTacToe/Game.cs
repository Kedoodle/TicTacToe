using System;

namespace TicTacToe {
    
    public class Game {

        private Board board;
        private bool isPlayerTurn = true;
        private bool hasQuit;
        
        public Game(Board b) {
            board = b;
        }

        public void Start() {
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            Console.WriteLine("Here's the current board:\n");
            board.Display();
            while (!HasFinished()) {
                NextTurn();
            }
            if (hasQuit) {
                Console.WriteLine("You have quit the game. AI wins!");
            }
            else if (HasDraw()) {
                Console.WriteLine("The game has ended in a draw");
            }
            else {
                Console.WriteLine("{0} won the game!", isPlayerTurn ? "AI" : "You");
            }
         }

        private void NextTurn() {
            if (isPlayerTurn) {
                PlayerMove();
            }
            else {
                AIMove();
            }
        }

        private void AIMove() {
            var bestVal = -10;
            var move = new Tuple<int, int>(-1, -1);
            var availableSlots = board.GetAvailableSlots();
            foreach (var slot in availableSlots)
            {
                board.SetSlot(slot.Item1, slot.Item2, 'O');
                var moveVal = MiniMax(false);
                board.SetSlot(slot.Item1, slot.Item2, '.');
                if (moveVal > bestVal) {
                    bestVal = moveVal;
                    move = slot;
                }
            }
            ProcessMove(move.Item1, move.Item2);
            
        }

        private int MiniMax(bool isAI) {
            
            if (HasWin()) {
                return isAI ? -10 : 10;
            }
            if (HasDraw()) {
                return 0;
            }

            int score;
            var availableSlots = board.GetAvailableSlots();
            
            if (isAI) {
                score = -100;
                foreach (var slot in availableSlots)
                {
                    board.SetSlot(slot.Item1, slot.Item2, 'O');
                    score = Math.Max(score, MiniMax(!isAI));
                    board.SetSlot(slot.Item1, slot.Item2, '.');
                }
            }
            else {
                score = 100;
                foreach (var slot in availableSlots)
                {
                    board.SetSlot(slot.Item1, slot.Item2, 'X');
                    score = Math.Min(score, MiniMax(!isAI));
                    board.SetSlot(slot.Item1, slot.Item2, '.');
                }
            }

            return score;

        }
        
        
        private void PlayerMove() {
            var input = GetInput();
            if (input == "q")
                hasQuit = true;
            else {
                ProcessInput(input);
            }
        }

        private static string GetInput() {
            Console.Write("Please enter a coord x,y to place your X or enter 'q' to give up: ");
            var input = Console.ReadLine();
            while (!IsValidInput(input)) {
                Console.Write("Invalid input! Please try again: ");
                input = Console.ReadLine();
            }
            return input;
        }

        private static bool IsValidInput(string input) {
            if (input == "q")
                return true;
            return input.Length == 3 && input[1] == ','
                                     && int.TryParse(input[0].ToString(), out var x)
                                     && int.TryParse(input[2].ToString(), out var y)
                                     && x > 0 && x < 4
                                     && y > 0 && y < 4;
        }

        private void ProcessInput(string input) {
            var x = int.Parse(input[0].ToString());
            var y = int.Parse(input[2].ToString());
            ProcessMove(x, y);
        }

        private void ProcessMove(int x, int y) {
            if (board.GetSlot(x, y) == '.') {
                board.SetSlot(x, y, isPlayerTurn ? 'X' : 'O');
                Console.WriteLine("{0} move accepted, here's the current board:\n", isPlayerTurn ? "Player" : "AI");
                board.Display();
                isPlayerTurn = !isPlayerTurn;
            } else {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...\n");
            }
        }

        private bool HasFinished() {
            return HasWin() || HasDraw() || hasQuit;
        }

        private bool HasWin() {
            return board.HasDiagonal() || board.HasHorizontal() || board.HasVertical();
        }

        private bool HasDraw() {
            return board.IsFull() && !HasWin();
        }
         
    }
}