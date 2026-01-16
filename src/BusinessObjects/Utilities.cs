/// <file>Utilities.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

namespace BusinessObjects
{
    /// <summary>
    /// File with the project's utility methods
    /// </summary>
    public static class Utilities
    {
        // d1 -> Data "atual"
        // d2 -> Data "referencia"

        // se for para calcular um aniversário,
        // d1 é a data atual, d2 é a data de nascimento

        /// <summary>
        /// Method that receives two dates and calculates the gap in years.
        /// If it is greater than 0, it means that x years have passed from the first date to the second date.
        /// If it is less than 0, it means that x years remain from the first date to the second date.
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static int GetYearGap(DateOnly d1, DateOnly d2)
        {
            // gap > 0 -> Passaram gap anos
            // gap < 0 -> Faltam gap anos
            // gap = 0 -> Faltam ou Passaram 0 anos
            int gap = d1.Year - d2.Year;

            if (gap > 0)
            {
                if (d1.Month < d2.Month
                    || (d1.Month == d2.Month && d1.Day < d2.Day))
                    gap--;
            }
            else if (gap < 0)
            {
                if (d1.Month > d2.Month
                    || (d1.Month == d2.Month && d1.Day > d2.Day))
                    gap++;
            }

            return gap;
        }

        /// <summary>
        /// Use the GetYearGap method to compare the date received by parameters with the current date.
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        public static int GetAge(DateOnly birthDate)
        {
            return GetYearGap(Config.CurrentDate, birthDate);
        }

        /// <summary>
        /// Receives a int value associated with an Enum JobType value and, if valid, converts it to JobType.
        /// </summary>
        /// <param name="jobNum"></param>
        /// <returns></returns>
        public static JobType? ConvertToJob(int? jobNum)
        {
            if (jobNum is null || !IntegrityValidator.IsJobValid((int)jobNum))
                return null;

            return (JobType)jobNum;
        }
    }
}
