

using System.Collections.Generic;




namespace WordlistClass
{

        public class WordList
        {
            public List<string> _wordList { get; set; }
            //inject the dependency
            //this type of dependency injection is known as constructor injection
            public WordList(List<string> wordList)
            {
                _wordList = wordList;
            }
            public WordList()
            {
            }
            public bool ExistsInList { get; set; }









            public List<string> RemoveIncorrectLength(string inputwordinstance)
            {
                List<string> amendedwordlist = new List<string> { };
                foreach (var word in _wordList)
                {
                    if (word.Length == inputwordinstance.Length)
                    {
                        amendedwordlist.Add(word);
                    }
                }
                _wordList = amendedwordlist;
                return _wordList;
            }
            public void FinishwordExistsInList(string endword)
            {
                foreach (var word in _wordList)
                {


                    if (endword == word)
                    {
                        ExistsInList = true;
                    }
                }
            }
        }









    }
