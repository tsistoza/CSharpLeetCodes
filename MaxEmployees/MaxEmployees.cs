// LeetCode 2127
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

public static class Globals
{
    public static List<int> favorite = new List<int>() { 2, 2, 1, 2 };
    public static List<int> favorite1 = new List<int>() { 1, 2, 0 };
    public static List<int> favorite2 = new List<int>() { 3, 0, 1, 4, 1 };
}

namespace Solution
{
    public class Program
    {
        public int MaximumInvitations(List<int> favorite)
        {
            int max = -1;
            Dictionary<int,List<int>> neighbors = new Dictionary<int,List<int>>();
            for (int i=0; i<favorite.Count; i++)
            {
                if (neighbors.ContainsKey(favorite[i])) neighbors[favorite[i]].Add(i);
                else neighbors.Add(favorite[i], new List<int>() { i });
            }


            // Think of it like a linked list
            for (int i=0; i<favorite.Count; i++)
            {
                List<int> temp = new List<int>();
                int seat = i;
                
                while (!temp.Contains(seat))
                {
                    temp.Add(seat); // Add current seat
                    seat = favorite[seat]; // Next seat is the current seat favorite
                    if (!temp.Contains(seat))
                        continue;


                    // If the meeting already contains the favorite person

                    // Check if back is sitting next to favorite
                    if (favorite[temp.Last()] == temp[0]) break;
                    if (favorite[temp.Last()] != temp[temp.Count - 2])
                    {
                        temp.RemoveAt(temp.Count - 1);
                        break;
                    }

                    if (!neighbors.ContainsKey(seat)) break;
                    
                    int tempSeat = -1;
                    foreach (int index in neighbors[seat]) // Find another person that you want to add to end of list
                    {
                        if (temp.Contains(index)) continue;
                        tempSeat = index;
                        break;
                    }


                    if (tempSeat != -1)
                    {
                        seat = tempSeat;
                        continue;
                    }
                    if (!neighbors.ContainsKey(temp[0])) break;

                    // If none want to sit next to end of list
                    foreach(int index in neighbors[temp[0]]) // Find one that wants to sit near front of list
                    {
                        if (temp.Contains(index)) continue;
                        tempSeat = index;
                        break;
                    }

                    if (tempSeat != -1)
                    {
                        seat = tempSeat;
                        continue;
                    }

                    
                }
                max = (max < temp.Count) ? temp.Count : max;

                foreach (int j in temp)
                    Console.Write($"{j} ");
                Console.WriteLine();
            }
            return max;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaximumInvitations(Globals.favorite));
            Console.WriteLine(obj.MaximumInvitations(Globals.favorite1));
            Console.WriteLine(obj.MaximumInvitations(Globals.favorite2));
            return;
        }
    }
}