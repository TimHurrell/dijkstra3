
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WordLadderLibrary;

namespace ConsoleApplication
{
    class Console
    {
        public void Process()
        {
            InputWord inputwordinstance = new InputWord
            {
                Seedword = null
            };
            inputwordinstance = Intro();

            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();

            List<string> _wordList;
            string path = AppContext.BaseDirectory;

            string Filepath = path + @"\" + filename;
            _wordList = File.ReadAllLines(Filepath).ToList();

            WordList wordlistinstance = new WordList(_wordList);
            wordlistinstance.FinishwordExistsInList(inputwordinstance.Finishword);

            if (wordlistinstance.ExistsInList == false)
            {
                System.Console.WriteLine("Sorry, the finish word has to be in your dictionary file");
                return;
            }


            wordlistinstance.RemoveIncorrectLength(inputwordinstance.Seedword);


            WordLadderSolution WordLadderInstance = new WordLadderSolution();

            IList<IList<string>> ladders = WordLadderInstance.FindLadders(inputwordinstance.Seedword, inputwordinstance.Finishword, wordlistinstance._wordList);


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


        // private void Intro()
        public InputWord Intro()
        {
            System.Console.Write("Enter start word : \n");
            InputWord inputwordinstance = new InputWord
            {
                Seedword = System.Console.ReadLine()
            };
            System.Console.Write("Enter finish word :\n ");
            inputwordinstance.Finishword = System.Console.ReadLine();
            System.Console.WriteLine(inputwordinstance.Seedword);
            System.Console.WriteLine(inputwordinstance.Finishword);


            if (inputwordinstance.AreWordsDifferentLength(inputwordinstance.Seedword, inputwordinstance.Finishword))
            {
                System.Console.WriteLine("Sorry, words need to be the same length");
                return inputwordinstance;
            } 

            if (inputwordinstance.AreWordsDifferent(inputwordinstance.Seedword, inputwordinstance.Finishword) == false)
            {
                System.Console.WriteLine("Sorry, words need to be different");
                return inputwordinstance;
            }

            return inputwordinstance;




        }


        //public static void Main(String[] args)
        static void Main()
        {
            Console console = new Console();
            console.Process();

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



        public List<string> RemoveIncorrectLength(string inputwordinstance)
        {
            List<string> amendedwordlist = new List<string> { };
            foreach (var word in _wordList)
            {
                if (word.Length == inputwordinstance.Length)
                {
                    amendedwordlist.Add(word);
                }
            }
            _wordList = amendedwordlist;
            return _wordList;
        }


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