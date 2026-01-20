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
        /// Attempts to edit the attributes of an object of type Movie with the attributes present in a DTO.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool Edit(Movie? element, string? name, int? year, int? duration, int? ageRatingNum)
        {
            if (element is null)
                return false;

            bool success = false;

            if (name is not null && RuleValidator.IsNameValid(name))
            {
                element.Name = name;
                success = true;
            }

            if (year is not null && RuleValidator.IsMovieYearValid(year))
            {
                element.Year = (int)year;
                success = true;
            }

            if (duration is not null && RuleValidator.IsDurationValid(duration))
            {
                element.Duration = (int)duration;
                success = true;
            }

            if (ageRatingNum is not null && IntegrityValidator.IsAgeRatingValid(ageRatingNum))
            {
                element.AgeRating = (AgeRatingType)ageRatingNum;
                success = true;
            }

            return success;
        }
    }
}
