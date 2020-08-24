// Implement the StreamChecker class as follows:

// StreamChecker(words): Constructor, init the data structure with the given words.
// query(letter): returns true if and only if for some k >= 1, the last k characters queried (in order from oldest to newest, including this letter just queried) spell one of the words in the given list.
using System;
using System.Collections.Generic;

namespace algorithms
{
    public class StreamChecker
    {
        private Trie head;
        private List<char> queries;
        private int max;

        public StreamChecker(string[] words) {
            this.head = new Trie();
            this.queries = new List<char>();
            this.max = -1;

            foreach(string word in words)
                insertWord(word);
        }

        private void insertWord(string word) {
            Trie node = this.head;
            
            //WARNING: insert word in reverse so when we search the query we can go from query letter down through most recent queries
            for(int i = word.Length - 1; i >= 0; i--) {
                char c = word[i];
                Trie next = node.children[c - 'a'];

                if(next == null) {
                    next = new Trie();
                    node.children[c - 'a'] = next;
                }

                node = node.children[c - 'a'];
            }

            node.endOfWord = true;
        }
        
        public bool Query(char letter) {
            Trie head = this.head;
            
            queries.Add(letter);
            max++;

            for(int i = max; i >= 0; i--) {
                char c = queries[i];

                if(head.children[c - 'a'] == null) {
                    return false;
                } 

                head = head.children[c - 'a'];

                if(head.endOfWord) {
                    return true;
                }
            }

            return false;
        }

        public class Trie {
            public bool endOfWord {get; set;} = false;
            public Trie[] children {get;set;} = new Trie[26];
        }
    }
}