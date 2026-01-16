/// <file>Program.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <brief>Main file</brief>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

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
                    StarExec.Load();
                    MovieExec.Load();
                    break;
                case 2:
                    Console.WriteLine("Starting with a fresh database...");
                    break;
                default:
                    end = true;
                    break;
            }

            if (!end && loadOption != 2)
                ConsoleUI.Pause();

            while (!end)
            {
                int option = ConsoleUI.MainMenu();
                switch (option)
                {
                    case 1:
                        GlobalExec<Star>.Menu();
                        break;
                    case 2:
                        GlobalExec<Movie>.Menu();
                        break;
                    case 3:
                        StarExec.Save();
                        MovieExec.Save();
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
