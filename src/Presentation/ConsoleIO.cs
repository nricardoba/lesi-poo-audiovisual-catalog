using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    /// <summary>
    /// Class with console input and output methods
    /// </summary>
    public static class ConsoleIO
    {
        /// <summary>
        /// Reads a string from the console.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string? ReadString(string message)
        {
            Console.Write("Enter the " + message + ": ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Reads an int from the console.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int? ReadInt(string message)
        {
            string? input = ReadString(message);

            if (!int.TryParse(input, out int num))
                return null;

            return num;
        }

        /// <summary>
        /// Reads information from a Star-type object in the console.
        /// </summary>
        /// <returns></returns>
        public static StarDTO GetStarInfo()
        {
            string? name = ReadString("name");
            DateOnly? birthDate = GetDate();
            int? jobNum = ReadInt("job number");

            return StarService.CreateDTO(name, birthDate, jobNum);
        }

        /// <summary>
        /// Reads information from a Movie-type object in the console.
        /// </summary>
        /// <returns></returns>
        public static MovieDTO GetMovieInfo()
        {
            string? name = ReadString("name");
            int? year = ReadInt("year");
            int? duration = ReadInt("duration");
            int? ageRatingNum = ReadInt("age rating");

            return MovieService.CreateDTO(name, year, duration, ageRatingNum);
        }

        /// <summary>
        /// Reads a string from the console and attempts to convert it to a Guid referring to an id.
        /// </summary>
        /// <returns></returns>
        public static Guid? GetId()
        {
            string? input = ReadString("ID");

            if (!Guid.TryParse(input, out Guid id))
                return null;

            return id;
        }

        /// <summary>
        /// Reads information about a date from the console.
        /// </summary>
        /// <returns></returns>
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
