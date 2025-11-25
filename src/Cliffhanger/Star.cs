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
            dateOfBirth = ProgramConfig.DefaultDate;
            job = ProgramConfig.DefaultJob;
        }

        public Star(int id, string name, DateOnly date, JobType job) : base(id, name)
        {
            if (IsValidDate(date)) dateOfBirth = date;
            else dateOfBirth = ProgramConfig.DefaultDate;

            if (IsValidJob(job)) this.job = job;
            else this.job = ProgramConfig.DefaultJob;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        static bool IsValidDate(DateOnly date)
        {
            if (date.Year >= ProgramConfig.MinYear && date.Year <= ProgramConfig.CurrentYear)
                return true;
            return false;
        }
        
        static bool IsValidJob(JobType job)
        {
            int aux = (int)job;
            if (aux > ProgramConfig.MinJobType && aux < ProgramConfig.JobTypeLength)
                return true;
            return false;
        }
        #endregion
        
        #endregion
    }
}
