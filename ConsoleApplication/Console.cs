﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WordLadderLibrary;
using InputwordClass;
using WordlistClass;

namespace ConsoleApplication
{
    class Console
    {
        public void Process()
        {
            InputWordsForWordLadders InputWordsForWordLaddersinstance = Intro();

            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();
            string filePath = Path.Combine(AppContext.BaseDirectory, filename);
            Listofwordsfromwordfile wordlistinstance = CreateWordListFromInputWordFile(filePath);
            FinishWordExistsInList(wordlistinstance, InputWordsForWordLaddersinstance.Finishword);


            wordlistinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);
            WordLadderSolution WordLadderInstance = new WordLadderSolution();
            IList<IList<string>> ladders = WordLadderInstance.FindLadders(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword, wordlistinstance._listofwordsfromwordfile);
            WriteLaddersToCsvFile(ladders);
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
            System.Console.WriteLine(InputWordsForWordLaddersinstance.Seedword);
            System.Console.WriteLine(InputWordsForWordLaddersinstance.Finishword);
            if (InputWordsForWordLaddersinstance.AreWordsDifferentLength(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword))
            {
                System.Console.WriteLine("Sorry, words need to be the same length");
                return InputWordsForWordLaddersinstance;
            }
            if (InputWordsForWordLaddersinstance.AreWordsDifferent(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword) == false)
            {
                System.Console.WriteLine("Sorry, words need to be different");
                return InputWordsForWordLaddersinstance;
            }
            return InputWordsForWordLaddersinstance;
        }

        public void FinishWordExistsInList(Listofwordsfromwordfile wordlist, string finishword)
        {
            if (!wordlist.WordExistsInListFromWordFile(finishword))
            {
                System.Console.WriteLine("Sorry, the finish word has to be in your dictionary file");
            }
        }

        public Listofwordsfromwordfile CreateWordListFromInputWordFile(string Filepath)
        {
            List<string> _listofwordsfromwordfile;
            _listofwordsfromwordfile = File.ReadAllLines(Filepath).ToList();
            return new Listofwordsfromwordfile(_listofwordsfromwordfile);
        }

        //TODO we can write a test for this, but we need to split the method up so that it returns a string
        //we're not interested in testing that we can write a file but more interested in what the contents of the file is.
        public void WriteLaddersToCsvFile(IList<IList<string>> ladders)
        {
            string strFilePath = Path.Combine(AppContext.BaseDirectory, "Data.csv");
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

            File.WriteAllText(strFilePath, StringOfWordLadders.ToString());
        }
        static void Main()
        {
            Console console = new Console();
            console.Process();
        }
    }


}
