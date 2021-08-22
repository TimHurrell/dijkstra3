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
            WordList sol1 = new WordList();
            Console.Write("Enter start word : \n");
            sol1.Inputword = Console.ReadLine();
            Console.Write("Enter finish word :\n ");
            sol1.Endword = Console.ReadLine();


            // List<String> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };




            sol1.Inputword = sol1.MakeWordLowerCase(sol1.Inputword);
            sol1.Endword = sol1.MakeWordLowerCase(sol1.Endword);

            Console.WriteLine(sol1.Inputword);
            Console.WriteLine(sol1.Endword);




            //foreach (var item in sol1.wordList)
            //   {
            //       Console.Write("New ladder \n");
            //       Console.WriteLine(item.ToString());
            //   }



            //numInput1 = Console.ReadLine();
            //    Solution sol1 = new Solution();

            //    foreach (var item in sol1.FindLadders(beginWord, endWord, wordList))
            //    {
            //        Console.Write("New ladder \n");
            //        foreach (var item1 in item)
            //        {
            //            Console.WriteLine(item1.ToString());
            //        }
            //    }
        }
    }



    public class WordList
    {
        public List<string> wordList { get; set; }
        public string Inputword { get; set; }
        public string Endword { get; set; }
        public bool IsSameLength { get; set; }
        public bool IsSameWord { get; set; }

        public WordList()
        {
            string path = "";
            path = System.AppContext.BaseDirectory;
            string Filepath = path + @"\words-english.txt";
            //List<string> wordList = File.ReadAllLines(Filepath).ToList();
            wordList = File.ReadAllLines(Filepath).ToList();
            //Inputword = "Harry";
            //Endword = "Roger";
            IsSameLength = true;
            IsSameWord = false;
        }

         public List<string> RemoveIncorrectLength()
        {
            List<string> wordList2 = new List<string> {};
            foreach (var word in wordList)
            {
                if (word.Length == Inputword.Length)
                {
                    wordList2.Add(word);
                }
            }
            wordList = wordList2;
            return wordList;
        }

        public void RemoveIfWordsDifferentLength()
        {
            if (Endword.Length != Inputword.Length)
            {
                IsSameLength = false;
            }
        }

        public void RemoveIfWordsSame()
        {
            if (Endword == Inputword)
            {
                IsSameWord = true;
            }
        }

        public string MakeWordLowerCase(string word)
        {
            int length = word.Length;
            string finalletters = word[1..length];
            string firstletter = Inputword[0].ToString();
            finalletters = finalletters.ToLower();
            word = firstletter + finalletters;
            return word;
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
