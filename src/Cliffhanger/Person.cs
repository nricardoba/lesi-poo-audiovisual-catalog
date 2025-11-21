namespace Cliffhanger
{
    public abstract class Person
    {
        #region Constants
        const int DefaultId = -1;
        const int MaxId = 999;

        const string DefaultName = "Unknown";
        const int StringMaxLength = 50;
        #endregion

        #region Attributes
        int id;
        string name = string.Empty;
        #endregion

        #region Methods

        #region Properties
        // se estas forem protected, ver se dá para usar no main com a class filha
        public int Id
        {
            get { return id; }
            set
            {
                if (CheckId(value)) id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (CheckName(value)) name = value;
            }
        }
        #endregion

        #region Constructors
        public Person()
        {
            id = DefaultId;
            name = DefaultName;
        }

        public Person(int id, string name)
        {
            if (CheckId(id)) this.id = id;
            else this.id = DefaultId;

            if (CheckName(name)) this.name = name;
            else this.name = DefaultName;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        // protected?
        static bool CheckId(int id)
        {
            if (id > 0 && id <= MaxId) return true;
            return false;
        }

        // não tenho a certeza se as posso usar no constructor e nas properties
        static bool CheckName(string name)
        {
            if (name.Length > 0 && name.Length <= StringMaxLength) return true;
            return false;
        }
        #endregion

        #endregion
    }
}
