using System;

namespace TicTacToe {

    internal class Program {
        
        public static void Main(string[] args) {
            Console.Write("Enter a board size: ");
            var input = Console.ReadLine();
            int size;
            while (!int.TryParse(input, out size) || size < 1) {
                Console.Write("Invalid natural number. Enter a board size: ");
                input = Console.ReadLine();
            }
            Console.WriteLine();
            var b = new Board(size);
            var g = new Game(b);
            g.Start();
        }
        
    }
}