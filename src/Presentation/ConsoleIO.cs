using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class ConsoleIO
    {
        public static string? ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int? ReadInt(string message)
        {
            string? input = ReadString(message);

            if (!int.TryParse(input, out int num))
                return null;

            return num;
        }

        public static DateOnly? GetDate(string message)
        {
            const int InvalidNum = 0;

            int? input = ReadInt(message + " year: ");
            int year = input ?? InvalidNum;

            input = ReadInt(message + " month: ");
            int month = input ?? InvalidNum;

            input = ReadInt(message + " day: ");
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
