
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
            _ = new InputWordsForWordLadders
            {
                Seedword = null
            };
            InputWordsForWordLadders InputWordsForWordLaddersinstance = Intro();


            Listofwordsfilepath listofwordsfromwordfilefilepathinstance = new Listofwordsfilepath
            {
                listofwordsfilepath = null
            };

            Listofwordsfromwordfile listofwordsfromwordfileinstance = CreatelistofwordsfromwordfileFromInputWordsForWordLaddersFile(listofwordsfromwordfilefilepathinstance.Getlistofwordsfilepath());


            FinishWordExistsInList(listofwordsfromwordfileinstance, InputWordsForWordLaddersinstance.Finishword);


            listofwordsfromwordfileinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);


            WordLadderSolution WordLadderInstance = new WordLadderSolution();

            IList<IList<string>> listofstringsofwordladders = WordLadderInstance.FindLadders(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword, listofwordsfromwordfileinstance._listofwordsfromwordfile);

            WriteLaddersToCsvFile(listofstringsofwordladders);


        }

        public InputWordsForWordLadders Intro() 
        {
            System.Console.Write("Enter start word : \n");
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Seedword = System.Console.ReadLine()
            };
            System.Console.Write("Enter finish word :\n ");
            InputWordsForWordLaddersinstance.Finishword = System.Console.ReadLine();


            if (InputWordsForWordLaddersinstance.AreWordsDifferentLength(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword))
            {
                System.Console.WriteLine("Sorry, words need to be the same length");
                Environment.Exit(-1);
            } 

            if (InputWordsForWordLaddersinstance.AreWordsDifferent(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword) == false)
            {
                System.Console.WriteLine("Sorry, words need to be different");
                Environment.Exit(-1);
            }

            return InputWordsForWordLaddersinstance;

        }


        public void FinishWordExistsInList (Listofwordsfromwordfile listofwordsfromwordfile, string finishword)
        {

            listofwordsfromwordfile.FinishwordExistsInList(finishword);

            if (listofwordsfromwordfile.ExistsInList == false)
            {
                System.Console.WriteLine("Sorry, the finish word has to be in your dictionary file");
                Environment.Exit(-1);
            }

        }



        public Listofwordsfromwordfile CreatelistofwordsfromwordfileFromInputWordsForWordLaddersFile(string listofwordsfromwordfilefilepath)
        {

            List<string> _listofwordsfromwordfile;
            _listofwordsfromwordfile = File.ReadAllLines(listofwordsfromwordfilefilepath).ToList();

            Listofwordsfromwordfile listofwordsfromwordfile = new Listofwordsfromwordfile(_listofwordsfromwordfile);

            return listofwordsfromwordfile;

        }


        public void WriteLaddersToCsvFile(IList<IList<string>> ladders)
        {


            string outputladdersfilepath = AppContext.BaseDirectory + @"\Data.csv";
            string strSeperator = ",";
            StringBuilder StringOfWordLadders = new StringBuilder();

            int i = 0;
            foreach (var item in ladders)
            {
                i++;
                StringOfWordLadders.AppendLine(string.Join(strSeperator, ""));
                StringOfWordLadders.Append(string.Join(strSeperator, "Ladder" + i));
                foreach (var item1 in item)
                {
                    StringOfWordLadders.Append(string.Join(strSeperator, ","));
                    StringOfWordLadders.Append(string.Join(strSeperator, item1));
                }
            }

            File.WriteAllText(outputladdersfilepath, StringOfWordLadders.ToString());

        }


        static void Main()
        {
            Console console = new Console();
            console.Process();

        }
    }



    public class InputWordsForWordLadders
        {
            public string Seedword { get; set; }
            public string Finishword { get; set; }


        public bool AreWordsDifferentLength(string InputWordsForWordLadders, string endWord)
        {
            return InputWordsForWordLadders.Length != endWord.Length;
        }


        public bool AreWordsDifferent(string InputWordsForWordLadders, string endWord)
        {
            return InputWordsForWordLadders != endWord;
        }

    }
   


    public class Listofwordsfromwordfile
    {
        public List<string> _listofwordsfromwordfile { get; set; }

        //inject the dependency
        //this type of dependency injection is known as constructor injection
        public Listofwordsfromwordfile(List<string> listofwordsfromwordfile)
        {
            _listofwordsfromwordfile = listofwordsfromwordfile;
        }

        public Listofwordsfromwordfile()
        {

        }



        public bool ExistsInList { get; set; }



        public List<string> RemoveIncorrectLength(string InputWordsForWordLaddersinstance)
        {
            List<string> amendedlistofwordsfromwordfile = new List<string> { };
            foreach (var word in _listofwordsfromwordfile)
            {
                if (word.Length == InputWordsForWordLaddersinstance.Length)
                {
                    amendedlistofwordsfromwordfile.Add(word);
                }
            }
            _listofwordsfromwordfile = amendedlistofwordsfromwordfile;
            return _listofwordsfromwordfile;
        }


        public void FinishwordExistsInList(string endword)
        {
            foreach (var word in _listofwordsfromwordfile)
            {
                if (endword == word)
                {
                    ExistsInList = true;
                }
            }
        }




    }


    public class Listofwordsfilepath
    {
        public string listofwordsfilepath { get; set; }

        public string Getlistofwordsfilepath()
        {
            System.Console.Write("Enter file name :\n ");
            string listofwordsfromwordfilefilepath = AppContext.BaseDirectory + @"\" + System.Console.ReadLine();
            return listofwordsfromwordfilefilepath;
        }
    }




}