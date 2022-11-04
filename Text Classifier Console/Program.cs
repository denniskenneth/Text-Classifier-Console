
using System;
using System.IO;


namespace Text_Classifier_Console 
{
    class Program
    {
        static Methods Api;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello welcome to 4th IR's Text Classifier");
            Console.WriteLine("PLease Enter some text");
            string consoleTxt = Console.ReadLine();

            if (consoleTxt != null && consoleTxt.GetType() == typeof(string))
            {
                Api = new Methods(consoleTxt);
                await Api.classify();

                
            }else
            {
                Console.WriteLine("Invalid Input");
            }
            
        }
    }
}
