
using System.Collections.Generic;
using WordLadderLibrary;

namespace ConsoleApplication
{
    class Console
    { 
        static void Main()
        {
            // Entering the words
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();

            // Validating the words
            WordsValidator wordsvalidatorinstance = new WordsValidator();
            wordsvalidatorinstance.AreWordsDifferentLength(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword);
            wordsvalidatorinstance.AreWordsDifferent(InputWordsForWordLaddersinstance.Seedword, InputWordsForWordLaddersinstance.Finishword);

            // creating list of words from the word text file
            //an example of how to use a static method on a static class
            string wordFilePath = WordFilePath.GetWordFilePath();

            CreateWordListFromFile createwordlistfromfileinstance = new CreateWordListFromFile();
            Listofwordsfromwordfile wordlistinstance = createwordlistfromfileinstance.GetWordList(wordFilePath);

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
