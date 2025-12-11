namespace BusinessObjects
{
    public static class Config
    {
        #region Constants
        public const int NameMaxLength = 50;
        public const string DefaultName = "Unknown";

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
        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > NameMaxLength)
                return false;
            return true;
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
