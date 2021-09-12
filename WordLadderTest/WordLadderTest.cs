
using System;
using System.Collections.Generic;
using WordLadderLibrary;
using Xunit;

namespace WordLadderTest
{
   




    public class TestRecordsFile
    {

        [Fact]
        public void GetFindLadderTest()
        {
            List<String> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            string beginWord = "hit";
            string endWord = "cog";
            List<List<string>> transformation = new List<List<string>>
            {
            new List<string> { "hit", "hot", "dot", "dog", "cog" },
            new List<string> { "hit", "hot", "lot", "log", "cog" }
            };


            WordLadderSolution WordLadderInstance = new WordLadderSolution();



            WordLadderInstance.FindLadders(beginWord, endWord, wordList);

            Assert.Equal(WordLadderInstance.FindLadders(beginWord, endWord, wordList), transformation);
        }

        [Fact]
        public void WithinSingleEditDistance1()
        {

            WordLadderSolution WordLadderInstance = new WordLadderSolution();


            Assert.True(WordLadderInstance.WithinSingleEditDistance("eddi", "eddy"));

        }


        [Fact]
        public void WithinSingleEditDistance2()
        {

            WordLadderSolution WordLadderInstance = new WordLadderSolution();

            Assert.False(WordLadderInstance.WithinSingleEditDistance("eddi", "eddi"));

        }


        [Fact]
        public void WithinSingleEditDistance3()
        {

            WordLadderSolution WordLadderInstance = new WordLadderSolution();

            Assert.False(WordLadderInstance.WithinSingleEditDistance("eddi", "edey"));

        }





       



    }


}
