namespace Cliffhanger
{
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
        public string Name
        {
            get { return name; }
            set
            {
                if (CheckName(value)) name = value;
            }
        }

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
        protected Person()
        {
            name = DefaultName;
            dateOfBirth = new DateOnly(DefaultYear, DefaultMonth, DefaultDay);
        }

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
        public abstract void ShowInformation();
        #endregion

        #region Other Methods
        protected static bool CheckName(string name)
        {
            if (name.Length < StringMaxLength)
            {
                return true;
            }
            return false;
        }

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
