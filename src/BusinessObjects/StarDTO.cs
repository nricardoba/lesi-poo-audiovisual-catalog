namespace BusinessObjects
{
    /// <summary>
    /// Data Transfer Object of Star class
    /// </summary>
    public class StarDTO : IdentifierDTO
    {
        #region Attributes
        readonly DateOnly birthDate;
        readonly JobType job;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property of attribute birthDate.
        /// Just returns the value of the attribute.
        /// </summary>
        public DateOnly BirthDate
        {
            get { return birthDate; }
        }

        /// <summary>
        /// Property of attribute job.
        /// Just returns the value of the attribute.
        /// </summary>
        public JobType Job
        {
            get { return job; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor to be used for clones.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="job"></param>
        public StarDTO(Guid id, string name, DateOnly birthDate, JobType job)
            : base(id, name)
        {
            this.birthDate = birthDate;
            this.job = job;
        }

        /// <summary>
        /// Constructor to be used to edit attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="job"></param>
        public StarDTO(string name, DateOnly birthDate, JobType job)
            : base(name)
        {
            this.birthDate = birthDate;
            this.job = job;
        }
        #endregion

        #endregion
    }
}
