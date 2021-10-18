using WordlistClass;

namespace ConsoleApplication
{
    public class WordsValidator
    {
        public bool AreWordsDifferentLength(string inputWord, string endWord)
        {

            if (inputWord.Length != endWord.Length)
                {
                //       StandardMessages.DisplayValidationError("first name");
                System.Console.WriteLine("Sorry, words need to be the same length");
                        return false;
                }
            return true;
        }
        public bool AreWordsDifferent(string inputWord, string endWord)
        {
            if (inputWord == endWord)
            {
                System.Console.WriteLine("Sorry, words need to be different");
                return false;
            }
            return true;
        }
        public void FinishWordExistsInList(Listofwordsfromwordfile wordlist, string endWord)
        {
            if (!wordlist.WordExistsInListFromWordFile(endWord))
            {
                System.Console.WriteLine("Sorry, the finish word has to be in your dictionary file");
            }
        }
    }
}


