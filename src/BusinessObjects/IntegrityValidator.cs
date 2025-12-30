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
            if (jobNum >= Config.MinEnumType && jobNum < Config.JobTypeLength)
                return true;
            return false;
        }

        public static bool IsAgeRatingValid(int ageRatingNum)
        {
            if (ageRatingNum >= Config.MinEnumType && ageRatingNum < Config.AgeRatingTypeLength)
                return true;
            return false;
        }

        public static bool IsMovieIntValid(int num)
        {
            return num > 0;
        }
    }
}
