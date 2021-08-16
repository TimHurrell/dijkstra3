using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string numInput1 = "";
            Console.Write("Enter start word : \n");
            Console.Write("Enter finish word :\n ");
            Console.Write("Enter word list :\n ");

            // List<String> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };

            string path = "";
            path = System.AppContext.BaseDirectory;
            string Filepath = path + @"\words-english.txt";
            List<string> wordList = File.ReadAllLines(Filepath).ToList();


            string beginWord = "hit";
            string endWord = "cog";
            //numInput1 = Console.ReadLine();
            Solution sol1 = new Solution();

            foreach (var item in sol1.FindLadders(beginWord, endWord, wordList))
            {
                Console.Write("New ladder \n");
                foreach (var item1 in item)
                {
                    Console.WriteLine(item1.ToString());
                }
            }
        }
    }



    public class WordList
    {
        public List<string> wordList { get; set; }

        public int length { get; set; }
        public WordList()
        {
            string path = "";
            path = System.AppContext.BaseDirectory;
            string Filepath = path + @"\words-english.txt";
            List<string> wordList = File.ReadAllLines(Filepath).ToList();
            length = 3;
        }

         public List<string> RemoveIncorrectLength()
        {
            List<string> wordList2 = new List<string> {};
            foreach (var word in wordList)
            {
                if (word.Length == length)
                {
                    wordList2.Add(word);
                }
            }
            wordList = wordList2;
            return wordList;
        }

    }
}

//class MainConsole
//{
//    static void Main(string[] args)
//    {
//        //if the variable is in grey its not being used so you can remove them
//        string path = "";
//        path = System.AppContext.BaseDirectory;
//        string Filepath = path + @"\MaturityData.csv";

//        List<string> lines = File.ReadAllLines(Filepath).ToList();
//        List<PolicyData> ListOfAccounts = new List<PolicyData>();

//        foreach (var line in lines)
//        {
//            PolicyData NewPolicyData = new PolicyData(line);
//            ListOfAccounts.Add(NewPolicyData);
//        }

//        List<Policy> ListOfPolicys = new List<Policy>();
//        foreach (PolicyData account in ListOfAccounts)

//        {


//            PolicyFactory factory = new ConcretePolicyFactory();
//            Policy policy = factory.GetPolicy(account.GetPolicyType(), account);
//            ListOfPolicys.Add(policy);
//        }


//        IDictionary<string, decimal> PolicyNumberAndPayout = new Dictionary<string, decimal>();
//        foreach (Policy acco in ListOfPolicys)
//        {
//            PolicyNumberAndPayout.Add(acco.PolicyNumber, acco.GetMaturityPayout());
//        }

//        path = System.AppContext.BaseDirectory;
//        string jsonOutPut = JsonSerializer.Serialize(PolicyNumberAndPayout);
//        System.IO.File.WriteAllText(path + @"\jsonInsurancePolicyFile.json", jsonOutPut);

//    }
//}
