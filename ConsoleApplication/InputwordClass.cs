



namespace ConsoleApplication
{



    public class InputWordsForWordLadders
    {
        public string Seedword { get; set; }
        public string Finishword { get; set; }



        public InputWordsForWordLadders()
        {

            System.Console.Write("Enter start word : \n");
            Seedword = System.Console.ReadLine();
            System.Console.Write("Enter finish word :\n ");
            Finishword = System.Console.ReadLine();
            System.Console.WriteLine(Seedword);
            System.Console.WriteLine(Finishword);
        }
       

    }



}
