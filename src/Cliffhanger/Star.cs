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
                if (Config.IsDateOfBirthValid(value.Year, value.Month, value.Day))
                    dateOfBirth = value;
            }
        }

        public JobType Job
        {
            get { return job; }
            set
            {
                if (Config.IsJobValid((int)value)) job = value;
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
            dateOfBirth = Config.IsDateOfBirthValid(date.Year, date.Month, date.Day)
                ? date : Config.DefaultDate;

            this.job = Config.IsJobValid((int)job) ? job : Config.DefaultJob;
        }
        #endregion

        #endregion
    }
}
