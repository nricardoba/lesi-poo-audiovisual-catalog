/// <file>MovieService.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;

namespace BusinessLogic
{
    /// <summary>
    /// BL class to provide service methods to the Movie class
    /// </summary>
    public class MovieService
    {
        /// <summary>
        /// Validates the attributes of the DTO passed by parameters and creates a new object of type Movie.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Movie Create(string? name, int? year, int? duration, int? ageRatingNum)
        {
            if (name is null || !RuleValidator.IsNameValid(name))
                name = Config.DefaultName;

            if (year is null || !RuleValidator.IsMovieYearValid((int)year))
                year = Config.CurrentYear;

            if (duration is null || !RuleValidator.IsDurationValid((int)duration))
                duration = Config.DefaultDuration;

            ageRatingNum ??= Config.DefaultAgeRatingNum;

            return new Movie(name, (int)year, (int)duration, (int)ageRatingNum);
        }

        /// <summary>
        /// Certifies that the attributes passed by parameters are not null.
        /// Then creates a new DTO of type Movie.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="duration"></param>
        /// <param name="ageRatingNum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Based on the attributes of an object of type Movie, create a DTO clone.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static MovieDTO? Clone(Movie? element)
        {
            if (element is null)
                return null;

            return new MovieDTO(element.Id, element.Name,
                element.Year, element.Duration, element.AgeRating);
        }

        /// <summary>
        /// Attempts to edit the attributes of an object of type Movie with the attributes present in a DTO.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
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
