namespace Cliffhanger
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
        DateOnly dateOfBirth;
        JobType job;
        #endregion
        
        #region Methods
        
        #region Properties
        public DateOnly DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (IsDateOfBirthValid(value.Year, value.Month, value.Day))
                    dateOfBirth = value;
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
            dateOfBirth = Config.DefaultDate;
            job = Config.DefaultJob;
        }

        public Star(string name, DateOnly date, JobType job) : base(name)
        {
            if (IsDateOfBirthValid(date.Year, date.Month, date.Day)) dateOfBirth = date;
            else dateOfBirth = Config.DefaultDate;

            if (IsJobValid((int)job)) this.job = job;
            else this.job = Config.DefaultJob;
        }
        #endregion

        #region Other Methods
        public static bool IsDateOfBirthValid(int year, int month, int day)
        {
            if (year > Config.CurrentYear) return false;
            if (!DateRules.IsDayValid(year, month, day)) return false;

            return true;
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
