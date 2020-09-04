// Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together. 
// You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.

// Example 1:

// Input: "abab"
// Output: True
// Explanation: It's the substring "ab" twice.
using System.Collections.Generic;

namespace algorithms
{
    public class RepeatedSubstringPattern
    {
        public static bool RepeatedSubstring(string s) {
            Queue<char> substring = new Queue<char>();

            bool isRepeated = true;

            for(int i = 0; i < s.Length; i++) {
                char c = s[i];

                if(substring.Count > 0 && substring.Peek() == c) {
                    i = checkSubstring(i, s, ref substring);
                } else {
                    substring.Enqueue(c);
                }
            }
            
            //if q has anything then did not find repeat
            if(substring.Count > 0)
                isRepeated = false;

            return isRepeated;
        }

        private static int checkSubstring(int i, string s, ref Queue<char> substringToCheck) {
            Queue<char> substringToSave = new Queue<char>();
            int initial = i;
            int count = substringToCheck.Count;
            bool isRepeating = true;

            while(i < s.Length && isRepeating) {
                char c = s[i];

                if(substringToCheck.Count > 0 && substringToCheck.Peek() == c) {
                    char temp = substringToCheck.Dequeue();
                    substringToSave.Enqueue(temp);
                } else if(substringToCheck.Count > 0 && substringToCheck.Peek() != c) {
                    while(substringToCheck.Count > 0) {
                        substringToSave.Enqueue(substringToCheck.Dequeue());
                    }

                    substringToSave.Enqueue(s[initial]);
                    i = initial++;

                    isRepeating = false;
                }

                if(substringToCheck.Count == 0 && substringToSave.Count > 0) {
                    Queue<char> temp = substringToCheck;
                    substringToCheck = substringToSave;
                    substringToSave = temp;
                }

                if(isRepeating)
                    i++;
            }

            if(isRepeating && substringToCheck.Count == count)
                substringToCheck.Clear();

            return i;
        }
    }
}