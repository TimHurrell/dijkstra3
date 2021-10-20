using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
	public class CreateWordListFromFile
	{
		

		public Listofwordsfromwordfile GetWordList(string filepath)
		{
			List<string> _listofwordsfromwordfile;
			_listofwordsfromwordfile = File.ReadAllLines(filepath).ToList();
			return new Listofwordsfromwordfile(_listofwordsfromwordfile);
		}
	}
}
