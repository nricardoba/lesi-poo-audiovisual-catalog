/// <file>ConsoleIO.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    /// <summary>
    /// Class with console input and output methods
    /// </summary>
    public class ConsoleIO
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
        public static bool GetStarInfo(out string? name,
            out DateOnly? birthDate, out int? jobNum)
        {
            name = ReadString("name");
            birthDate = GetDate();
            jobNum = ReadInt("job number");

            return name is null && birthDate is null
                && jobNum is null;
        }

        /// <summary>
        /// Reads information from a Movie-type object in the console.
        /// </summary>
        /// <returns></returns>
        public static bool GetMovieInfo(out string? name, out int? year,
            out int? duration, out int? ageRatingNum)
        {
            name = ReadString("name");
            year = ReadInt("year");
            duration = ReadInt("duration");
            ageRatingNum = ReadInt("age rating");

            return name is null && year is null &&
                duration is null && ageRatingNum is null;
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
