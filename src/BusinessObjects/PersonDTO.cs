namespace BusinessObjects
{
    public abstract class PersonDTO
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
            set { name = value; }
        }
        #endregion

        #region Constructors
        // sem id neste
        // é para passar dados
        public PersonDTO(string name)
        {
            this.name = name;
        }

        // é para criar clone
        public PersonDTO(Guid id, string name)
        {
            this.id = id;
            this.name = name;
        }
        #endregion

        #endregion
    }
}
