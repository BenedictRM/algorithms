// Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

// Note:

// The same word in the dictionary may be reused multiple times in the segmentation.
// You may assume the dictionary does not contain duplicate words.

using System;
using System.Collections.Generic;
namespace algorithms
{
    public class WordBreak
    {
        //DP solution: resource https://www.youtube.com/watch?v=iWenZCZEBIA&ab_channel=FisherCoder
        public static bool IsWordBreakPossible(string s, IList<string> wordDict) {
            int len = s.Length;
            // +1 and 0 = true to handle empty strings 
            bool[] dp = new bool[len + 1];
            dp[0] = true;

            int maxLen = 0;
            foreach(string word in wordDict)
                maxLen = Math.Max(maxLen, word.Length);

            for(int i = 0; i <= len; i++){
                for(int j = 0; j < i; j++){
                    int length = i - j;
                    if(length > maxLen)
                        continue;

                    // Console.WriteLine("checking {0}", substr);

                    if(dp[j] && wordDict.Contains(s.Substring(j, length))){
                        dp[i] = true;
                        // Console.WriteLine("found! idx: {0}", i);
                        
                        break;
                    }
                }
            }

            return dp[len];
        }

        // First shot -- trie with stack, this coould prob work, but is definitely more difficult than neeeded 
        // Build Trie with all words in wordDict O(W*L)
        // Then using a stack walk the string, if word created via substring 0 - i (if stack empty)
        // or stack.peek() to i, stack.push(i);
        // if reach end and cannot make a word, stack.pop(), advance i by 1
        // if stack.peek() - i is a word still, continue, else keep popping until stack empty
        // if still cannot make a word return false
        // if we reach the end and cannot make a word and stack is empty, return false
        // else if can reach and and make a word from stack.peek -> i then return true
        // idea: perhaps push 0 onto the stack so you always got a range, if cannot make a word then false

        // private static TrieNode[] trie;
        // private static Stack<int> spaces;

        // public static bool IsWordBreakPossible(string s, IList<string> wordDict) {
        //     trie = new TrieNode[26];
        //     spaces = new Stack<int>();
        //     bool isPossible = true;

        //     buildTrie(wordDict);

        //     // foreach(TrieNode t in trie) {
        //     //     if(t != null)
        //     //         Console.WriteLine("trie node letter: {0}", t.letter); 
        //     //     else
        //     //         Console.WriteLine("null"); 
        //     // }

        //     spaces.Push(0);
        //     int length = 1;
        //     for(int i = 0; i < s.Length; i++) {
        //         if(!isPossible || spaces.Count == 0) {
        //             isPossible = false;
        //             break;
        //         }

        //         TrieNode[] root = trie;
        //         // Console.WriteLine("peek: {0}, length {1}", spaces.Peek(), length);
        //         string substr = s.Substring(spaces.Peek(), length);
        //         Console.WriteLine("substr: {0}, i: {1}", substr, i);

        //         for(int j = 0; j < substr.Length; j++) {
        //             char c = substr[j];
        //             // Console.WriteLine("letter {0}", c);
        //             if(root[c - 'a'] != null){
        //                 // Console.WriteLine("letter found {0}, isWord {1}", c, root[c - 'a'].isWord);
        //                 if(j == substr.Length - 1 && root[c - 'a'].isWord) {
        //                     Console.WriteLine("Word Found!");
        //                     //valid word store space
        //                     spaces.Push(i + 1);
        //                     length = 0;
        //                 } else {
        //                     root = root[c - 'a'].alphabet;
        //                 }
        //             } else {
        //                 if(spaces.Count > 0) {
        //                     //pop and check again
        //                     Console.WriteLine("Popping");
        //                     i = spaces.Pop() - 1;                             
        //                 } else {
        //                     isPossible = false;
        //                 }

        //                 length = 0;
                        
        //                 break;
        //             }
        //         }
        //         length++;
        //     }

        //     return isPossible;
        // }

        // private static void buildTrie(IList<string> wordDict) {
        //     // int count = 0;
        //     foreach(string word in wordDict){
        //         TrieNode[] root = trie;
        //         for(int i = 0; i < word.Length; i++){
        //             char c = word[i];
        //             TrieNode letter = root[c - 'a'];
        //             // Console.WriteLine("letter {0}", c);
        //             if(letter == null){
        //                 root[c - 'a'] = new TrieNode();
        //                 letter = root[c - 'a'];
        //                 root = letter.alphabet;
        //             } else {
        //                 root = letter.alphabet;
        //             }

        //             letter.letter = c;

        //             if(i == word.Length - 1) {
        //                 letter.isWord = true;
        //                 // count++;
        //             }
        //         }
        //     }

        //     // Console.WriteLine("Count is {0}", count);
        // }

        // private class TrieNode {
        //     public TrieNode[] alphabet {get;set;}
        //     public char letter {get;set;}
        //     public bool isWord {get;set;}

        //     public TrieNode() {
        //         this.alphabet = new TrieNode[26];
        //         this.isWord = false;
        //     }
        // }
    }
}