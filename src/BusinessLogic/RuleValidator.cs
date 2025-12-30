using BusinessObjects;

namespace BusinessLogic
{
    public static class RuleValidator
    {
        public static bool IsElementValid(object? element)
        {
            if (element is Star auxStar)
                return IsStarValid(auxStar);

            if (element is StarDTO auxStarDTO)
                return IsStarDTOValid(auxStarDTO);

            if (element is Movie auxMovie)
                return IsMovieValid(auxMovie);

            if (element is MovieDTO auxMovieDTO)
                return IsMovieDTOValid(auxMovieDTO);

            // vais adicionando tipos de objetos...

            return false;
        }

        public static bool IsStarValid(Star? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsBirthDateValid(element.BirthDate);
        }

        public static bool IsStarDTOValid(StarDTO? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsBirthDateValid(element.BirthDate)
                && IntegrityValidator.IsJobValid((int)element.Job);
        }

        public static bool IsMovieValid(Movie? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsMovieYearValid(element.Year)
                && IsDurationValid(element.Duration);
        }

        public static bool IsMovieDTOValid(MovieDTO? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsMovieYearValid(element.Year)
                && IsDurationValid(element.Duration)
                && IntegrityValidator.IsAgeRatingValid((int)element.AgeRating);
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

        public static bool IsMovieYearValid(int year)
        {
            return IsYearValid(year)
                && year <= Config.CurrentYear + 10;
        }

        public static bool IsDurationValid(int duration)
        {
            return IntegrityValidator.IsMovieIntValid(duration)
                && duration <= Config.MaxDuration;
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
            return year >= Config.MinYear
                && year <= Config.CurrentYear + 100;
        }

        public static bool IsMonthValid(int month)
        {
            return month >= 1 && month <= 12;
        }

        public static bool IsDayValid(int year, int month, int day)
        {
            if (!IsYearValid(year) || !IsMonthValid(month))
                return false;

            return day > 0 && day <= DateTime.DaysInMonth(year, month);
        }
    }
}
