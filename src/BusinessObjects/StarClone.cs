namespace BusinessObjects
{
    public class StarClone : PersonClone
    {
        #region Attributes
        readonly DateOnly birthDate;
        readonly JobType job;
        #endregion

        #region Methods

        #region Properties
        public DateOnly Birthdate
        {
            get { return birthDate; }
        }

        public JobType Job
        {
            get { return job; }
        }
        #endregion

        #region Constructors
        public StarClone(Guid id, string name, DateOnly date, JobType job) : base(id, name)
        {
            birthDate = date;
            this.job = job;
        }
        #endregion

        #endregion
    }
}
