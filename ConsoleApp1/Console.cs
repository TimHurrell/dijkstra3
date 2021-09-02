using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Console
    {

        //static void Main(string[] args)
        static void Main()
        {
            ////WordList wordlist = new WordList();
            System.Console.Write("Enter start word : \n");
            InputWord inputword = new InputWord
            {
                Seedword = System.Console.ReadLine()
            };
            System.Console.Write("Enter finish word :\n ");
            inputword.Finishword = System.Console.ReadLine();
            System.Console.WriteLine(inputword.Seedword);
            System.Console.WriteLine(inputword.Finishword);


            if (inputword.AreWordsDifferentLength(inputword.Seedword, inputword.Finishword))
            {
                System.Console.WriteLine("Sorry, words need to be the same length");
                return;
            }


            if (inputword.AreWordsDifferent(inputword.Seedword, inputword.Finishword) == false)
            {
                System.Console.WriteLine("Sorry, words need to be different");
                return;
            }

            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();



            List<string> _wordList;
            string path = AppContext.BaseDirectory;
            // string Filepath = path + @"\words-english.txt";

            string Filepath = path + @"\" + filename;
            _wordList = File.ReadAllLines(Filepath).ToList();

            WordList wordlist = new WordList(_wordList);
            wordlist.FinishwordExistsInList(inputword.Finishword);

            if (wordlist.ExistsInList == false)
            {
                System.Console.WriteLine("Sorry, the finish word has to be in your dictionary file");
                return;
            }

            wordlist.RemoveIncorrectLength(inputword.Seedword);


            Solution sol1 = new Solution();

            IList<IList<string>> ladders = sol1.FindLadders(inputword.Seedword, inputword.Finishword, wordlist._wordList);


            string strFilePath = path + @"\Data.csv";
            string strSeperator = ",";
            StringBuilder sbOutput = new StringBuilder();

            int i = 0;
            foreach (var item in ladders)
            {
                i++;
                sbOutput.AppendLine(string.Join(strSeperator, ""));
                sbOutput.Append(string.Join(strSeperator, "Ladder" + i));
                foreach (var item1 in item)
                {
                    sbOutput.Append(string.Join(strSeperator, ","));
                    sbOutput.Append(string.Join(strSeperator, item1));
                }
            }

            File.WriteAllText(strFilePath, sbOutput.ToString());




        }
    }



    public class InputWord
        {
            public string Seedword { get; set; }
            public string Finishword { get; set; }


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