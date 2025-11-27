using System.Reflection;

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
                if (IsYearValid(value.Year)) dateOfBirth = value;
            }
        }

        public JobType Job
        {
            get { return job; }
            set
            {
                if (IsJobValid(value)) job = value;
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
            if (IsYearValid(date.Year)) dateOfBirth = date;
            else dateOfBirth = Config.DefaultDate;

            if (IsJobValid(job)) this.job = job;
            else this.job = Config.DefaultJob;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        public static bool IsYearValid(int year)
        {
            if (year >= Config.MinYear && year <= Config.CurrentYear)
                return true;
            return false;
        }

        public static bool IsMonthValid(int month)
        {
            if (month >= 1 && month <= 12) return true;
            return false;
        }

        public static bool IsDayValid(int year, int month, int day)
        {
            if (!IsYearValid(year)) return false;
            if (!IsMonthValid(month)) return false;

            if (day <= 0 || day > DateTime.DaysInMonth(year, month))
                return false;

            return true;
        }
        
        public static bool IsJobValid(JobType job)
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
