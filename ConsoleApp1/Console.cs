using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Console
    {
        static void Main(string[] args)
        {
            ////WordList wordlist = new WordList();
            System.Console.Write("Enter start word : \n");
            InputWord inputword = new InputWord();
            inputword.seedword = System.Console.ReadLine();
            System.Console.Write("Enter finish word :\n ");
            inputword.finishword = System.Console.ReadLine();




            System.Console.WriteLine(inputword.seedword);
            System.Console.WriteLine(inputword.finishword);
        }
    }



    public class InputWord
        {
            public string seedword { get; set; }
            public string finishword { get; set; }


        public bool AreWordsDifferentLength(string inputWord, string endWord)
        {
            return inputWord.Length != endWord.Length;
        }


        public bool AreWordsDifferent(string inputWord, string endWord)
        {
            return inputWord != endWord;
        }

    }
   





    public class WordList
    {
        public List<string> _wordList { get; set; }

        //inject the dependency
        //this type of dependency injection is known as constructor injection
        public WordList(List<string> wordList)
        {
            _wordList = wordList;
        }

        public WordList()
        {

        }




        public bool ExistsInList { get; set; }

        public List<string> FileRead(string Filepath)
        {
            string path = "";
            path = System.AppContext.BaseDirectory;
            //string Filepath = path + @"\words-english.txt";
            //List<string> wordList = File.ReadAllLines(Filepath).ToList();
            _wordList = File.ReadAllLines(Filepath).ToList();
            return _wordList;
            //Inputword = "Harry";
            //Endword = "Roger";
            // ExistsInList = false;
        }



        public List<string> RemoveIncorrectLength(string inputword)
        {
            List<string> wordList2 = new List<string> { };
            foreach (var word in _wordList)
            {
                if (word.Length == inputword.Length)
                {
                    wordList2.Add(word);
                }
            }
            _wordList = wordList2;
            return _wordList;
        }





        //public string MakeWordLowerCase(string word)
        //{
        //    int length = word.Length;
        //    string finalletters = word[1..length];
        //    string firstletter = Inputword[0].ToString();
        //    finalletters = finalletters.ToLower();
        //    word = firstletter + finalletters;
        //    return word;
        //}

        public void FinishwordExistsInList(string endword)
        {
            foreach (var word in _wordList)
            {
                if (endword == word)
                {
                    ExistsInList = true;
                }
            }
        }


    }

}