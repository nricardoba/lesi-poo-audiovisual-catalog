namespace BusinessObjects
{
    public static class Config
    {
        public const int NameMaxLength = 50;
        public const string DefaultName = "Unknown";

        public const int MinYear = 1850;
        public static int CurrentYear = DateTime.Today.Year;
        public const int DefaultMonth = 1;
        public static int CurrentMonth = DateTime.Today.Month;
        public const int DefaultDay = 1;
        public static int CurrentDay = DateTime.Today.Day;
        public static DateOnly CurrentDate = new DateOnly(CurrentYear, CurrentMonth, CurrentDay);
        public static DateOnly DefaultDate = new DateOnly(CurrentYear, DefaultMonth, DefaultDay);

        public const int MinJobType = 0;
        public const JobType DefaultJob = JobType.Unemployed;
        public static int JobTypeLength = Enum.GetValues<JobType>().Length;
    }
}
