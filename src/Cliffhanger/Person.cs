namespace Cliffhanger
{
    /// <summary>
    /// Abstract class to serve as a model for classes like Actor.
    /// </summary>
    public abstract class Person
    {
        #region Constants
        protected const string DefaultName = "Unknown";
        const int StringMaxLength = 50;

        // eu não quero que uma pessoa possa mudar! (ver como melhorar)
        static int CurrentYear = DateTime.Today.Year;
        const int MinYear = 1850;
        const int DefaultYear = 1950;
        const int DefaultMonth = 1;
        const int DefaultDay = 1;
        #endregion

        // um ator tambem pode ser um escritor ou realizador, depois ver melhor esta parte
        #region Attributes
        string name = string.Empty;
        DateOnly dateOfBirth;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property of attribute name.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (CheckName(value)) name = value;
            }
        }

        /// <summary>
        /// Property of attribute dateOfBirth.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public DateOnly DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (CheckDate(value.Year, value.Month, value.Day))
                {
                    dateOfBirth = value;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor of class Person.
        /// Assigns the default values.
        /// </summary>
        protected Person()
        {
            name = DefaultName;
            dateOfBirth = new DateOnly(DefaultYear, DefaultMonth, DefaultDay);
        }

        /// <summary>
        /// Constructor with all the parameters of class Person.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        protected Person(string name, int year, int month, int day)
        {
            if (CheckName(name))
            {
                this.name = name;
            }
            else
            {
                this.name = DefaultName;
            }

            if (CheckDate(year, month, day))
            {
                dateOfBirth = new DateOnly(year, month, day);
            }
            else
            {
                dateOfBirth = new DateOnly(DefaultYear, DefaultMonth, DefaultDay);
            }
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Signature of method ShowInformation.
        /// </summary>
        public abstract void ShowInformation();
        #endregion

        #region Other Methods
        /// <summary>
        /// Checks if a name is valid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// If the name is valid, returns true if it is invalid, returns false.
        /// </returns>
        protected static bool CheckName(string name)
        {
            if (name.Length < StringMaxLength)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a date is valid.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>
        /// If the date is valid, returns true if it is invalid, returns false.
        /// </returns>
        static bool CheckDate(int year, int month, int day)
        {
            if (year <= MinYear || year > CurrentYear)
            {
                return false;
            }

            if (month < 1 || month > 12)
            {
                return false;
            }

            int aux = DateTime.DaysInMonth(year, month);
            if (day < 1 || day > aux)
            {
                return false;
            }

            return true;
        }
        #endregion

        #endregion
    }
}
