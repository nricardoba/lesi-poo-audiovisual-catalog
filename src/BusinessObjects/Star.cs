namespace BusinessObjects
{
    /// <summary>
    /// Class containing information about a movie star
    /// </summary>
    public class Star : Identifier
    {
        #region Attributes
        DateOnly birthDate;
        JobType job;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property of attribute birthDate.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public DateOnly BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        /// <summary>
        /// Property of attribute job.
        /// If the variable value is valid, it's assigned.
        /// </summary>
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
        /// <summary>
        /// Default constructor.
        /// Assigns the default values.
        /// </summary>
        public Star() : base()
        {
            birthDate = Config.DefaultDate;
            job = Config.DefaultJob;
        }

        /// <summary>
        /// Constructor with all the parameters.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="job"></param>
        public Star(string name, DateOnly birthDate, JobType job)
            : base(name)
        {
            this.birthDate = birthDate;
            this.job = IntegrityValidator.IsJobValid((int)job)
                ? job : Config.DefaultJob;
        }

        /// <summary>
        /// This constructor will only be called when manipulating binary files.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="job"></param>
        public Star(Guid id, string name, DateOnly birthDate, JobType job)
            : base(id, name)
        {
            this.birthDate = birthDate;
            this.job = IntegrityValidator.IsJobValid((int)job)
                ? job : Config.DefaultJob;
        }
        #endregion

        #endregion
    }
}
