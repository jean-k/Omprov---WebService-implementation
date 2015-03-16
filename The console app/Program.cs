using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_web_app;

namespace The_console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Arbetsprov - Atea";
            Console.WriteLine("*** Welcome to the console to website application, made by Jean Kam.");
            Console.WriteLine();
            Console.Write(" How it works:\n 1) Write a message \n 2) Press enter \n 3) Enjoy the incoming messages on the website!\n");

            Console.WriteLine(" To exit type 'exit', then press enter.");
            Console.WriteLine("\n");
            Console.WriteLine(" Please write a message below.");

            MessageService ms = new MessageService();
            while (true)
            {
                try
                {
                    Console.WriteLine(" Write a message below!");
                    string message = Console.ReadLine();
                    //Programmet avslutas när man skriver 'e' och trycker på Enter.
                    if (message == "exit")
                    {
                        break;
                    }
                    //Web service anrop
                    int row = ms.SaveMessage(message, DateTime.Now);
                    if (row > 0)
                    {
                        Console.WriteLine("Message sent!");
                    }
                    else
                    {
                        Console.WriteLine("Error. Message was not sent!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
