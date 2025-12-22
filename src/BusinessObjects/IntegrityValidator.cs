namespace BusinessObjects
{
    public static class IntegrityValidator
    {
        public static bool IsNameValid(string? name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > Config.NameMaxLength)
                return false;
            return true;
        }

        public static bool IsJobValid(int jobNum)
        {
            if (jobNum >= Config.MinJobType && jobNum < Config.JobTypeLength)
                return true;
            return false;
        }
    }
}
