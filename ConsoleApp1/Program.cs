using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WordList sol1 = new WordList();
            Console.Write("Enter start word : \n");
            sol1.Inputword = Console.ReadLine();
            Console.Write("Enter finish word :\n ");
            sol1.Endword = Console.ReadLine();


            // List<String> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };




            sol1.Inputword = sol1.MakeWordLowerCase(sol1.Inputword);
            sol1.Endword = sol1.MakeWordLowerCase(sol1.Endword);

            Console.WriteLine(sol1.Inputword);
            Console.WriteLine(sol1.Endword);




            //foreach (var item in sol1.wordList)
            //   {
            //       Console.Write("New ladder \n");
            //       Console.WriteLine(item.ToString());
            //   }



            //numInput1 = Console.ReadLine();
            //    Solution sol1 = new Solution();

            //    foreach (var item in sol1.FindLadders(beginWord, endWord, wordList))
            //    {
            //        Console.Write("New ladder \n");
            //        foreach (var item1 in item)
            //        {
            //            Console.WriteLine(item1.ToString());
            //        }
            //    }
        }
    }


    public interface IFileRead
    {
        public List<string> FileRead(string Filepath);
    }



    public class WordList : IFileRead
    {
        public List<string> wordList { get; set; }
        public string Inputword { get; set; }
        public string Endword { get; set; }
        public bool ExistsInList { get; set; }

        public List<string> FileRead(string Filepath)
        {
            string path = "";
            path = System.AppContext.BaseDirectory;
            //string Filepath = path + @"\words-english.txt";
            //List<string> wordList = File.ReadAllLines(Filepath).ToList();
            wordList = File.ReadAllLines(Filepath).ToList();
            return wordList;
            //Inputword = "Harry";
            //Endword = "Roger";
            // ExistsInList = false;
        }



        //public class WordList
        //{
        //    public List<string> _wordList { get; set; }

        //    //inject the dependency
        //    //this type of dependency injection is known as constructor injection
        //    public WordList(List<string> wordList)
        //    {
        //        _wordList = wordList;
        //    }
        //}

        public List<string> RemoveIncorrectLength()
        {
            List<string> wordList2 = new List<string> { };
            foreach (var word in wordList)
            {
                if (word.Length == Inputword.Length)
                {
                    wordList2.Add(word);
                }
            }
            wordList = wordList2;
            return wordList;
        }



        public bool AreWordsDifferentLength(string inputWord, string endWord)
        {
            return inputWord.Length != endWord.Length;
        }


        public bool AreWordsDifferent(string inputWord, string endWord)
        {
            return inputWord != endWord;
        }


        public string MakeWordLowerCase(string word)
        {
            int length = word.Length;
            string finalletters = word[1..length];
            string firstletter = Inputword[0].ToString();
            finalletters = finalletters.ToLower();
            word = firstletter + finalletters;
            return word;
        }

        public void EndwordExistsInList()
        {
            foreach (var word in wordList)
            {
                if (Endword == word)
                {
                    ExistsInList = true;
                }
            }
        }


    }

    public class FileOpeningEvent
    {
        IFileRead filereader;

        public FileOpeningEvent(IFileRead filereader)
        {
            this.filereader = filereader;
        }

    }
}