namespace BusinessObjects
{
    public static class Validator
    {
        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > Config.NameMaxLength)
                return false;
            return true;
        }

        public static bool IsBirthDateValid(int year, int month, int day)
        {
            if (IsDayValid(year, month, day) && year <= Config.CurrentYear)
                return true;
            return false;
        }

        public static bool IsJobValid(int jobNum)
        {
            if (jobNum > Config.MinJobType && jobNum < Config.JobTypeLength)
                return true;
            return false;
        }

        public static bool IsYearValid(int year)
        {
            if (year >= Config.MinYear && year <= Config.CurrentYear + 100)
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
    }
}
