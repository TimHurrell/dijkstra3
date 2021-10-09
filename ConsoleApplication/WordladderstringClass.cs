
using System.Collections.Generic;
using System.Text;


namespace WordladderstringClass
{ 
public class StringOfWordLadder
{
    public string GetStringOfWordLadder(IEnumerable<IEnumerable<string>> ladders)
    {
        string strSeperator = ",";
        StringBuilder StringOfWordLadders = new StringBuilder();
        int i = 0;
        foreach (var item in ladders)
        {
            i++;
            StringOfWordLadders.AppendLine(string.Join(strSeperator, ""));
            StringOfWordLadders.Append(string.Join(strSeperator, "Ladder" + i));
            foreach (var item1 in item)
            {
                StringOfWordLadders.Append(string.Join(strSeperator, ","));
                StringOfWordLadders.Append(string.Join(strSeperator, item1));
            }
        }
        return StringOfWordLadders.ToString();
    }


}
}
