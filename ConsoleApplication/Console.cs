
using System.Collections.Generic;
using WordLadderLibrary;

namespace ConsoleApplication
{
    class Console
    { 
        static void Main()
        {
            Console console = new Console();

            // Entering the words
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();

            // Validating the words
            WordsValidator wordsvalidatorinstance = new WordsValidator();
            wordsvalidatorinstance.AreWordsDifferentLength(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword);
            wordsvalidatorinstance.AreWordsDifferent(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword);

            // creating list of words from the word text file
            WordFilePath wordsfilepathinstance = new WordFilePath();
            CreateWordListFromFile createwordlistfromfileinstance = new CreateWordListFromFile();
            Listofwordsfromwordfile wordlistinstance = createwordlistfromfileinstance.GetWordList(wordsfilepathinstance.GetWordFilePath());

            // checking end word is in the word text file file
            wordsvalidatorinstance.FinishWordExistsInList(wordlistinstance, InputWordsForWordLaddersinstance.Finishword);

            // remove any words from the word list not the same length as the input words
            wordlistinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);

            WordLadderSolution WordLadderInstance = new WordLadderSolution();
            IList<IList<string>> ladders = WordLadderInstance.FindLadders(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword, wordlistinstance._listofwordsfromwordfile);
            WriteLadders writeLadders = new WriteLadders();
            writeLadders.WriteToFile(ladders);
        }
    }


}
