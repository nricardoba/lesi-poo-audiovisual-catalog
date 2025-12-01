namespace Cliffhanger
{
    public static class Config
    {
        #region Constants
        public const int DefaultId = -1;
        public const int MaxId = 999;

        public const string DefaultName = "Unknown";
        public const int StringMaxLength = 50;

        public const int MinYear = 1850;
        public static int CurrentYear = DateTime.Today.Year;
        public static int DefaultMonth = 1;
        public static int DefaultDay = 1;
        public static DateOnly DefaultDate = new DateOnly(CurrentYear, DefaultMonth, DefaultDay);

        public const int MinJobType = 0;
        public const JobType DefaultJob = JobType.Unemployed;
        public static int JobTypeLength = Enum.GetValues<JobType>().Length;
        #endregion

        #region Methods
        // perguntar ao professor se estes metodos podem estar neste ficheiro
        public static bool IsIdValid(int id)
        {
            if (id >= 0 && id <= MaxId)
                return true;
            return false;
        }

        // name or title?
        public static bool IsNameValid(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length <= StringMaxLength)
                return true;
            return false;
        }

        public static bool IsDateOfBirthValid(int year, int month, int day)
        {
            if (IsDayValid(year, month, day) && year <= CurrentYear)
                return true;
            return false;
        }

        public static bool IsJobValid(int jobNum)
        {
            if (jobNum > MinJobType && jobNum < JobTypeLength)
                return true;
            return false;
        }

        public static bool IsYearValid(int year)
        {
            if (year >= MinYear && year <= CurrentYear + 100)
                return true;
            return false;
        }

        public static bool IsMonthValid(int month)
        {
            if (month >= 1 && month <= 12)
                return true;
            return false;
        }

        public static bool IsDayValid(int year, int month, int day)
        {
            if (!IsYearValid(year) || !IsMonthValid(month))
                return false;

            if (day <= 0 || day > DateTime.DaysInMonth(year, month))
                return false;
            return true;
        }
        #endregion
    }
}
