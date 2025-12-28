using BusinessObjects;

namespace Presentation
{
    public static class ConsoleUI
    {
        public static int SaveMenu()
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

                // ver melhor o is not!!!
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
        
        public static int MainMenu()
        {
            int? option = 0;
            bool success = false;

            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Choose a repository: ");
                Console.WriteLine();

                int count = 1;
                Console.WriteLine($"{count++} - Star");

                Console.WriteLine("\n0 - Quit\n");

                option = ConsoleIO.ReadInt("option");
                Console.WriteLine();

                // ver melhor o is not!!!
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

        public static int StarMenu()
        {
            int? option = 0;
            bool success = false;

            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Star repository");
                Console.WriteLine("Choose an option: ");
                Console.WriteLine();

                int count = 1;
                Console.WriteLine($"{count++} - Show full repository");
                Console.WriteLine($"{count++} - Show Star by ID");
                Console.WriteLine($"{count++} - Show Star by index");
                Console.WriteLine($"{count++} - Add Star");
                Console.WriteLine($"{count++} - Remove Star by ID");
                Console.WriteLine($"{count++} - Remove Star by index");
                Console.WriteLine($"{count++} - Edit Star by ID");
                Console.WriteLine($"{count++} - Edit Star by index");

                Console.WriteLine("\n0 - Go Back\n");

                option = ConsoleIO.ReadInt("option");
                Console.WriteLine();

                // ver melhor o is not!!!
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
