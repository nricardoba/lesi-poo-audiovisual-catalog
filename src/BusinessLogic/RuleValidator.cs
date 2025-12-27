using BusinessObjects;

namespace BusinessLogic
{
    public static class RuleValidator
    {
        public static bool IsElementValid(object? element)
        {
            if (element is null)
                return false;

            var elementType = element.GetType();

            if (elementType == typeof(Star))
                return IsStarValid((Star)element);

            // vais adicionando tipos de objetos...

            return false;
        }

        public static bool IsStarValid(Star? element)
        {
            if (element is null)
                return false;

            if (!IsNameValid(element.Name)
                || !IsBirthDateValid(element.BirthDate))
                return false;

            return true;
        }

        public static bool IsNameValid(string? name)
        {
            // se chamares isto antes de chamar o construtor, estás a quebrar o DRY
            // (ver melhor se dá para resolver)
            if (name is null || !IntegrityValidator.IsNameValid(name))
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ')
                    return false;
            }

            return true;
        }

        public static bool IsBirthDateValid(DateOnly? birthDate)
        {
            if (birthDate is null)
                return false;

            DateOnly aux = (DateOnly)birthDate;
            return IsBirthDateValid(aux.Year, aux.Month, aux.Day);
        }

        public static bool IsBirthDateValid(int year, int month, int day)
        {
            if (!IsDayValid(year, month, day))
                return false;

            if (year > Config.CurrentYear)
                return false;

            if (year == Config.CurrentYear)
            {
                if (month > Config.CurrentMonth)
                    return false;

                if (month == Config.CurrentMonth
                    && day > Config.CurrentDay)
                    return false;
            }

            return true;
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
