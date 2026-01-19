/// <file>StarService.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;

namespace BusinessLogic
{
    /// <summary>
    /// BL class to provide service methods to the Star class
    /// </summary>
    public class StarService
    {
        /// <summary>
        /// Validates the attributes of the DTO passed by parameters and creates a new object of type Star.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Star Create(string? name, DateOnly? birthDate, int? jobNum)
        {
            if (name is null || !RuleValidator.IsNameValid(name))
                name = Config.DefaultName;

            if (birthDate is null || !RuleValidator.IsBirthDateValid(birthDate))
                birthDate = Config.DefaultDate;

            jobNum ??= Config.DefaultJobNum;

            return new Star(name, (DateOnly)birthDate, (int)jobNum);
        }

        /// <summary>
        /// Certifies that the attributes passed by parameters are not null.
        /// Then creates a new DTO of type Star.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="jobNum"></param>
        /// <returns></returns>
        public static StarDTO CreateDTO(string? name, DateOnly? birthDate, int? jobNum)
        {
            string auxName = name ?? Config.DefaultName;
            DateOnly auxBirthDate = birthDate ?? Config.DefaultDate;
            JobType auxJob = Config.DefaultJob;

            if (jobNum is not null)
                auxJob = (JobType)jobNum;

            return new StarDTO(auxName, auxBirthDate, auxJob);
        }

        /// <summary>
        /// Based on the attributes of an object of type Star, create a DTO clone.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static StarDTO? Clone(Star? element)
        {
            if (element is null)
                return null;

            return new StarDTO(element.Id, element.Name,
                element.BirthDate, element.Job);
        }

        /// <summary>
        /// Attempts to edit the attributes of an object of type Star with the attributes present in a DTO.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool Edit(Star? element, StarDTO? dto)
        {
            if (element is null || dto is null)
                return false;

            bool success = false;

            if (RuleValidator.IsNameValid(dto.Name))
            {
                element.Name = dto.Name;
                success = true;
            }

            if (RuleValidator.IsBirthDateValid(dto.BirthDate))
            {
                element.BirthDate = dto.BirthDate;
                success = true;
            }

            if (IntegrityValidator.IsJobValid((int)dto.Job))
            {
                element.Job = dto.Job;
                success = true;
            }

            return success;
        }
    }
}
