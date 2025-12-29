namespace BusinessObjects
{
    public class Star : Identifier
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

        public Star(string name, DateOnly birthDate, JobType job) : base(name)
        {
            this.birthDate = birthDate;
            this.job = IntegrityValidator.IsJobValid((int)job)
                ? job : Config.DefaultJob;
        }

        // este contrutor só vai ser chamado ao ler ficheiros binarios
        public Star(Guid id, string name, DateOnly birthDate, JobType job) : base(id, name)
        {
            this.birthDate = birthDate;
            this.job = IntegrityValidator.IsJobValid((int)job)
                ? job : Config.DefaultJob;
        }
        #endregion

        #endregion
    }
}
