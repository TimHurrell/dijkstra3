using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace dijkstra3
{
   

public class Node
    {
        public string Value { get; set; }
        public List<Node> Neighbors { get; set; }
        public List<Node> ShortestPathChildren { get; set; }

        public bool isVisited { get; set; }
        public int Distance { get; set; }
        public Node()
        {
            Neighbors = new List<Node>();
            ShortestPathChildren = new List<Node>();
            Distance = int.MaxValue;
            isVisited = false;
        }

    }

    public class Solution
    {

        public bool WithinSingleEditDistance(string s1, string s2)
        {
            int misMatchCount = 0;

            for (int i = 0; i < s1.Length; ++i)
            {
                if (s1[i] != s2[i])
                {
                    if (misMatchCount > 0)
                        return false;
                    else
                        misMatchCount++;
                }
            }

            return (misMatchCount == 1);
        }
        public List<Node> BuildGraph(IList<string> wordList, string beginWord)
        {
            var graph = new List<Node>();

            if (!wordList.Contains(beginWord))
                graph.Add(new Node() { Value = beginWord });

            foreach (var word in wordList)
            {
                var node = new Node()
                {
                    Value = word
                };
                graph.Add(node);
            }

            foreach (var n1 in graph)
            {
                foreach (var n2 in graph)
                {
                    if (WithinSingleEditDistance(n1.Value, n2.Value))
                    {
                        n1.Neighbors.Add(n2);
                    }
                }
            }

            return graph;
        }

        public IList<IList<string>> FindLadders(
            string beginWord, string endWord, IList<string> wordList)
        {
            var graph = BuildGraph(wordList, beginWord);

            var startNode = graph.Single(x => x.Value.Equals(beginWord));

            var destNode = graph.SingleOrDefault(x => x.Value.Equals(endWord));

            if (destNode == null)
                return new List<IList<string>>();

            findPathsBFS(startNode, destNode);
            ladders = new List<IList<string>>();

            traverseDFS(startNode, destNode, new List<string>());

            return ladders;
        }

        public List<IList<string>> ladders { get; set; }
        public int MinDistance { get; set; }
        public void findPathsBFS(Node start, Node dest)
        {
            MinDistance = int.MaxValue;
            var list = new List<Node>();
            start.Distance = 0;
            list.Add(start);

            while (list.Count > 0)
            {
                var new_list = new List<Node>();

                foreach (var node in list)
                {
                    if (node.Value.Equals(dest.Value))
                    {
                        MinDistance = node.Distance;
                        continue;
                    }

                    foreach (var neighbor in node.Neighbors)
                    {
                        var new_distance = node.Distance + 1;

                        if ((!node.isVisited) &&
                            (new_distance <= neighbor.Distance) &&
                            (new_distance <= MinDistance))
                        {
                            node.ShortestPathChildren.Add(neighbor);
                            neighbor.Distance = new_distance;
                            new_list.Add(neighbor);
                        }
                    }

                    node.isVisited = true;
                }

                list = new_list;
            }

        }
        public void traverseDFS(Node current, Node dest, List<string> ladder)
        {
            ladder.Add(current.Value);

            if (current.Value.Equals(dest.Value))
            {
                var copied_ladder = new List<string>();
                foreach (var word in ladder)
                    copied_ladder.Add(word);
                ladders.Add(copied_ladder);
                ladder.Remove(current.Value);
                return;
            }

            foreach (var child in current.ShortestPathChildren)
            {
                traverseDFS(child, dest, ladder);
            }

            ladder.Remove(current.Value);
        }
    }



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



    }


}
