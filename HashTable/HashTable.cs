
using System;

namespace algorithms {
    public class HashTable {
        string input;
        public HashTable() {
            input = string.Empty;

            Console.WriteLine("Hashing!");
            BeginHashing();
        }

        private void BeginHashing() {
            while(!input.Equals("quit")) {
                Console.Write("Enter string to hash: ");
                input = Console.ReadLine();

                Console.WriteLine("Additive: {0}", AdditiveHash(input));
                Console.WriteLine("Additive: {0}", FoldingHash(input));
            }
        }

        private int AdditiveHash(string input) {
            int hash = 0;

            foreach(char c in input)
                hash += unchecked((int)c);

            return hash;
        }

        private int FoldingHash(string input) {
            int hash = 0;
            int chunkSize = 4;
            int arraySize = (int)Math.Ceiling(((double)input.Length / (double)chunkSize));
            string[] substrings = new string[arraySize];

            int idx = 0;
            for(int i = 0; i < input.Length; i += chunkSize) {
                substrings[idx] = input.Substring(i, Math.Min(chunkSize, input.Length - i));
                idx++;
            }

            foreach(string sub in substrings) {
                int bytes = 0;
                int shift = 0;

                foreach(char c in sub) {
                    bytes += c << shift;
                    shift += 8;
                }
                hash += (int)bytes;
            }

            return hash;
        }
    }
}