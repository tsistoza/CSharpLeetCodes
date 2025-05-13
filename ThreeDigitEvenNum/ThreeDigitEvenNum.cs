// LeetCode 2094
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] digits = { 3, 7, 5 };
}

namespace Solution
{
    public class Program
    {
        private IEnumerable<int> findDigits(int x)
        {
            while (x >= 10)
            {
                int digit = x % 10;
                x /= 10;
                yield return digit;
            }

            yield return (x % 10);
        }
        public List<int> FindEvenNumbers(int[] digits)
        {
            List<int> result = new List<int>();
            Dictionary<int,int> map = new Dictionary<int,int>();
            foreach (int i in digits)
                if (!map.TryAdd(i, 1))
                    map[i]++;
            

            for (int i=100; i<1000;)
            {
                if (i % 2 == 1)
                {
                    i++;
                    continue;
                }
                Dictionary<int, int> tempMap = new Dictionary<int, int>(map);
                List<int> bucket = new List<int>(findDigits(i));
                bucket.Reverse();
                int index = 0;
                for (; index<bucket.Count; index++)
                {
                    if (tempMap.ContainsKey(bucket[index]))
                        tempMap[bucket[index]]--;
                    else break;
                    if (tempMap[bucket[index]] <= 0) tempMap.Remove(bucket[index]);
                }

                if (index == 0)
                    i = (bucket[0] + 1) * 100;
                if (index == 1)
                    i = ((bucket[0]) * 100) + ((bucket[1]+1) * 10);
                if (index == 2)
                    i++;
                if (index == bucket.Count)
                {
                    result.Add(i);
                    i++;
                }
            }
            return result;
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach (int i in obj.FindEvenNumbers(Globals.digits))
                Console.WriteLine(i);
            return;
        }
    }
}