namespace Cliffhanger
{
    public abstract class Person
    {
        #region Attributes
        int id;
        string name = string.Empty;
        #endregion

        #region Methods

        #region Properties
        public int Id
        {
            get { return id; }
            set
            {
                if (IsValidId(value)) id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (IsValidName(value)) name = value;
            }
        }
        #endregion

        #region Constructors
        public Person()
        {
            id = ProgramConfig.DefaultId;
            name = ProgramConfig.DefaultName;
        }

        // talvez tirar as verificações, o construtor só é chamado se as variaveis forem verificadas anteriormente
        public Person(int id, string name)
        {
            if (IsValidId(id)) this.id = id;
            else this.id = ProgramConfig.DefaultId;

            if (IsValidName(name)) this.name = name;
            else this.name = ProgramConfig.DefaultName;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        // protected?
        static bool IsValidId(int id)
        {
            if (id >= ProgramConfig.MinId && id <= ProgramConfig.MaxId)
                return true;
            return false;
        }

        // não tenho a certeza se as posso usar no constructor e nas properties
        static bool IsValidName(string name)
        {
            if (name.Length >= ProgramConfig.StringMinLength && name.Length <= ProgramConfig.StringMaxLength)
                return true;
            return false;
        }
        #endregion

        #endregion
    }
}
