using System;
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

        static void Main()
        {
            Console console = new Console();
            //InputWordsForWordLadders InputWordsForWordLaddersinstance = console.Intro();

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
                return;
            }
            if (InputWordsForWordLaddersinstance.AreWordsDifferent(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword) == false)
            {
                System.Console.WriteLine("Sorry, words need to be different");
                return;
            }


            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();
            string filePath = Path.Combine(AppContext.BaseDirectory, filename);
            Listofwordsfromwordfile wordlistinstance = console.CreateWordListFromInputWordFile(filePath);
            console.FinishWordExistsInList(wordlistinstance, InputWordsForWordLaddersinstance.Finishword);


            wordlistinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);
            WordLadderSolution WordLadderInstance = new WordLadderSolution();
            IList<IList<string>> ladders = WordLadderInstance.FindLadders(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword, wordlistinstance._listofwordsfromwordfile);
            WriteLadders writeLadders = new WriteLadders();


            writeLadders.WriteToFile(ladders);
        }
    }


}
