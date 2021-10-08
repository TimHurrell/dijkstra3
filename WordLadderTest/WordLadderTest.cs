
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
            List<string> listofwordsfromwordfile = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            string beginWord = "hit";
            string endWord = "cog";
            List<List<string>> expectedLadders = new List<List<string>>
            {
                new List<string> { "hit", "hot", "dot", "dog", "cog" },
                new List<string> { "hit", "hot", "lot", "log", "cog" }
            };

            var foundLadders = new WordLadderSolution().FindLadders(beginWord, endWord, listofwordsfromwordfile);

            Assert.Equal(expectedLadders, foundLadders);
        }

        //TODO give these tests better namas
        //Like WithinSingleEditDistanceIsTrueTest

        // Done
        [Fact]
        public void WithinSingleEditDistanceIsTrueTest()
        {
            WordLadderSolution WordLadderInstance = new WordLadderSolution();
            Assert.True(WordLadderInstance.WithinSingleEditDistance("eddi", "eddy"));
        }

        [Fact]
        public void WithinSingleEditDistanceIsZeroFalseTest()
        {
            WordLadderSolution WordLadderInstance = new WordLadderSolution();
            Assert.False(WordLadderInstance.WithinSingleEditDistance("eddi", "eddi"));
        }

        [Fact]
        public void WithinSingleEditDistanceIsPluralTest()
        {
            WordLadderSolution WordLadderInstance = new WordLadderSolution();
            Assert.False(WordLadderInstance.WithinSingleEditDistance("eddi", "edey"));
        }
    }
}
