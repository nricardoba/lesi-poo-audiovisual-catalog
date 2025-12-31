using BusinessObjects;

namespace BusinessLogic
{
    /// <summary>
    /// BL class to provide service methods to the Movie class
    /// </summary>
    public static class MovieService
    {
        public static Movie Create(MovieDTO dto)
        {
            string name = RuleValidator.IsNameValid(dto.Name)
                ? dto.Name : Config.DefaultName;

            int year = RuleValidator.IsMovieYearValid(dto.Year)
                ? dto.Year : Config.CurrentYear;

            int duration = RuleValidator.IsDurationValid(dto.Duration)
                ? dto.Duration : Config.DefaultDuration;

            AgeRatingType ageRating = dto.AgeRating;

            return new Movie(name, year, duration, ageRating);
        }

        public static MovieDTO CreateDTO(string? name, int? year,
            int? duration, int? ageRatingNum)
        {
            string auxName = name ?? Config.DefaultName;
            int auxYear = year ?? Config.CurrentYear;
            int auxDuration = duration ?? Config.DefaultDuration;
            AgeRatingType auxAgeRating = Config.DefaultAgeRating;

            if (ageRatingNum is not null)
                auxAgeRating = (AgeRatingType)ageRatingNum;

            return new MovieDTO(auxName, auxYear, auxDuration, auxAgeRating);
        }

        public static MovieDTO? Clone(Movie? element)
        {
            if (element is null)
                return null;

            return new MovieDTO(element.Id, element.Name,
                element.Year, element.Duration, element.AgeRating);
        }

        public static bool Edit(Movie? element, MovieDTO? dto)
        {
            if (element is null || dto is null)
                return false;

            bool success = false;

            if (RuleValidator.IsNameValid(dto.Name))
            {
                element.Name = dto.Name;
                success = true;
            }

            if (RuleValidator.IsMovieYearValid(dto.Year))
            {
                element.Year = dto.Year;
                success = true;
            }

            if (RuleValidator.IsDurationValid(dto.Duration))
            {
                element.Duration = dto.Duration;
                success = true;
            }

            if (IntegrityValidator.IsAgeRatingValid((int)dto.AgeRating))
            {
                element.AgeRating = dto.AgeRating;
                success = true;
            }

            return success;
        }
    }
}
