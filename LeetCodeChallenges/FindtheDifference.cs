using static System.Math;

namespace algorithms
{
    public class FindtheDifference
    {
        public static char FindTheDifference(string s, string t) {
            string all = s + t;
            int diff = 0;

            foreach(char c in all) {
                diff ^= c;
            }

            return (char)diff;
        }

        // public static char FindTheDifference(string s, string t) {
        //     int difference = 0;
        //     int mask = 0;

        //     for(int i = 0; i < t.Length; i++){
        //         mask = 1 << t[i] - 'a';
        //         difference ^= mask;

        //         if(i < s.Length){
        //             mask = 0;
        //             mask = 1 << s[i] - 'a';
        //             difference ^= mask;
        //         }

        //         mask = 0;
        //     }
            
        //     difference = (int)Log2((double)difference);

        //     return((char)('a' + difference));
        // }
    }
}