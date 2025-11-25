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
            id = Config.DefaultId;
            name = Config.DefaultName;
        }

        // talvez tirar as verificações, o construtor só é chamado se as variaveis forem verificadas anteriormente
        public Person(int id, string name)
        {
            if (IsValidId(id)) this.id = id;
            else this.id = Config.DefaultId;

            if (IsValidName(name)) this.name = name;
            else this.name = Config.DefaultName;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        // protected?
        static bool IsValidId(int id)
        {
            if (id >= Config.MinId && id <= Config.MaxId)
                return true;
            return false;
        }

        // não tenho a certeza se as posso usar no constructor e nas properties
        static bool IsValidName(string name)
        {
            if (name.Length >= Config.StringMinLength && name.Length <= Config.StringMaxLength)
                return true;
            return false;
        }
        #endregion

        #endregion
    }
}
