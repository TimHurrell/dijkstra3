﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordLadderLibrary;
using InputwordClass;
using WordlistClass;
using WriteLaddersToFile;

namespace ConsoleApplication
{
    class Console
    {
        public Listofwordsfromwordfile CreateWordListFromInputWordFile(string Filepath)
        {
            List<string> _listofwordsfromwordfile;
            _listofwordsfromwordfile = File.ReadAllLines(Filepath).ToList();
            return new Listofwordsfromwordfile(_listofwordsfromwordfile);
        }

        static void Main()
        {
            Console console = new Console();

            System.Console.Write("Enter start word : \n");
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Seedword = System.Console.ReadLine()
            };
            System.Console.Write("Enter finish word :\n ");
            InputWordsForWordLaddersinstance.Finishword = System.Console.ReadLine();
            System.Console.WriteLine(InputWordsForWordLaddersinstance.Seedword);
            System.Console.WriteLine(InputWordsForWordLaddersinstance.Finishword);

            WordsValidator wordsvalidatorinstance = new WordsValidator();
            wordsvalidatorinstance.AreWordsDifferentLength(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword);
            wordsvalidatorinstance.AreWordsDifferent(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword);


            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();
            string filePath = Path.Combine(AppContext.BaseDirectory, filename);
            Listofwordsfromwordfile wordlistinstance = console.CreateWordListFromInputWordFile(filePath);

            wordsvalidatorinstance.FinishWordExistsInList(wordlistinstance, InputWordsForWordLaddersinstance.Finishword);


            wordlistinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);
            WordLadderSolution WordLadderInstance = new WordLadderSolution();
            IList<IList<string>> ladders = WordLadderInstance.FindLadders(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword, wordlistinstance._listofwordsfromwordfile);
            WriteLadders writeLadders = new WriteLadders();


            writeLadders.WriteToFile(ladders);
        }
    }


}
