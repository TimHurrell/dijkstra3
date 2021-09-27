
using System;




namespace FilepathClass
{

    public class WordFilePath
    {

        public string GetWordFilePath()
        {
            System.Console.Write("Enter file name :\n ");
            string filename = System.Console.ReadLine();
            return AppContext.BaseDirectory + @"\" + filename;
        }
    }

}
