// You are driving a vehicle that has capacity empty seats initially available for passengers.  The vehicle only drives east (ie. it cannot turn around and drive west.)
// Given a list of trips, trip[i] = [num_passengers, start_location, end_location] contains information about the i-th trip: the number of passengers that must be picked up, and the locations to pick them up and drop them off.  
// The locations are given as the number of kilometers due east from your vehicle's initial location.
// Return true if and only if it is possible to pick up and drop off all passengers for all the given trips. 

using System;
using System.Collections.Generic;

namespace algorithms
{
    public class CarPooling
    {
        //O(n) solution: store start/stop passenger values in 2 arrays of size 1001 (max km distance) and then loop while i < 1001
        // store a total of += pickup[i] -= dropoff[i], if total > capacity return false -- this also naturally orders things by km position
        //since i is the starting point moving east
        public static bool isPossible(int[][] trips, int capacity) {
            bool isPossible = true;
            int[] stops = new int[1001];

            foreach(int[] trip in trips){
                stops[trip[1]] += trip[0];
                stops[trip[2]] -= trip[0];
            }

            for(int i = 0; i < stops.Length; i++){
                if(i > 0) {
                    if(stops[i - 1] + stops[i] > capacity) {
                        isPossible = false;
                        break;
                    } else {
                        stops[i] = stops[i - 1] + stops[i];
                    }
                } else if(stops[i] > capacity) {
                    isPossible = false;
                    break;
                }
            }

            return isPossible;
        }

        //O(nlog(n)) sort then walk
        // public static bool isPossible(int[][] trips, int capacity) {
        //     Dictionary<int, int> passengersByEndpoint = new Dictionary<int, int>();
        //     bool isPossible = true;

        //     sort(trips, 0, trips.Length - 1);

        //     print(trips);
        //     int stop = 0;
        //     int currentStop = 1;
        //     int finalStop = trips[trips.Length - 1][2];

        //     while(currentStop <= finalStop){
        //         if(passengersByEndpoint.ContainsKey(currentStop)){
        //             capacity += passengersByEndpoint[currentStop];
        //             passengersByEndpoint[currentStop] = 0;
        //         }

        //         while(stop < trips.Length && trips[stop][1] == currentStop) {
        //             int passengers = trips[stop][0];
        //             int pickUpKey = trips[stop][2];

        //             if(passengersByEndpoint.ContainsKey(pickUpKey))
        //                 passengersByEndpoint[pickUpKey] += passengers;
        //             else
        //                 passengersByEndpoint[pickUpKey] = passengers;

        //             capacity -= passengers;

        //             stop++;
        //         }

        //         if(capacity < 0) {
        //             isPossible = false;
        //             break;
        //         }

        //         currentStop++;
        //     }

        //     return isPossible;
        // }

        // private static void sort(int[][] trips, int left, int right) {
        //     int idx = partition(trips, left, right);

        //     if(left < idx - 1)
        //         sort(trips, left, idx - 1);
        //     if(right > idx)
        //         sort(trips, idx, right);
        // }

        // private static int partition(int[][] trips, int left, int right) {
        //     int pivot = trips[(left + right) / 2][1];

        //     while(left <= right){
        //         while(trips[left][1] < pivot) left++;
        //         while(trips[right][1] > pivot) right--;

        //         if(left <= right) {
        //             swap(trips, left, right);
        //             left++;
        //             right--;
        //         }
        //     }

        //     return left;
        // }

        // private static void swap(int[][] trips, int left, int right){
        //     int[] temp = trips[left];
        //     trips[left] = trips[right];
        //     trips[right] = temp;
        // }

        // private static void print(int[][] trips) {
        //     foreach(int[] i in trips){
        //         foreach(int j in i)
        //             Console.Write(" " + j);
        //         Console.WriteLine();
        //     }
        // }
    }
}