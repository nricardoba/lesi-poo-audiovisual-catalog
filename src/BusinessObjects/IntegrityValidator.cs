namespace BusinessObjects
{
    /// <summary>
    /// File containing the project integrity validation methods
    /// </summary>
    public static class IntegrityValidator
    {
        /// <summary>
        /// Receives a string referring to a name as a parameter and verifies that its integrity is valid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsNameValid(string? name)
        {
            return !string.IsNullOrWhiteSpace(name)
                && name.Length <= Config.NameMaxLength;
        }

        /// <summary>
        /// Receives a int referring to a job number as a parameter and verifies that its integrity is valid.
        /// </summary>
        /// <param name="jobNum"></param>
        /// <returns></returns>
        public static bool IsJobValid(int jobNum)
        {
            return jobNum >= Config.MinEnumType
                && jobNum < Config.JobTypeLength;
        }

        /// <summary>
        /// Receives a int referring to a age rating number as a parameter and verifies that its integrity is valid.
        /// </summary>
        /// <param name="ageRatingNum"></param>
        /// <returns></returns>
        public static bool IsAgeRatingValid(int ageRatingNum)
        {
            return ageRatingNum >= Config.MinEnumType
                && ageRatingNum < Config.AgeRatingTypeLength;
        }

        /// <summary>
        /// Receives an int and verifies that its integrity is valid in the context of the Movie class.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsMovieIntValid(int num)
        {
            return num > 0;
        }
    }
}
