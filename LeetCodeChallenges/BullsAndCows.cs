// You are playing the following Bulls and Cows game with your friend: You write down a number and ask your friend to guess what the number is. 
// Each time your friend makes a guess, you provide a hint that indicates how many digits in said guess match your secret number exactly in both 
// digit and position (called "bulls") and how many digits match the secret number but locate in the wrong position (called "cows"). 
// Your friend will use successive guesses and hints to eventually derive the secret number.
// Write a function to return a hint according to the secret number and friend's guess, use A to indicate the bulls and B to indicate the cows. 
// Please note that both secret number and friend's guess may contain duplicate digits.

// Example 1:
// Input: secret = "1807", guess = "7810"
// Output: "1A3B"
// Explanation: 1 bull and 3 cows. The bull is 8, the cows are 0, 1 and 7.

namespace algorithms
{
    public class BullsAndCows
    {
        public static string GetHint(string secret, string guess) {
            int A = 0;
            int B = 0;
            int[] guessmemo = new int[11];
            int[] secretmemo = new int[11];

            for(int i = 0; i < secret.Length; i++) {
                if(secret[i] == guess[i])
                    A++;
                else{
                    int guessidx = guess[i] - '0';
                    int secretidx = secret[i] - '0';
                    guessmemo[guessidx]++;
                    secretmemo[secretidx]++;
                }
            }
            
            for(int i = 0; i < 11; i++) {
                B += guessmemo[i] <= secretmemo[i] ? guessmemo[i] : secretmemo[i]; 
            }
            
            return A + "A" + B + "B";
        }
    }
}