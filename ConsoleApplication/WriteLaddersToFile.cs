using System;
using System.Collections.Generic;
using System.IO;
using WordladderstringClass;

namespace WriteLaddersToFile
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

