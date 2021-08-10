using ClassLibrary1;
using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string numInput1 = "";
            Console.Write("Enter start word : ");
            Console.Write("Enter finish word : ");
            Console.Write("Enter word list : ");
            List<String> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            string beginWord = "hit";
            string endWord = "cog";
            //numInput1 = Console.ReadLine();
            Solution sol1 = new Solution();
            Console.WriteLine("The outputs are {0}", sol1.FindLadders(beginWord, endWord, wordList));
        }
    }
}
