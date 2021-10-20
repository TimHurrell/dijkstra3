
using System;
using System.IO;

namespace ConsoleApplication
{

    public static class WordFilePath
    {
        public static string GetWordFilePath()
        {
            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();
            return Path.Combine(AppContext.BaseDirectory, filename);
        }
    }

}
