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
            WordList wordlistinstance = new WordList(_wordList);
            Assert.Equal("AAA", wordlistinstance._wordList[12]);
        }


        [Fact]
        public void CheckListOnlyContains3LetterWordsTestLimitedSelectionTrue()
        {
            WordList wordlistinstance = new WordList();
            InputWord inputwordinstance = new InputWord();
            wordlistinstance._wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
            inputwordinstance.Seedword = "Ben";
            wordlistinstance.RemoveIncorrectLength(inputwordinstance.Seedword);


            Boolean testresult = true;
            foreach (var word in wordlistinstance._wordList)
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
            WordList wordlistinstance = new WordList
            {
                _wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" }
            };
            InputWord inputwordinstance = new InputWord
            {
                Seedword = "Ben"
            };
            Boolean testresult = true;
            foreach (var word in wordlistinstance._wordList)
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
            WordList wordlistinstance = new WordList(_wordList);
            InputWord inputwordinstance = new InputWord
            {
                Seedword = "Ben"
            };
            wordlistinstance.RemoveIncorrectLength(inputwordinstance.Seedword);


            Boolean testresult = true;
            foreach (var word in wordlistinstance._wordList)
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
            WordList wordlistinstance = new WordList(_wordList);


            Boolean testresult = true;
            foreach (var word in wordlistinstance._wordList)
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
            WordList wordlistinstance = new WordList(_wordList);
            InputWord inputwordinstance = new InputWord
            {
                Seedword = "Ben"
            };
            wordlistinstance.RemoveIncorrectLength(inputwordinstance.Seedword);


            Boolean testresult = true;
            foreach (var word in wordlistinstance._wordList)
            {
                if (word.Length != inputwordinstance.Seedword.Length)
                {
                    testresult = false;
                }
            }

            Assert.True(testresult);
        }

        [Fact]
        public void CheckInputAndEndWordsSameLengthTrue()
        {
            InputWord inputwordinstance = new InputWord();

            Assert.True(inputwordinstance.AreWordsDifferentLength("Good", "Bad"));
        }


        [Fact]
        public void CheckInputAndEndWordsSameLengthFalse()
        {
            InputWord inputwordinstance = new InputWord();

            Assert.False(inputwordinstance.AreWordsDifferentLength("Good", "Goad"));
        }

        [Fact]
        public void CheckInputAndEndWordsSame()
        {
            InputWord inputwordinstance = new InputWord();

            Assert.False(inputwordinstance.AreWordsDifferent("Good", "Good"));
        }

        [Fact]
        public void CheckInputAndEndWordsDifferent()
        {
            InputWord inputwordinstance = new InputWord();

            Assert.True(inputwordinstance.AreWordsDifferent("Good", "Goad"));
        }

      

        [Fact]
        public void CheckEndWordExistsInListTrue()
        {
            List<string> words = new List<string>() { "cog", "mat" };

            WordList wordlistinstance = new WordList(words);
            InputWord inputwordinstance = new InputWord
            {
                Finishword = "cog"
            };
            wordlistinstance.FinishwordExistsInList(inputwordinstance.Finishword);

            Assert.True(wordlistinstance.ExistsInList);
        }


        [Fact]
        public void CheckEndWordExistsInListFalse()
        {
            List<string> words = new List<string>() { "cog", "mat" };

            WordList wordlistinstance = new WordList(words);
            InputWord inputwordinstance = new InputWord
            {
                Finishword = "Cog"
            };
            wordlistinstance.FinishwordExistsInList(inputwordinstance.Finishword);

            Assert.False(wordlistinstance.ExistsInList);
        }
    }

   
}
