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
                if (IsDateValid(value.Year, value.Month, value.Day))
                    dateOfBirth = value;
            }
        }

        public JobType Job
        {
            get { return job; }
            set
            {
                if (IsJobValid(value)) job = value;
            }
        }
        #endregion

        #region Constructors
        public Star() : base()
        {
            dateOfBirth = Config.DefaultDate;
            job = Config.DefaultJob;
        }

        public Star(int id, string name, DateOnly date, JobType job) : base(id, name)
        {
            if (IsDateValid(date.Year, date.Month, date.Day)) dateOfBirth = date;
            else dateOfBirth = Config.DefaultDate;

            if (IsJobValid(job)) this.job = job;
            else this.job = Config.DefaultJob;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        public static bool IsDateValid(int year, int month, int day)
        {
            if (!DateRules.IsYearValid(year) || year > Config.CurrentYear) return false;
            if (!DateRules.IsMonthValid(month)) return false;
            if (!DateRules.IsDayValid(year, month, day)) return false;

            return true;
        }
        
        public static bool IsJobValid(JobType job)
        {
            int aux = (int)job;
            if (aux > Config.MinJobType && aux < Config.JobTypeLength)
                return true;
            return false;
        }
        #endregion
        
        #endregion
    }
}
