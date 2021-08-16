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
        public void CheckListOnlyContains3LetterWordsTest()
        {
            WordList sol1 = new WordList();
            sol1.wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
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
        public void CheckListOnlyContains3LetterWordsTest2()
        {
            List<String> wordList = new List<string> { "hot", "dot", "doog", "lot", "log", "cog" };
            Boolean testresult = true;
            foreach (var word in wordList)
            {
                if (word.Length != 3)
                {
                    testresult = false;
                }
            }

            Assert.False(testresult);



        }

    }

}
