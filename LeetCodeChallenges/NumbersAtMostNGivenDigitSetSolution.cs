namespace algorithms.LeetCodeChallenges
{
    public class NumbersAtMostNGivenDigitSetSolution
    {
        //Problem: https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3538/

        //Test Cases:
//      ["1","3","4","5","6","9"]
        // 45702
        // ["5","7","8"]
        // 59
        // ["2","3","4","5","6","7","8"]
        // 3154
        // ["1","2","3","4","6","7","8","9"]
        // 4764
        // ["1","2","3","4","6","7","9"]
        // 333
        // ["3","4","8"]
        // 4
        // ["7"]
        // 8
        // ["1","3","5","7","2"]
        // 216
        // ["1","3","5","7","2"]
        // 200
        // ["1","3","5","7"]
        // 100
        // ["1","4","9"]
        // 1000000000
        // ["1","4","9"]
        // 100000000
        // ["1","2","3","4","5","6","7","8","9"]
        // 91243
        public int AtMostNGivenDigitSet(string[] digits, int target) {
            int k = (int)Math.Log10(target);
            int n = digits.Length;
            int possibleSets = 0;
            var targetDigits = new int[k + 1];
            int i = k;
            
            while(target > 0){
                targetDigits[i] = target % 10;
                target /= 10;
                i--;
            }
            
            for(int pow = k; pow > 0; pow--)
                possibleSets += (int)Math.Pow(n,pow);
            
            //consider possible target.Length combos -- start with number of digits less than significant target digit
            int significantDigitCount = 0;
            bool hasSignificantDigit = false;
            foreach(string digit in digits){
                if(int.Parse(digit) < targetDigits[0])
                    significantDigitCount++;
                else if(int.Parse(digit) == targetDigits[0]){
                    hasSignificantDigit = true;
                    
                    if(k == 0){
                        significantDigitCount = 0;
                        break;
                    }
                }
            }
            
            possibleSets += significantDigitCount * (int)Math.Pow(n,k);
            
            //possible combos including significant digit
            if(hasSignificantDigit){
                int start = k > 0 ? 1 : 0;
                var hasEqualDigit = new bool[targetDigits.Length];
                
                for(i = start; i < targetDigits.Length; i++){
                    int original = targetDigits[i];

                    targetDigits[i] = 0;
                    foreach(string digit in digits){
                        
                        if(int.Parse(digit) <= original){
                            targetDigits[i]++;
                        } 
                        
                        if(int.Parse(digit) == original){
                            hasEqualDigit[i] = true;
                        } 
                    }
                }
                
                if(start == 1 && targetDigits[start] > 1){
                    for(i = start; i < targetDigits.Length - 1; i++){
                        if(targetDigits[i] > 1){
                            int offset = hasEqualDigit[i] ? 1 : 0;
                            int pow = targetDigits.Length - (1 + i);
                            
                            possibleSets += (targetDigits[i] - offset) * (int)Math.Pow(n,pow);
                            targetDigits[i] = 1;
                        }
                    }
                }
                
                bool doAdd = true;

                if(targetDigits.Length > 1){
                    for(int l = 1; l <= targetDigits.Length - 2; l++) {
                        if(targetDigits[l] <= 0){
                            doAdd = false;
                            break;
                        }
                    }
                }

                if(doAdd){
                    possibleSets += targetDigits[targetDigits.Length - 1];
                }
            }
            
            return possibleSets;
        }
    }
}