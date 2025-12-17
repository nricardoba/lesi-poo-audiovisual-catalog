namespace BusinessObjects
{
    public static class IntegrityValidator
    {
        public static bool IsNameOrTitleValid(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length > Config.NameMaxLength)
                return false;
            return true;
        }

        public static bool IsJobValid(int jobNum)
        {
            if (jobNum > Config.MinJobType && jobNum < Config.JobTypeLength)
                return true;
            return false;
        }
    }
}
