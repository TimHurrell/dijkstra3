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
        readonly List<string> _listofwordsfromwordfile;

        public TestRecordsFile()
        {
            string path = AppContext.BaseDirectory;
            string listofwordsfromwordfilefilepath = path + @"\words-english.txt";
            _listofwordsfromwordfile = File.ReadAllLines(listofwordsfromwordfilefilepath).ToList();
        }


        [Fact]
        public void ChecklistofwordsfromwordfileConstructor()
        {
            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);
            Assert.Equal("AAA", listofwordsfromwordfileinstance._listofwordsfromwordfile[12]);
        }


        [Fact]
        public void CheckListOnlyContains3LetterWordsTestLimitedSelectionTrue()
        {
            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile();
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders();
            listofwordsfromwordfileinstance._listofwordsfromwordfile = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
            InputWordsForWordLaddersinstance.Seedword = "Ben";
            listofwordsfromwordfileinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);


            Boolean testresult = true;
            foreach (var word in listofwordsfromwordfileinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile
            {
                _listofwordsfromwordfile = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" }
            };
            _ = new InputWordsForWordLadders
            {
                Seedword = "Ben"
            };
            Boolean testresult = true;
            foreach (var word in listofwordsfromwordfileinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Seedword = "Ben"
            };
            listofwordsfromwordfileinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);


            Boolean testresult = true;
            foreach (var word in listofwordsfromwordfileinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);


            Boolean testresult = true;
            foreach (var word in listofwordsfromwordfileinstance._listofwordsfromwordfile)
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
            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile(_listofwordsfromwordfile);
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Seedword = "Ben"
            };
            listofwordsfromwordfileinstance.RemoveIncorrectLength(InputWordsForWordLaddersinstance.Seedword);


            Boolean testresult = true;
            foreach (var word in listofwordsfromwordfileinstance._listofwordsfromwordfile)
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

            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile(words);
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Finishword = "cog"
            };
            listofwordsfromwordfileinstance.FinishwordExistsInList(InputWordsForWordLaddersinstance.Finishword);

            Assert.True(listofwordsfromwordfileinstance.ExistsInList);
        }


        [Fact]
        public void CheckEndWordExistsInListFalse()
        {
            List<string> words = new List<string>() { "cog", "mat" };

            Listofwordsfromwordfile listofwordsfromwordfileinstance = new Listofwordsfromwordfile(words);
            InputWordsForWordLadders InputWordsForWordLaddersinstance = new InputWordsForWordLadders
            {
                Finishword = "Cog"
            };
            listofwordsfromwordfileinstance.FinishwordExistsInList(InputWordsForWordLaddersinstance.Finishword);

            Assert.False(listofwordsfromwordfileinstance.ExistsInList);
        }

     
    }

}
