namespace Cliffhanger
{
    /// <summary>
    /// Class that contains the project constants.
    /// </summary>
    public static class Config
    {
        #region Person
        public const int DefaultId = -1;
        public const int MinId = 0;
        public const int MaxId = 999;

        public const string DefaultName = "Unknown";
        public const int StringMinLength = 2;
        public const int StringMaxLength = 50;
        #endregion

        #region Star
        public const int MinYear = 1850;
        public static int CurrentYear = DateTime.Today.Year;
        public static DateOnly DefaultDate = new DateOnly(CurrentYear, 1, 1);

        public const int MinJobType = 0;
        public const JobType DefaultJob = JobType.Unemployed;
        public static int JobTypeLength = Enum.GetValues<JobType>().Length;
        #endregion

        #region User
        public const int MinAccountType = 0;
        public const AccountType DefaultAccount = AccountType.Normal;
        public static int AccountTypeLength = Enum.GetValues<AccountType>().Length;
        #endregion
    }
}
