// See https://aka.ms/new-console-template for more information
using System;

public class Solution {
    // Functions
    public int MaximumNumberOfStringPairs(string[] words) {
        int numStringPairs = 0;
        for(int i=0; i<words.Length; i++) {
            for(int j=i+1; j<words.Length; j++) {
                if (Palindrome(words[i],words[j]) && words[i] != "\0" && words[j] != "\0") {
                    numStringPairs++;
                    words[i] = "\0";
                    words[j] = "\0";
                }
            }
        }
        return numStringPairs;
    }

    public bool Palindrome(string word1, string word2) {
        char[] charArray = word1.ToCharArray();
        int index = 0;
        foreach(char ch in word2.Reverse()) {
            if (charArray[index] != ch) return false;
            index++;
        }
        return true;
    }

    public static int Main() {
        string[] words = {"cd", "ac", "dc", "ca", "zz"};
        Solution solution = new Solution();
        Console.WriteLine(solution.MaximumNumberOfStringPairs(words));
        return 0;
    }
}