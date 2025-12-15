namespace BusinessObjects
{
    public abstract class PersonClone
    {
        #region Attributes
        readonly Guid id;
        readonly string name;
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
        }
        #endregion

        #region Constructors
        public PersonClone(Guid id, string name)
        {
            this.id = id;
            this.name = name;
        }
        #endregion

        #endregion
    }
}
