using BusinessObjects;

namespace BusinessLogic
{
    public static class StarService
    {
        public static Star Create(StarDTO dto)
        {
            string name = RuleValidator.IsNameValid(dto.Name)
                ? dto.Name : Config.DefaultName;

            DateOnly birthDate = RuleValidator.IsBirthDateValid(dto.BirthDate)
                ? dto.BirthDate : Config.DefaultDate;

            JobType job = dto.Job;

            return new Star(name, birthDate, job);
        }

        public static StarDTO CreateDTO(string? name, DateOnly? birthDate, int? jobNum)
        {
            string auxName = name ?? Config.DefaultName;
            DateOnly auxBirthDate = birthDate ?? Config.DefaultDate;
            JobType auxJob = Config.DefaultJob;

            if (jobNum is not null)
                auxJob = (JobType)jobNum;

            return new StarDTO(auxName, auxBirthDate, auxJob);
        }

        public static StarDTO? Clone(Star? element)
        {
            if (element is null)
                return null;

            return new StarDTO(element.Id, element.Name,
                element.BirthDate, element.Job);
        }

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
