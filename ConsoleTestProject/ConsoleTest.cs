using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleApplication;

namespace ConsoleTestProject
{
    public class TestRecordsFile
    {
        List<string> _wordList;

        public TestRecordsFile()
        {
            string path = AppContext.BaseDirectory;
            string Filepath = path + @"\words-english.txt";
            _wordList = File.ReadAllLines(Filepath).ToList();
        }


        [Fact]
        public void CheckWordListConstructor()
        {
            WordList wordlist = new WordList(_wordList);
            Assert.Equal("AAA", wordlist._wordList[12]);
        }


        [Fact]
        public void CheckListOnlyContains3LetterWordsTestLimitedSelectionTrue()
        {
            WordList wordlist = new WordList();
            InputWord inputword = new InputWord();
            wordlist._wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
            inputword.Seedword = "Ben";
            wordlist.RemoveIncorrectLength(inputword.Seedword);


            Boolean testresult = true;
            foreach (var word in wordlist._wordList)
            {
                if (word.Length != 3)
                {
                    testresult = false;
                }
            }

            Assert.True(testresult);



        }


        [Fact]
        public void CheckListOnlyContains3LetterWordsTestLimitedSelectionFalse()
        {
            WordList wordlist = new WordList
            {
                _wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" }
            };
            InputWord inputword = new InputWord
            {
                Seedword = "Ben"
            };
            Boolean testresult = true;
            foreach (var word in wordlist._wordList)
            {
                if (word.Length != 3)
                {
                    testresult = false;
                }
            }

            Assert.False(testresult);



        }

        [Fact]
        public void CheckListOnlyContains3LetterWordsTestFullSelectionTrue()
        {
            WordList wordlist = new WordList(_wordList);
            InputWord inputword = new InputWord
            {
                Seedword = "Ben"
            };
            wordlist.RemoveIncorrectLength(inputword.Seedword);


            Boolean testresult = true;
            foreach (var word in wordlist._wordList)
            {
                if (word.Length != 3)
                {
                    testresult = false;
                }
            }

            Assert.True(testresult);



        }


        [Fact]
        public void CheckListOnlyContains3LetterWordsTestFullSelectionFalse()
        {
            WordList wordlist = new WordList(_wordList);


            Boolean testresult = true;
            foreach (var word in wordlist._wordList)
            {
                if (word.Length != 5)
                {
                    testresult = false;
                }
            }

            Assert.False(testresult);



        }

        [Fact]
        public void CheckListOnlyContainsWordsTestWhichMatchTheConstructorWordLength()
        {
            WordList wordlist = new WordList(_wordList);
            InputWord inputword = new InputWord
            {
                Seedword = "Ben"
            };
            wordlist.RemoveIncorrectLength(inputword.Seedword);


            Boolean testresult = true;
            foreach (var word in wordlist._wordList)
            {
                if (word.Length != inputword.Seedword.Length)
                {
                    testresult = false;
                }
            }

            Assert.True(testresult);
        }

        [Fact]
        public void CheckInputAndEndWordsSameLengthTrue()
        {
            InputWord inputword = new InputWord();

            Assert.True(inputword.AreWordsDifferentLength("Good", "Bad"));
        }


        [Fact]
        public void CheckInputAndEndWordsSameLengthFalse()
        {
            InputWord inputword = new InputWord();

            Assert.False(inputword.AreWordsDifferentLength("Good", "Goad"));
        }

        [Fact]
        public void CheckInputAndEndWordsSame()
        {
            InputWord inputword = new InputWord();

            Assert.False(inputword.AreWordsDifferent("Good", "Good"));
        }

        [Fact]
        public void CheckInputAndEndWordsDifferent()
        {
            InputWord inputword = new InputWord();

            Assert.True(inputword.AreWordsDifferent("Good", "Goad"));
        }

      

        [Fact]
        public void CheckEndWordExistsInListTrue()
        {
            List<string> words = new List<string>() { "cog", "mat" };

            WordList wordlist = new WordList(words);
            InputWord inputword = new InputWord
            {
                Finishword = "cog"
            };
            wordlist.FinishwordExistsInList(inputword.Finishword);

            Assert.True(wordlist.ExistsInList);
        }


        [Fact]
        public void CheckEndWordExistsInListFalse()
        {
            List<string> words = new List<string>() { "cog", "mat" };

            WordList wordlist = new WordList(words);
            InputWord inputword = new InputWord
            {
                Finishword = "Cog"
            };
            wordlist.FinishwordExistsInList(inputword.Finishword);

            Assert.False(wordlist.ExistsInList);
        }
    }

   
}
