using BusinessObjects;

namespace BusinessLogic
{
    public static class StarService
    {
        // é neste metodo que podes criar o novo ID
        // (se usares a abordagem do ID aleatorio como int)
        public static Star Create(string? name, DateOnly? birthDate, int? jobNum)
        {
            if (name is null || !RuleValidator.IsNameValid(name))
                name = Config.DefaultName;

            if (birthDate is null || !RuleValidator.IsBirthDateValid(birthDate))
                birthDate = Config.DefaultDate;

            JobType? job = ExtensionMethods.ConvertToJob(jobNum);
            if (job is null)
                job = Config.DefaultJob;

            return new Star(name, (DateOnly)birthDate, (JobType)job);
        }
    }
}
