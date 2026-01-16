/// <file>ConsoleUI.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;

namespace Presentation
{
    /// <summary>
    /// Class with console menu methods
    /// </summary>
    public static class ConsoleUI
    {
        /// <summary>
        /// Menu to ask the user if they want to read the information from the repositories present in a binary file.
        /// </summary>
        /// <returns></returns>
        public static int LoadMenu()
        {
            int? option = 0;
            bool success = false;

            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Before starting,");
                Console.WriteLine("Choose an option: ");
                Console.WriteLine();

                int count = 1;
                Console.WriteLine($"{count++} - Load data from binary file");
                Console.WriteLine($"{count++} - Start with a fresh database");

                Console.WriteLine("\n0 - Quit\n");

                option = ConsoleIO.ReadInt("option");
                Console.WriteLine();

                if (option is not null && option >= 0 && option < count)
                    success = true;
                else
                {
                    Console.WriteLine("Invalid option!");
                    Pause();
                }
            }

            return option ?? 0;
        }
        
        /// <summary>
        /// Menu for selecting a repository to manipulate.
        /// </summary>
        /// <returns></returns>
        public static int MainMenu()
        {
            int? option = 0;
            bool success = false;

            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Choose an option: ");
                Console.WriteLine();

                int count = 1;
                Console.WriteLine($"{count++} - Star Repository");
                Console.WriteLine($"{count++} - Movie Repository");
                Console.WriteLine($"{count++} - Save data on binary file");

                Console.WriteLine("\n0 - Quit\n");

                option = ConsoleIO.ReadInt("option");
                Console.WriteLine();

                if (option is not null && option >= 0 && option < count)
                    success = true;
                else
                {
                    Console.WriteLine("Invalid option!");
                    Pause();
                }
            }

            return option ?? 0;
        }

        /// <summary>
        /// Menu with all options of a repository.
        /// </summary>
        /// <param name="menuType"></param>
        /// <returns></returns>
        public static int RepoMenu(string menuType)
        {
            int? option = 0;
            bool success = false;

            while (!success)
            {
                Console.Clear();
                Console.WriteLine(menuType + " repository");
                Console.WriteLine("Choose an option: ");
                Console.WriteLine();

                int count = 1;
                Console.WriteLine($"{count++} - Show full repository");
                Console.WriteLine($"{count++} - Show {menuType} by ID");
                Console.WriteLine($"{count++} - Show {menuType} by index");
                Console.WriteLine($"{count++} - Add {menuType}");
                Console.WriteLine($"{count++} - Remove {menuType} by ID");
                Console.WriteLine($"{count++} - Remove {menuType} by index");
                Console.WriteLine($"{count++} - Edit {menuType} by ID");
                Console.WriteLine($"{count++} - Edit {menuType} by index");
                Console.WriteLine($"{count++} - Sort repository");

                Console.WriteLine("\n0 - Go Back\n");

                option = ConsoleIO.ReadInt("option");
                Console.WriteLine();

                if (option is not null && option >= 0 && option < count)
                    success = true;
                else
                {
                    Console.WriteLine("Invalid option!");
                    Pause();
                }
            }

            return option ?? 0;
        }

        public static void Pause()
        {
            Console.Write("\npress ENTER to continue...");
            Console.ReadKey();
        }
    }
}
