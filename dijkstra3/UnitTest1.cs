using ClassLibrary1;
using System;
using System.Collections.Generic;

using Xunit;

namespace dijkstra3
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


            Solution sol1 = new Solution();



            sol1.FindLadders(beginWord, endWord, wordList);

            Assert.Equal(sol1.FindLadders(beginWord, endWord, wordList), transformation);
        }

        [Fact]
        public void WithinSingleEditDistance1()
        {

            Solution sol1 = new Solution();


            Assert.True(sol1.WithinSingleEditDistance("eddi", "eddy"));

        }


        [Fact]
        public void WithinSingleEditDistance2()
        {

            Solution sol1 = new Solution();

            Assert.False(sol1.WithinSingleEditDistance("eddi", "eddi"));

        }


        [Fact]
        public void WithinSingleEditDistance3()
        {

            Solution sol1 = new Solution();

            Assert.False(sol1.WithinSingleEditDistance("eddi", "edey"));

        }


        [Fact]
        public void BuildGraphTest()
        {
            List<String> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            string beginWord = "hit";


            Solution sol1 = new Solution();

            var graph = sol1.BuildGraph(wordList, beginWord);

        }



    }


}
