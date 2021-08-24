using System;
using Xunit;
using ConsoleApp1;
using System.Collections.Generic;

namespace ConsoleTestProject
{



    public class TestRecordsFile
    {

        [Fact]
        public void CheckWordListConstructor()
        {
            WordList sol1 = new WordList();
            Assert.Equal("AAA",sol1.wordList[12]);



        }

        [Fact]
        public void CheckListOnlyContains3LetterWordsTestLimitedSelectionTrue()
        {
            WordList sol1 = new WordList();
            sol1.wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
            sol1.Inputword = "Ben";
            sol1.RemoveIncorrectLength();


            Boolean testresult = true;
            foreach (var word in sol1.wordList)
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
            WordList sol1 = new WordList();
            sol1.wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
            sol1.Inputword = "Ben";
            Boolean testresult = true;
            foreach (var word in sol1.wordList)
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
            WordList sol1 = new WordList();
            sol1.RemoveIncorrectLength();


            Boolean testresult = true;
            foreach (var word in sol1.wordList)
            {
                if (word.Length != 5)
                {
                    testresult = false;
                }
            }

            Assert.True(testresult);



        }


        [Fact]
        public void CheckListOnlyContains3LetterWordsTestFullSelectionFalse()
        {
            WordList sol1 = new WordList();


            Boolean testresult = true;
            foreach (var word in sol1.wordList)
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
            WordList sol1 = new WordList();
            sol1.RemoveIncorrectLength();


            Boolean testresult = true;
            foreach (var word in sol1.wordList)
            {
                if (word.Length != sol1.Inputword.Length)
                {
                    testresult = false;
                }
            }

            Assert.True(testresult);



        }

        [Fact]
        public void CheckInputAndEndWordsSameLengthTrue()
        {
            WordList sol1 = new WordList();

            Assert.True(sol1.AreWordsDifferentLength("Good","Bad"));


        }


        [Fact]
        public void CheckInputAndEndWordsSameLengthFalse()
        {
            WordList sol1 = new WordList();

            Assert.False(sol1.AreWordsDifferentLength("Good", "Goad"));
        }


        [Fact]
        public void CheckInputAndEndWordsSame()
        {
            WordList sol1 = new WordList();

            Assert.False(sol1.AreWordsDifferent("Good", "Good"));


        }

        [Fact]
        public void CheckInputAndEndWordsDifferent()
        {
            WordList sol1 = new WordList();
            Assert.True(sol1.AreWordsDifferent("Good", "Goad"));


        }

        [Fact]
        public void CheckWordLowerCaseFalse()
        {
            WordList sol1 = new WordList();
            sol1.Inputword = "JOhnny";

            Assert.False(Char.IsLower(sol1.Inputword[1]));


        }

        [Fact]
        public void CheckWordLowerCaseTrue()
        {
            WordList sol1 = new WordList();
            sol1.Inputword = "JOhnny";
            sol1.Inputword = sol1.MakeWordLowerCase(sol1.Inputword);

            Assert.True(Char.IsLower(sol1.Inputword[1]));


        }

        [Fact]
        public void CheckEndWordExistsInListTrue()
        {
            WordList sol1 = new WordList();
            sol1.Endword = "cog";
            sol1.EndwordExistsInList();

            Assert.True(sol1.ExistsInList);


        }


        [Fact]
        public void CheckEndWordExistsInListFalse()
        {
            WordList sol1 = new WordList();
            sol1.Endword = "Cog";
            sol1.EndwordExistsInList();

            Assert.False(sol1.ExistsInList);


        }


    }

}
