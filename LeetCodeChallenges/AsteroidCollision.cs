using System;
using System.Collections.Generic;

namespace algorithms
{
    public class AsteroidCollision
    {
        public int[] Solution(int[] asteroids) {
            Stack<int> survivors = new Stack<int>();
            int cur = asteroids[asteroids.Length - 1];

            for(int i = asteroids.Length - 2; i >= 0; i--){
                int asteroid = asteroids[i];

                if(cur == 0) {
                    if(survivors.Count > 0)
                        cur = survivors.Pop();
                    else {
                        cur = asteroid;
                        continue;
                    }
                }

                if(cur > 0 || (cur < 0 && asteroid < 0)) {
                    survivors.Push(cur);
                    cur = asteroid;
                } else if(asteroid > 0){
                    if(Math.Abs(cur) > Math.Abs(asteroid))
                        continue;
                    else{
                        if(cur != 0)
                            survivors.Push(cur);

                        cur = asteroid;
                        while(survivors.Count > 0){
                            if(Math.Abs(cur) > Math.Abs(survivors.Peek()) && survivors.Peek() < 0){
                                survivors.Pop();
                            } else if(Math.Abs(cur) == Math.Abs(survivors.Peek()) && survivors.Peek() < 0){
                                survivors.Pop();
                                cur = 0;
                                break;
                            } else if(Math.Abs(cur) < Math.Abs(survivors.Peek()) && survivors.Peek() < 0){
                                cur = 0;
                                break;
                            } else {
                                break;
                            }
                        }
                    }
                } 
            }

            if(cur != 0)
                survivors.Push(cur);            

            return survivors.ToArray();
        }
    }
}