
using System;
using System.IO;





namespace ConsoleApplication
{

    public class WordFilePath
    {

        public string GetWordFilePath()
        {
            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();
            string filepath = Path.Combine(AppContext.BaseDirectory, filename);
            return filepath;
        }
    }

}
