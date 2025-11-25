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
                if (IsValidDate(value)) dateOfBirth = value;
            }
        }

        // isto é necessario, pois se alguem tentar fazer 'Job = (JobType)7', vai dar erro
        public JobType Job
        {
            get { return job; }
            set
            {
                if (IsValidJob(value)) job = value;
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
            if (IsValidDate(date)) dateOfBirth = date;
            else dateOfBirth = Config.DefaultDate;

            if (IsValidJob(job)) this.job = job;
            else this.job = Config.DefaultJob;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        static bool IsValidDate(DateOnly date)
        {
            if (date.Year >= Config.MinYear && date.Year <= Config.CurrentYear)
                return true;
            return false;
        }
        
        static bool IsValidJob(JobType job)
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
