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
        public DateOnly BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public JobType Job
        {
            get { return job; }
            set
            {
                if (IntegrityValidator.IsJobValid((int)value))
                    job = value;
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
            birthDate = date;
            this.job = IntegrityValidator.IsJobValid((int)job)
                ? job : Config.DefaultJob;
        }
        #endregion

        #region Overrides
        public override StarDTO Clone()
        {
            return new StarDTO(Id, Name, BirthDate, Job);
        }
        #endregion

        #region Other Methods
        // se a data for superior à data atual, o metodo devolve -1
        public int GetAge()
        {
            // Invalid
            int InvalidValue = -1;
            if (birthDate.Year > Config.CurrentYear)
                return InvalidValue;

            if (birthDate.Year == Config.CurrentYear)
            {
                if (birthDate.Month > Config.CurrentMonth)
                    return InvalidValue;

                if (birthDate.Month == Config.CurrentMonth
                    && birthDate.Day > Config.CurrentDay)
                    return InvalidValue;
            }

            // Valid
            int age = Config.CurrentYear - birthDate.Year;
            if (birthDate.Month > Config.CurrentMonth
                || (birthDate.Month == Config.CurrentMonth
                && birthDate.Day > Config.CurrentDay))
                age--;

            return age;
        }
        #endregion

        #endregion
    }
}
