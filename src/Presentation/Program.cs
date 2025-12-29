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

            int loadOption = ConsoleUI.LoadMenu();
            switch (loadOption)
            {
                case 1:
                    GlobalExec.Load();
                    break;
                case 2:
                    Console.WriteLine("Starting with a fresh database...");
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
                    case 2:
                        GlobalExec.Save();
                        ConsoleUI.Pause();
                        break;
                    default:
                        end = true;
                        break;
                }
            }

            Console.WriteLine("The End...");
        }
    }
}
