using System;

namespace algorithms
{
    public class bigO
    {
        int numChars = 26;

        public void printSortedStrings(int remaining) {
            printSortedStrings(remaining, "");
        }

        private void printSortedStrings(int remaining, string prefix) {
            if(remaining == 0) {
                if(isInOrder(prefix)) { // k where k is number of spots
                    Console.WriteLine(prefix);
                }
            }       
            else {
                for(int i = 0; i < numChars; i++) {
                    char c = ithLetter(i);
                    printSortedStrings(remaining - 1, prefix + c);
                }//n^k where n is alphabet size, k is number spots
            }
        }

        private bool isInOrder(string s) {
            for(int i = 1; i < s.Length; i++) {
                int prev = ithLetter(s[i - 1]);
                int curr = ithLetter(s[i]);

                if(prev > curr) {
                    return false;
                }

            }
            
            return true;
        }

        private char ithLetter(int i) {
            return((char)((int)'a' + i));
        }
    }
}