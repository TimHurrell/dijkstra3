

using System.Collections.Generic;




namespace WordlistClass
{

        public class Listofwordsfromwordfile
        {
            public List<string> _listofwordsfromwordfile { get; set; }
            //inject the dependency
            //this type of dependency injection is known as constructor injection
            public Listofwordsfromwordfile(List<string> listofwordsfromwordfile)
            {
                _listofwordsfromwordfile = listofwordsfromwordfile;
            }
            public Listofwordsfromwordfile()
            {
            }
            public bool ExistsInList { get; set; }









            public List<string> RemoveIncorrectLength(string InputWordsForWordLaddersinstance)
            {
                List<string> amendedlistofwordsfromwordfile = new List<string> { };
                foreach (var word in _listofwordsfromwordfile)
                {
                    if (word.Length == InputWordsForWordLaddersinstance.Length)
                    {
                        amendedlistofwordsfromwordfile.Add(word);
                    }
                }
                _listofwordsfromwordfile = amendedlistofwordsfromwordfile;
                return _listofwordsfromwordfile;
            }
            public void FinishwordExistsInList(string endword)
            {
                foreach (var word in _listofwordsfromwordfile)
                {


                    if (endword == word)
                    {
                        ExistsInList = true;
                    }
                }
            }
        }









    }
