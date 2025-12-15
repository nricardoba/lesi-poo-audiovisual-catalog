namespace BusinessObjects
{
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
                if (Validator.IsBirthDateValid(value.Year, value.Month, value.Day))
                    birthDate = value;
            }
        }

        public JobType Job
        {
            get { return job; }
            set
            {
                if (Validator.IsJobValid((int)value)) job = value;
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
            birthDate = Validator.IsBirthDateValid(date.Year, date.Month, date.Day) ? date : Config.DefaultDate;
            this.job = Validator.IsJobValid((int)job) ? job : Config.DefaultJob;
        }
        #endregion

        #region Overrides
        public override StarClone Clone()
        {
            return new StarClone(Id, Name, Birthdate, Job);
        }
        #endregion

        #region Other Methods
        #endregion

        #endregion
    }
}
