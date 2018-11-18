using System;
using System.Collections.Generic;

namespace TicTacToe {
    
    public class Board {
        
        private char[,] slots = new char[3, 3];
        
        public Board() {
            for (var y = 0; y < 3; y++) {
                for (var x = 0; x < 3; x++) {
                    slots[x, y] = '.';
                }
            }
        }
        
        public void Display() {
            Console.WriteLine("{0} {1} {2}", slots[0, 0], slots[1, 0], slots[2, 0]);
            Console.WriteLine("{0} {1} {2}", slots[0, 1], slots[1, 1], slots[2, 1]);
            Console.WriteLine("{0} {1} {2}\n", slots[0, 2], slots[1, 2], slots[2, 2]);
        }
        
        public List<Tuple<int, int>> GetAvailableSlots() {
            var availableSlots = new List<Tuple<int, int>>();
            for (var y = 0; y < 3; y++) {
                for (var x = 0; x < 3; x++) {
                    if (slots[x, y] == '.')
                        availableSlots.Add(new Tuple<int, int>(x + 1, y + 1));
                }
            }
            return availableSlots;
        }

        public char GetSlot(int x, int y) {
            return slots[x - 1, y - 1];
        }

        public void SetSlot(int x, int y, char c) {
            slots[x - 1, y - 1] = c;
        }

        public bool IsFull() {
            for (var y = 0; y < 3; y++) {
                for (var x = 0; x < 3; x++) {
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