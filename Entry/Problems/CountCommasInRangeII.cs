// LeetCode 3871
using System;
using System.Collections.Generic;

namespace _3871
{
    public static class Globals
    {
        public static long n = 1000000000;
    }
    public class Program
    {
        public long CountCommas(long n)
        {
            if (n < 1000) return 0;
            long commaMultiplier = 1000000;

            HashSet<long> numCommas = new HashSet<long>() { commaMultiplier };
            
            long sum = 0;

            // [ commaMultiplier / 1000 | commaMultiplier | n ]
            // Since we know commaMultiplier is still < n, we just count the commas using math
            while (commaMultiplier < n)
            {
                sum += ((commaMultiplier - (commaMultiplier / 1000)) * (long)(Math.Log((double)commaMultiplier / 1000, 1000)));
                commaMultiplier *= 1000;
                numCommas.Add(commaMultiplier);
            }

            // Remainder [ commaMultiplier/1000 | n | commaMultiplier ]
            if (numCommas.Contains(n))
            {
                sum += (n - (commaMultiplier / 1000)) * (long)(Math.Log((double)(commaMultiplier / 1000), 1000));
                sum += (long)(Math.Log((double)(commaMultiplier), 1000));
            }
            else
            {
                sum += ((n - (commaMultiplier / 1000)) + 1) * (long)(Math.Log((double)(commaMultiplier / 1000), 1000));
            }
            return sum;
        }
    }
}
