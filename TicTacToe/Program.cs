namespace TicTacToe {

    internal class Program {
        
        public static void Main(string[] args) {

            var b = new Board();
            Game g = new Game(b);
            g.Start();
        }
        
    }
}