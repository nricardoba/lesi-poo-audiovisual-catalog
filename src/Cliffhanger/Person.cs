namespace Cliffhanger
{
    public abstract class Person
    {
        #region Attributes
        int id;
        string name;
        #endregion

        #region Methods

        #region Properties
        public int Id
        {
            get { return id; }
            set
            {
                if (IsIdValid(value)) id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (IsNameValid(value)) name = value;
            }
        }
        #endregion

        #region Constructors
        public Person()
        {
            id = Config.DefaultId;
            name = Config.DefaultName;
        }

        public Person(string name)
        {
            id = Config.DefaultId;

            if (IsNameValid(name)) this.name = name;
            else this.name = Config.DefaultName;
        }
        #endregion

        #region Other Methods
        public static bool IsIdValid(int id)
        {
            if (id >= Config.MinId && id <= Config.MaxId)
                return true;
            
            return false;
        }

        public static bool IsNameValid(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length <= Config.StringMaxLength)
                return true;
                
            return false;
        }
        #endregion

        #endregion
    }
}
