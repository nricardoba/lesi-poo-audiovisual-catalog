namespace Presentation
{
    public static class ConsoleUI
    {
        public static int StarMenu()
        {
            int? option = 0;
            bool success = false;

            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Choose an option: ");

                int count = 1;
                Console.WriteLine($"{count++} - Show full repository");
                Console.WriteLine($"{count++} - Show element by ID");
                Console.WriteLine($"{count++} - Show element by index");
                Console.WriteLine($"{count++} - Add element");
                Console.WriteLine($"{count++} - Remove element");
                Console.WriteLine($"{count++} - Remove element by ID");
                Console.WriteLine($"{count++} - Remove element by index");
                Console.WriteLine($"{count++} - Edit element");
                Console.WriteLine($"{count++} - Edit element by ID");
                Console.WriteLine($"{count++} - Edit element by index");

                Console.WriteLine("\n0 - Quit\n");

                option = ConsoleIO.ReadInt("Option: ");
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

            // nunca vai ser preciso
            // é só para não dar warning
            if (option is null)
                return 0;

            return (int)option;
        }

        public static void Pause()
        {
            Console.Write("press ENTER to continue...");
            Console.ReadKey();
        }
    }
}
