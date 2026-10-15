using System;
using System.Collections.Generic;
namespace _3723;

public static class Globals
{
    public static int num = 1;
    public static int sum = 10;
}

public class Program
{
    public string MaxSumOfSquares(int num, int sum)
    {
        int maxSum = num * 9;
        if (maxSum < sum) return String.Empty;

        char[] result = new char[num];
        int lastIndex = 0;
        
        if (sum > 9)
        {
            int remainder = sum % 9;
            sum -= remainder;
            sum /= 9;
            lastIndex = sum;
            Span<char> cStart = result.AsSpan(0, sum);
            cStart.Fill('9');
            sum = remainder;
        }

        if (sum > 0)
        {
            result[lastIndex] = (char)(48 + sum);
            lastIndex++;
        }

        if (lastIndex < num)
        {
            Span<char> cEnd = result.AsSpan(lastIndex, num - lastIndex);
            cEnd.Fill('0');
        }
        

        /*for (int i=0; i<num; i++)
        {
            if (sum > 9)
            {
                sum -= 9;
                result += '9';
            }
            else
            {
                result += (char) (48 + sum);
                sum -= sum;
                break;
            }
        }*/



        return new string(result);
    }
}
