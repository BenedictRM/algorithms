
using System;
using System.Text;
using System.Collections;

namespace algorithms
{
    public class StringManipulation
    {

        public static void ReverseStringBuiltIn(string s) {
            char[] chars = s.ToCharArray(); 
            Array.Reverse(chars);
    
            StringBuilder builder = new StringBuilder();
            builder.Append(chars);

            Console.WriteLine(builder.ToString());
        }

        public static void ReverseString(string s) {
            char[] chars = new char[s.Length];

            for(int i = s.Length - 1; i >= 0; i--) {
                chars[s.Length - 1 - i] = s[i];
            }
            
            string reversed = new string(chars);

            Console.WriteLine(reversed);
        }

        public static void ReverseStringArrayList(string s) {
            ArrayList chars = new ArrayList();
            chars.AddRange(s.ToCharArray());
            chars.Reverse();

            StringBuilder sb = new StringBuilder();
            foreach(char c in chars)
                sb.Append(c);

            Console.WriteLine(sb.ToString());
        }
    }
}