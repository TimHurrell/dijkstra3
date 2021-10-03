using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordlistClass;
using InputwordClass;
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
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();
            Assert.True(InputWordsForWordLaddersinstance.AreWordsDifferentLength("Good", "Bad"));
        }
        [Fact]
        public void CheckInputAndEndWordsSameLengthFalse()
        {
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();
            Assert.False(InputWordsForWordLaddersinstance.AreWordsDifferentLength("Good", "Goad"));
        }
        [Fact]
        public void CheckInputAndEndWordsSame()
        {
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();
            Assert.False(InputWordsForWordLaddersinstance.AreWordsDifferent("Good", "Good"));
        }
        [Fact]
        public void CheckInputAndEndWordsDifferent()
        {
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();
            Assert.True(InputWordsForWordLaddersinstance.AreWordsDifferent("Good", "Goad"));
        }

        [Fact]
        public void CheckEndWordExistsInListTrue()
        {
            List<string> words = new List<string>() { "cog", "mat" };
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(words);
            
            Assert.True(wordlistinstance.FinishwordExistsInList("cog"));
        }
        [Fact]
        public void CheckEndWordExistsInListFalse()
        {
            List<string> words = new List<string>() { "cog", "mat" };
            Listofwordsfromwordfile wordlistinstance = new Listofwordsfromwordfile(words);
            Assert.False(wordlistinstance.FinishwordExistsInList("Cog"));
        }

    }
}



