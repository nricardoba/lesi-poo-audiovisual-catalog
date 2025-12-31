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
        public DateOnly BirthDate
        {
            get { return birthDate; }
        }

        public JobType Job
        {
            get { return job; }
        }
        #endregion

        #region Constructors
        public StarDTO(Guid id, string name, DateOnly birthDate, JobType job)
            : base(id, name)
        {
            this.birthDate = birthDate;
            this.job = job;
        }

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
