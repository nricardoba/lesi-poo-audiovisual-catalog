namespace BusinessObjects
{
    public abstract class IdentifierDTO
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
        public IdentifierDTO(Guid id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public IdentifierDTO(string name)
        {
            this.name = name;
        }
        #endregion

        #endregion
    }
}
