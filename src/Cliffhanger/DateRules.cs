namespace Cliffhanger
{
    public static class DateRules
    {
        public static bool IsYearValid(int year)
        {
            if (year >= Config.MinYear && year <= Config.CurrentYear + 100)
                return true;
                
            return false;
        }

        public static bool IsMonthValid(int month)
        {
            if (month >= 1 && month <= 12) return true;
            return false;
        }

        public static bool IsDayValid(int year, int month, int day)
        {
            if (!IsYearValid(year)) return false;
            if (!IsMonthValid(month)) return false;

            if (day <= 0 || day > DateTime.DaysInMonth(year, month))
                return false;

            return true;
        }
    }
}
