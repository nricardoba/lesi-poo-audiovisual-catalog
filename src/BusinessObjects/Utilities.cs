namespace BusinessObjects
{
    public static class Utilities
    {
        // d1 -> Data "atual"
        // d2 -> Data "referencia"

        // se for para calcular um aniversário,
        // d1 é a data atual, d2 é a data de nascimento
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

        public static int GetAge(DateOnly birthDate)
        {
            return GetYearGap(Config.CurrentDate, birthDate);
        }

        public static JobType? ConvertToJob(int? jobNum)
        {
            if (jobNum is null || !IntegrityValidator.IsJobValid((int)jobNum))
                return null;

            return (JobType)jobNum;
        }
    }
}
