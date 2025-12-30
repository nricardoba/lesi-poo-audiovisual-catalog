namespace BusinessObjects
{
    public static class Config
    {
        public const int NameMaxLength = 50;
        public const string DefaultName = "Unknown";

        public const int MinYear = 1850;
        public static readonly int CurrentYear = DateTime.Today.Year;
        public const int DefaultMonth = 1;
        public static readonly int CurrentMonth = DateTime.Today.Month;
        public const int DefaultDay = 1;
        public static readonly int CurrentDay = DateTime.Today.Day;
        public static readonly DateOnly CurrentDate = new DateOnly(CurrentYear, CurrentMonth, CurrentDay);
        public static readonly DateOnly DefaultDate = new DateOnly(CurrentYear, DefaultMonth, DefaultDay);

        public const int DefaultDuration = 120;
        public const int MaxDuration = 600;

        public const int MinEnumType = 0;

        public const JobType DefaultJob = JobType.Unemployed;
        public static readonly int JobTypeLength = Enum.GetValues<JobType>().Length;

        public const AgeRatingType DefaultAgeRating = AgeRatingType.G;
        public static readonly int AgeRatingTypeLength = Enum.GetValues<AgeRatingType>().Length;

        public const string DefaultFilePath = "src/Bin/";
        public const string StarFilePath = DefaultFilePath + "Star.bin";
    }
}
