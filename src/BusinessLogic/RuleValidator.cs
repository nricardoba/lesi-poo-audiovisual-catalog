/// <file>RuleValidator.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;

namespace BusinessLogic
{
    /// <summary>
    /// File containing the project rule validation methods
    /// </summary>
    public static class RuleValidator
    {
        /// <summary>
        /// Generic method to verify whether an object is valid according to business rules.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Receives a Star object by parameters and verifies that its attributes
        /// are valid according to business rules.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsStarValid(Star? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsBirthDateValid(element.BirthDate);
        }

        /// <summary>
        /// Receives a Star DTO by parameters and verifies that its attributes
        /// are valid according to business rules.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsStarDTOValid(StarDTO? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsBirthDateValid(element.BirthDate)
                && IntegrityValidator.IsJobValid((int)element.Job);
        }

        /// <summary>
        /// Receives a Movie object by parameters and verifies that its attributes
        /// are valid according to business rules.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsMovieValid(Movie? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsMovieYearValid(element.Year)
                && IsDurationValid(element.Duration);
        }

        /// <summary>
        /// Receives a Movie DTO by parameters and verifies that its attributes
        /// are valid according to business rules.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsMovieDTOValid(MovieDTO? element)
        {
            return element is not null
                && IsNameValid(element.Name)
                && IsMovieYearValid(element.Year)
                && IsDurationValid(element.Duration)
                && IntegrityValidator.IsAgeRatingValid((int)element.AgeRating);
        }

        /// <summary>
        /// Checks whether a name is valid according to business rules.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks whether a movie year is valid according to business rules.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsMovieYearValid(int year)
        {
            return IsYearValid(year)
                && year <= Config.CurrentYear + 10;
        }

        /// <summary>
        /// Checks whether a movie duration is valid according to business rules.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static bool IsDurationValid(int duration)
        {
            return IntegrityValidator.IsMovieIntValid(duration)
                && duration <= Config.MaxDuration;
        }

        /// <summary>
        /// Checks whether a birth date is valid according to business rules.
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        public static bool IsBirthDateValid(DateOnly? birthDate)
        {
            if (birthDate is null)
                return false;

            DateOnly aux = (DateOnly)birthDate;
            return IsBirthDateValid(aux.Year, aux.Month, aux.Day);
        }

        /// <summary>
        /// Checks whether a birth date is valid according to business rules.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks whether a year is valid according to business rules.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsYearValid(int year)
        {
            return year >= Config.MinYear
                && year <= Config.CurrentYear + 100;
        }

        /// <summary>
        /// Checks whether a month is valid according to business rules.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static bool IsMonthValid(int month)
        {
            return month >= 1 && month <= 12;
        }

        /// <summary>
        /// Checks whether a day is valid according to business rules.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static bool IsDayValid(int year, int month, int day)
        {
            if (!IsYearValid(year) || !IsMonthValid(month))
                return false;

            return day > 0 && day <= DateTime.DaysInMonth(year, month);
        }
    }
}
