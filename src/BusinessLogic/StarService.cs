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
        /// Attempts to edit the attributes of an object of type Star with the attributes present in a DTO.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool Edit(Star? element, string? name, DateOnly? birthDate, int? jobNum)
        {
            if (element is null)
                return false;

            bool success = false;

            if (name is not null && RuleValidator.IsNameValid(name))
            {
                element.Name = name;
                success = true;
            }

            if (birthDate is not null && RuleValidator.IsBirthDateValid(birthDate))
            {
                element.BirthDate = (DateOnly)birthDate;
                success = true;
            }

            if (jobNum is not null && IntegrityValidator.IsJobValid(jobNum))
            {
                element.Job = (JobType)jobNum;
                success = true;
            }

            return success;
        }
    }
}
