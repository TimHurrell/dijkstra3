using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    public class WriteLadders
    {
        public void WriteToFile(IList<IList<string>> ladders)
        {
            string strFilePath = Path.Combine(AppContext.BaseDirectory, "Data.csv");

            StringOfWordLadder WordLadderString = new StringOfWordLadder();

            File.WriteAllText(strFilePath, WordLadderString.GetStringOfWordLadder(ladders));
        }
    }
}

