namespace BusinessObjects
{
    public abstract class Person
    {
        #region Attributes
        readonly Guid id;
        string name;
        #endregion

        #region Methods

        #region Properties
        public Guid Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (Config.IsNameValid(value)) name = value;
            }
        }
        #endregion

        #region Constructors
        public Person()
        {
            id = Guid.NewGuid();
            name = Config.DefaultName;
        }

        public Person(string name)
        {
            id = Guid.NewGuid();
            this.name = Config.IsNameValid(name) ? name : Config.DefaultName;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        #endregion

        #endregion
    }
}
