namespace BusinessObjects
{
    public enum JobType
    {
        Unemployed,
        Director,
        Writer,
        Actor
    }

    public class Star : Person
    {
        #region Attributes
        DateOnly birthDate;
        JobType job;
        #endregion

        #region Methods

        #region Properties
        public DateOnly Birthdate
        {
            get { return birthDate; }
            set
            {
                if (IsBirthDateValid(value.Year, value.Month, value.Day))
                    birthDate = value;
            }
        }

        public JobType Job
        {
            get { return job; }
            set
            {
                if (IsJobValid((int)value)) job = value;
            }
        }
        #endregion

        #region Constructors
        public Star() : base()
        {
            birthDate = Config.DefaultDate;
            job = Config.DefaultJob;
        }

        public Star(string name, DateOnly date, JobType job) : base(name)
        {
            birthDate = IsBirthDateValid(date.Year, date.Month, date.Day) ? date : Config.DefaultDate;
            this.job = IsJobValid((int)job) ? job : Config.DefaultJob;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        public static bool IsBirthDateValid(int year, int month, int day)
        {
            if (Config.IsDayValid(year, month, day) && year <= Config.CurrentYear)
                return true;
            return false;
        }

        public static bool IsJobValid(int jobNum)
        {
            if (jobNum > Config.MinJobType && jobNum < Config.JobTypeLength)
                return true;
            return false;
        }
        #endregion

        #endregion
    }
}
