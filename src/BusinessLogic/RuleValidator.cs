using BusinessObjects;

namespace BusinessLogic
{
    public static class RuleValidator
    {
        public static bool IsElementValid(object element)
        {
            var elementType = element.GetType();

            if (elementType == typeof(Star))
            {
                Star aux = (Star)element;
                if (!IsNameValid(aux.Name) || !IsBirthDateValid(aux.BirthDate))
                    return false;
                return true;
            }

            return false;
        }

        public static bool IsNameValid(string text)
        {
            // se chamares isto antes de chamar o construtor, estás a quebrar o DRY
            // (ver melhor se dá para resolver)
            if (!IntegrityValidator.IsNameValid(text))
                return false;

            foreach (char c in text)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ')
                    return false;
            }

            return true;
        }

        public static bool IsBirthDateValid(DateOnly date)
        {
            return IsBirthDateValid(date.Year, date.Month, date.Day);
        }

        public static bool IsBirthDateValid(int year, int month, int day)
        {
            if (IsDayValid(year, month, day) && year <= Config.CurrentYear)
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
