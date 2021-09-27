



namespace InputwordClass
{



    public class InputWord
    {
        public string Seedword { get; set; }
        public string Finishword { get; set; }


        // these methods are so similar its probably not worth testing them.
        public bool AreWordsDifferentLength(string inputWord, string endWord)
        {
            return inputWord.Length != endWord.Length;

        }

        public bool AreWordsDifferent(string inputWord, string endWord)
        {
            return inputWord != endWord;
        }

    }



}
