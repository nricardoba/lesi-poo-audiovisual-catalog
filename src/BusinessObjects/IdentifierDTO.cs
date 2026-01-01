namespace BusinessObjects
{
    /// <summary>
    /// Data Transfer Object of Identifier class
    /// </summary>
    public abstract class IdentifierDTO
    {
        #region Attributes
        readonly Guid id;
        readonly string name;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property of attribute id.
        /// Just returns the value of the attribute.
        /// </summary>
        public Guid Id
        {
            get { return id; }
        }

        /// <summary>
        /// Property of attribute name.
        /// Just returns the value of the attribute.
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor to be used for clones.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public IdentifierDTO(Guid id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// Constructor to be used to edit attributes.
        /// </summary>
        /// <param name="name"></param>
        public IdentifierDTO(string name)
        {
            this.name = name;
        }
        #endregion

        #endregion
    }
}
