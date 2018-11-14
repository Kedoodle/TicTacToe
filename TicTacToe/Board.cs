using System;

namespace TicTacToe {
    
    public class Board {
        
        private char[,] slots = new char[3, 3];
        
        public Board() {
            for (int y = 0; y < 3; y++) {
                for (int x = 0; x < 3; x++) {
                    slots[x, y] = '.';
                }
            }
        }
        
        public void Display() {
            Console.WriteLine("{0} {1} {2}", slots[0, 0], slots[1, 0], slots[2, 0]);
            Console.WriteLine("{0} {1} {2}", slots[0, 1], slots[1, 1], slots[2, 1]);
            Console.WriteLine("{0} {1} {2}\n", slots[0, 2], slots[1, 2], slots[2, 2]);
        }

        public char Get(int x, int y) {
            return slots[x - 1, y - 1];
        }

        public void Set(int x, int y, char c) {
            slots[x - 1, y - 1] = c;
        }

        public bool IsFull() {
            for (int y = 0; y < 3; y++) {
                for (int x = 0; x < 3; x++) {
                    if (slots[x, y] == '.')
                        return false;
                }
            }
            return true;
        }

        public bool HasDiagonal() {
            return slots[0, 0] == slots[1, 1] && slots[1, 1] == slots[2, 2] && slots[1, 1] != '.'
                || slots[2, 0] == slots[1, 1] && slots[1, 1] == slots[2, 2] && slots[1, 1] != '.';
        }


        public bool HasHorizontal() {
            return slots[0, 0] == slots[1, 0] && slots[1, 0] == slots[2, 0] && slots[1, 0] != '.'
                || slots[0, 1] == slots[1, 1] && slots[1, 1] == slots[2, 1] && slots[1, 1] != '.'
                || slots[0, 2] == slots[1, 2] && slots[1, 2] == slots[2, 2] && slots[1, 2] != '.';
        }


        public bool HasVertical() {
            return slots[0, 0] == slots[0, 1] && slots[0, 1] == slots[0, 2] && slots[0, 1] != '.' 
                || slots[1, 0] == slots[1, 1] && slots[1, 1] == slots[1, 2] && slots[1, 1] != '.' 
                || slots[2, 0] == slots[2, 1] && slots[2, 1] == slots[2, 2] && slots[2, 1] != '.';
        }
    }
}