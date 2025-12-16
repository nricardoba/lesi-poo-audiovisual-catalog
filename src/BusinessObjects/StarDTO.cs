namespace BusinessObjects
{
    public class StarDTO : PersonDTO
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
            set { birthDate = value; }
        }

        public JobType Job
        {
            get { return job; }
            set { job = value; }
        }
        #endregion

        #region Constructors
        public StarDTO(string name, DateOnly date, JobType job) : base(name)
        {
            birthDate = date;
            this.job = job;
        }

        public StarDTO(Guid id, string name, DateOnly date, JobType job) : base(id, name)
        {
            birthDate = date;
            this.job = job;
        }
        #endregion

        #endregion
    }
}
