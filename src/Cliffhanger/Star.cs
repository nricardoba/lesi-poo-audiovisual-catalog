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
        #region Constants
        const int MinYear = 1850;
        static int CurrentYear = DateTime.Today.Year;
        static DateOnly DefaultDate = new DateOnly(CurrentYear, 1, 1);

        const JobType DefaultJob = JobType.Unemployed;
        static int JobTypeLength = Enum.GetValues<JobType>().Length;
        #endregion

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
            dateOfBirth = DefaultDate;
            job = DefaultJob;
        }

        public Star(int id, string name, DateOnly date, JobType job) : base(id, name)
        {
            if (IsValidDate(date)) dateOfBirth = date;
            else dateOfBirth = DefaultDate;

            if (IsValidJob(job)) this.job = job;
            else this.job = DefaultJob;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        static bool IsValidDate(DateOnly date)
        {
            if (date.Year > MinYear && date.Year <= CurrentYear) return true;
            return false;
        }
        
        static bool IsValidJob(JobType job)
        {
            int aux = (int)job;
            if (aux > 0 && aux < JobTypeLength) return true;
            return false;
        }
        #endregion
        
        #endregion
    }
}
