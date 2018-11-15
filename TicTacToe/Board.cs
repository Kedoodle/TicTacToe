using System;

namespace TicTacToe {
    
    public class Board {

        private int size;
        private char[,] slots;
        
        public Board(int s) {
            size = s < 1 ? 1 : s;
            slots = new char[size, size];
            for (var y = 0; y < size; y++) {
                for (var x = 0; x < size; x++) {
                    slots[x, y] = '.';
                }
            }
        }

        public char Get(int x, int y) {
            return slots[x - 1, y - 1];
        }

        public void Set(int x, int y, char c) {
            slots[x - 1, y - 1] = c;
        }

        public int Size() {
            return size;
        }
        
        public void Display() {
            for (var y = 0; y < size; y++) {
                for (var x = 0; x < size; x++) {
                    Console.Write(slots[x, y] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool IsFull() {
            for (var y = 0; y < size; y++) {
                for (var x = 0; x < size; x++) {
                    if (slots[x, y].Equals('.'))
                        return false;
                }
            }
            return true;
        }

        public bool HasDiagonal() {
            return HasForwardDiagonal() || HasBackwardDiagonal();
        }

        private bool HasForwardDiagonal() {
            if (slots[0, 0].Equals('.'))
                return false;
            for (var i = 0; i < size; i++) {
                if (!slots[i, i].Equals(slots[0, 0]))
                    return false;
            }
            return true;
        }
        
        private bool HasBackwardDiagonal() {
            if (slots[size - 1, 0].Equals('.'))
                return false;
            for (var i = 0; i < size; i++) {
                if (!slots[size - 1 - i, i].Equals(slots[size - 1, 0]))
                    return false;
            }
            return true;
        }


        public bool HasHorizontal() {
            for (var y = 0; y < size; y++) {
                if (CheckRow(y))
                    return true;
            }
            return false;
        }

        private bool CheckRow(int y) {
            if (slots[0, y].Equals('.'))
                return false;
            for (var x = 0; x < size; x++) {
                if (!slots[x, y].Equals(slots[0, y]))
                    return false;
            }
            return true;
        }

        public bool HasVertical() {
            for (var x = 0; x < size; x++) {
                if (CheckColumn(x))
                    return true;
            }
            return false;
        }

        private bool CheckColumn(int x) {
            if (slots[x, 0].Equals('.'))
                return false;
            for (var y = 0; y < size; y++) {
                if (!slots[x, y].Equals(slots[x, 0]))
                    return false;
            }
            return true;
        }
    }
}