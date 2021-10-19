using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordlistClass;
using WordladderstringClass;
using WordLadderLibrary;
using ConsoleApplication;


namespace ConsoleTestProject
{
    public class TestRecordsFile
    {
        readonly List<string> _listofwordsfromwordfile;
        public TestRecordsFile()
        {
            string Filepath = Path.Combine(AppContext.BaseDirectory, "words-english.txt");
            _listofwordsfromwordfile = File.ReadAllLines(Filepath).ToList();
        }

        [Fact]
        public void CheckWordListConstructor()
        {
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);
            Assert.Equal("AAA", wordlistinstance._listofwordsfromwordfile[12]);
        }
        [Fact]
        public void CheckListOnlyContains3LetterWordsTestLimitedSelectionTrue()
        {
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile();
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();
            wordlistinstance._listofwordsfromwordfile = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
            InputWordsForWordLaddersinstance.Seedword = "Ben";
            wordlistinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);
            Boolean testresult = true;
            foreach (var word in wordlistinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile
            {
                _listofwordsfromwordfile = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" }
            };
          

            bool testresult = true;
            foreach (var word in wordlistinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Seedword = "Ben"
            };
            wordlistinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);
            bool testresult = true;
            foreach (var word in wordlistinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);

            bool testresult = true;
            foreach (var word in wordlistinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Seedword = "Ben"
            };
            wordlistinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);
            Boolean testresult = true;
            foreach (var word in wordlistinstance._listofwordsfromwordfile)
            {
                if (word.Length != InputWordsForWordLaddersinstance.Seedword.Length)
                {
                    testresult = false;
                }
            }
            Assert.True(testresult);
        }
        [Fact]
        public void CheckInputAndEndWordsSameLengthTrue()
        {
            WordsValidator wordsvalidatorinstance = new WordsValidator();
            Assert.True(wordsvalidatorinstance.AreWordsDifferentLength("Good", "Bad"));
        }
        [Fact]
        public void CheckInputAndEndWordsSameLengthFalse()
        {
            WordsValidator wordsvalidatorinstance = new WordsValidator();
            Assert.False(wordsvalidatorinstance.AreWordsDifferentLength("Good", "Goad"));
        }
        [Fact]
        public void CheckInputAndEndWordsSame()
        {
            WordsValidator wordsvalidatorinstance = new WordsValidator();
            Assert.False(wordsvalidatorinstance.AreWordsDifferent("Good", "Good"));
        }
        [Fact]
        public void CheckInputAndEndWordsDifferent()
        {
            WordsValidator wordsvalidatorinstance = new WordsValidator();
            Assert.False(wordsvalidatorinstance.AreWordsDifferent("Good", "Goad"));
        }

        [Fact]
        public void CheckEndWordExistsInListTrue()
        {
            List<string> words = new List<string>() { "cog", "mat" };
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(words);
            
            Assert.True(wordlistinstance.WordExistsInListFromWordFile("cog"));
        }
        [Fact]
        public void CheckEndWordExistsInListFalse()
        {
            List<string> words = new List<string>() { "cog", "mat" };
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(words);
            Assert.False(wordlistinstance.WordExistsInListFromWordFile("Cog"));
        }

        [Fact]

        // want to simplify this and not have to invoke the wordladder library file
        public void CheckStringCreatedFromWordLadder()
        {
            List<string> listofwordsfromwordfile = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            string beginWord = "hit";
            string endWord = "cog";
            List<List<string>> expectedLadders = new List<List<string>>
            {
                new List<string> { "hit", "hot", "dot", "dog", "cog" },
                new List<string> { "hit", "hot", "lot", "log", "cog" }
            };

            var foundLadders = new WordLadderSolution().FindLadders(beginWord, endWord, listofwordsfromwordfile);


            string testoutputtedstring = "\r\nLadder1,hit,hot,dot,dog,cog\r\nLadder2,hit,hot,lot,log,cog";
            StringOfWordLadder TestWordLadderString = new StringOfWordLadder();

            //Test
            Assert.Equal(testoutputtedstring, TestWordLadderString.GetStringOfWordLadder(foundLadders));
        }

    }

   
}



