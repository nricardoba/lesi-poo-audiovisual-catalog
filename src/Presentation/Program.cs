using System;
using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;

            int saveOption = ConsoleUI.SaveMenu();
            switch (saveOption)
            {
                case 1:
                    Console.WriteLine("Load data from binary file");
                    break;
                case 2:
                    Console.WriteLine("Start with a fresh database");
                    break;
                default:
                    end = true;
                    break;
            }

            if (!end)
                ConsoleUI.Pause();

            while (!end)
            {
                int option = ConsoleUI.MainMenu();
                switch (option)
                {
                    case 1:
                        StarExec.StarMenu();
                        break;
                    default:
                        end = true;
                        break;
                }

                // if (!end)
                //     ConsoleUI.Pause();
            }

            Console.WriteLine("The End...");
        }
    }
}
