// A sentence S is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.

// We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)

// The rules of Goat Latin are as follows:

// If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
// For example, the word 'apple' becomes 'applema'.
 
// If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
// For example, the word "goat" becomes "oatgma".
 
// Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
// For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
// Return the final sentence representing the conversion from S to Goat Latin. 

//Examples
// Input: "I speak Goat Latin"
// Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"

// Input: "The quick brown fox jumped over the lazy dog"
// Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"
using System;
using System.Text;
using System.Collections.Generic;

namespace algorithms
{
    public class GoatLatin
    {
        private static readonly HashSet<char> VOWELS = new HashSet<char>{'a', 'e', 'i', 'o', 'u'};
        public static string ToGoatLatin(string s) {
            List<string> words = new List<string>(s.Split(' '));
            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < words.Count; i++){
                List<char> chars = new List<char>(words[i].ToCharArray());

                if(!VOWELS.Contains(char.ToLower(chars[0]))){
                    char c = chars[0];
                    chars.Remove(c);
                    chars.Add(c);
                } 

                builder.Append(chars.ToArray());
                builder.Append("ma");
                builder.Append(new String('a', i + 1));

                if(i != words.Count - 1)
                    builder.Append(" ");
            }

            return builder.ToString();
        }
    }
}