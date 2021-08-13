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
            Console.Write("Enter start word : \n");
            Console.Write("Enter finish word :\n ");
            Console.Write("Enter word list :\n ");
            List<String> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            string beginWord = "hit";
            string endWord = "cog";
            //numInput1 = Console.ReadLine();
            Solution sol1 = new Solution();

            foreach (var item in sol1.FindLadders(beginWord, endWord, wordList))
            {
                Console.Write("New ladder \n");
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.ToString());
                }
            }
        }
    }
}
