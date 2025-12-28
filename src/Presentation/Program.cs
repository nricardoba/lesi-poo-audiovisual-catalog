using System;
using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // bool end = false;

            // int saveOption = ConsoleUI.SaveMenu();
            // switch (saveOption)
            // {
            //     case 1:
            //         Console.WriteLine("Load data from binary file");
            //         break;
            //     case 2:
            //         Console.WriteLine("Start with a fresh database");
            //         break;
            //     default:
            //         end = true;
            //         break;
            // }

            // if (!end)
            //     ConsoleUI.Pause();

            // while (!end)
            // {
            //     int option = ConsoleUI.MainMenu();
            //     switch (option)
            //     {
            //         case 1:
            //             StarExec.StarMenu();
            //             break;
            //         default:
            //             end = true;
            //             break;
            //     }

            //     // if (!end)
            //     //     ConsoleUI.Pause();
            // }

            // Console.WriteLine("The End...");

            Star s1 = StarService.Create("Manuel", new DateOnly(1966, 11, 8), 1);
            Star s2 = StarService.Create("Filipe", new DateOnly(1998, 2, 17), 2);
            Star s3 = StarService.Create("Eduarda", new DateOnly(1989, 8, 14), 3);
            GlobalRepoControl<Star>.AddElement(s1);
            GlobalRepoControl<Star>.AddElement(s2);
            GlobalRepoControl<Star>.AddElement(s3);
            StarExec.ShowRepo();

            bool success = GlobalRepoControl<Star>.Save("src/Bin/Stars.json");

            // bool success = GlobalRepoControl<Star>.Load("src/Bin/Stars.json");
            // StarExec.ShowRepo();

            Console.WriteLine(success);
        }
    }
}
