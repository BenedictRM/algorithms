// You are given equations in the format A / B = k, where A and B are variables represented as strings, and k is a real number (floating-point number). 
// Given some queries, return the answers. If the answer does not exist, return -1.0.

// The input is always valid. You may assume that evaluating the queries will result in no division by zero and there is no contradiction.

// Example 1:

// Input: equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
// Output: [6.00000,0.50000,-1.00000,1.00000,-1.00000]
// Explanation: 
// Given: a / b = 2.0, b / c = 3.0
// queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ?
// return: [6.0, 0.5, -1.0, 1.0, -1.0 ]
using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    //Turns out this is a graph problem -- revisit later
    public class EvaluateDivision
    {
        private static Dictionary<string, Dictionary<string, string>> variableToConversions;
        public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
            variableToConversions = new Dictionary<string, Dictionary<string, string>>();
            double[] answers = new double[queries.Count];

            setVariableToConversions(equations, values);

            int i = 0;
            foreach(List<string> query in queries){
                answers[i] = calculate(query);
                i++;
            }
            
            printVariableToConverstions();

            return answers;
        }

        private static void setVariableToConversions(IList<IList<string>> equations, double[] values) {
            int i = 0;

            foreach(IList<string> equation in equations){
                if(variableToConversions.ContainsKey(equation[0])){
                    Dictionary<string, string> conversions = variableToConversions[equation[0]];
                    conversions.Add(equation[1], values[i] + equation[1]);
                } else {
                    variableToConversions.Add(equation[0], new Dictionary<string, string>(){{equation[1], values[i] + equation[1]}});
                }

                if(variableToConversions.ContainsKey(equation[1])) {
                    Dictionary<string, string> conversions = variableToConversions[equation[1]];
                    conversions.Add(equation[0], equation[0] + "/" + values[i]);
                } else {
                    variableToConversions.Add(equation[1], new Dictionary<string, string>(){{equation[0], equation[0] + "/" + values[i]}});
                }

                i++;
            }
        }

        private static double calculate(List<string> query){
            double answer = -1.0;

            //Get denom in terms of numerator
            string normalizedConversion = normalizeTerms(query[1], query[0]);
            
            if(normalizedConversion == string.Empty) {
                //Get numerator in terms of denominator
                normalizedConversion = normalizeTerms(query[0], query[1]);
                if(normalizedConversion != string.Empty){
                    Dictionary<string, string> conversions = variableToConversions[query[0]];

                    if(!conversions.ContainsKey(query[1]))
                        conversions.Add(query[1], normalizedConversion);
                }
            } else {
                Dictionary<string, string> conversions = variableToConversions[query[1]];

                if(!conversions.ContainsKey(query[0]))
                    conversions.Add(query[0], normalizedConversion);
            }

            Console.WriteLine("Converted: {0}", normalizedConversion);

            if(normalizedConversion != string.Empty && normalizedConversion != "1.0") {
                int levels = 0;
                //convert into double
                if(char.IsLetter(normalizedConversion[0])){
                    //denominator was converted
                    for(int i = 0; i < normalizedConversion.Length; i++){
                        if(char.IsDigit(normalizedConversion[i])){
                            string number = string.Empty;
                            levels++;

                            while(i < normalizedConversion.Length && char.IsDigit(normalizedConversion[i])){
                                number += normalizedConversion[i];
                                i++;
                            }

                            if(answer == -1){
                                answer = Convert.ToDouble("" + number);
                            } else {
                                //undo frac
                                answer *= Convert.ToDouble("" + number);
                            }
                        }
                    }
                } else {
                    // Console.WriteLine("Numerator Converted");
                    for(int i = 0; i < normalizedConversion.Length; i++){
                        if(char.IsDigit(normalizedConversion[i])){
                            string number = string.Empty;

                            while(i < normalizedConversion.Length && char.IsDigit(normalizedConversion[i])){
                                number += normalizedConversion[i];
                                i++;
                            }

                            answer = 1.0 / (Convert.ToDouble("" + number));

                            //depending on how many levels there are affects if mult or div
                            // if(answer == -1){
                            //     answer = 1 / Convert.ToDouble("" + number);
                            // } else {
                            //     answer *= Convert.ToDouble("" + number);
                            // }
                        }
                    }
                }

                if(levels == 1)
                    answer = 1 / answer;
            } else if(normalizedConversion == "1.0") {
                answer = 1.0;
            }
            // Console.WriteLine("Answer {0}", answer);
            return answer;
        }

        private static string normalizeTerms(string from, string to) {
            string normalize = string.Empty;

            if(variableToConversions.ContainsKey(from)){
                Dictionary<string, string> conversions = variableToConversions[from];
                if(from == to){
                    normalize = "1.0";
                }
                else if(conversions.ContainsKey(to)){
                    normalize = conversions[to];
                    normalize = to + '/' + normalize;
                } else {
                    foreach(string key in conversions.Keys){
                        if(variableToConversions.ContainsKey(key)){
                            Dictionary<string, string> intermediateConversion = variableToConversions[key];
                            if(intermediateConversion.ContainsKey(to)){
                                string intermediateConvervsion = intermediateConversion[to];
                                string conversionToIntermediate = conversions[key];
                                Console.WriteLine("Intermediate {0} to conversion {1}", intermediateConvervsion, conversionToIntermediate);
                                if(conversionToIntermediate[0] != to[0]){
                                    normalize = intermediateConvervsion + conversionToIntermediate.Replace(key[0], '\0');
                                } else {
                                    // Console.WriteLine("Here");
                                    normalize = conversionToIntermediate + intermediateConvervsion.Replace(key[0], '\0');
                                }

                                break;
                            }
                        }
                    }
                }
            }

            return normalize;
        }

        private static void printVariableToConverstions() {
            StringBuilder sb = new StringBuilder();

            foreach(string key in variableToConversions.Keys){
                Dictionary<string, string> conversions = variableToConversions[key];
                foreach(string key2 in conversions.Keys) {
                    string conversion = conversions[key2];

                    sb.Append(key + " to " + key2 + ": " + conversion + "\n");
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}