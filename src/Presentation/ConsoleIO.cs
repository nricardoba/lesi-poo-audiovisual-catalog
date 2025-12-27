using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class ConsoleIO
    {
        public static string? ReadString(string message)
        {
            Console.Write("Enter the " + message + ": ");
            return Console.ReadLine();
        }

        public static int? ReadInt(string message)
        {
            string? input = ReadString(message);

            if (!int.TryParse(input, out int num))
                return null;

            return num;
        }

        public static DateOnly? GetDate()
        {
            const int InvalidNum = 0;

            int? input = ReadInt("year");
            int year = input ?? InvalidNum;

            input = ReadInt("month");
            int month = input ?? InvalidNum;

            input = ReadInt("day");
            int day = input ?? InvalidNum;

            try
            {
                return new DateOnly(year, month, day);
            }
            catch
            {
                return null;
            }
        }
    }
}
