namespace BusinessObjects
{
    public static class IntegrityValidator
    {
        public static bool IsNameValid(string? name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && name.Length <= Config.NameMaxLength;
        }

        public static bool IsJobValid(int jobNum)
        {
            return jobNum >= Config.MinEnumType
                && jobNum < Config.JobTypeLength;
        }

        public static bool IsAgeRatingValid(int ageRatingNum)
        {
            return ageRatingNum >= Config.MinEnumType
                && ageRatingNum < Config.AgeRatingTypeLength;
        }

        public static bool IsMovieIntValid(int num)
        {
            return num > 0;
        }
    }
}
