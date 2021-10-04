using System.Collections.Generic;
using System.Linq;

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

        public List<string> RemoveIncorrectLength(string inputWordsForWordLaddersinstance)
        {
            //I've used LINQ here which is a more terse way of manipulating lists.
            //We've not covered this yet
            _listofwordsfromwordfile = _listofwordsfromwordfile.Where(o => o.Length == inputWordsForWordLaddersinstance.Length).ToList();
            return _listofwordsfromwordfile;
        }

        //TODO can you think of less specific name of this method.
        //Would it work for other words besides the endword?
        public bool WordExistsInListFromWordFile(string endword)
        {
            //Again using LINQ to find containing word
            return _listofwordsfromwordfile.Contains(endword);
        }
    }
}
