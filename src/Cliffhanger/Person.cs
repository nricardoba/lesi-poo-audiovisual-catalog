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
        // depois ver melhor, porque só queres mudar o id em contexto da lista principal
        public int Id
        {
            get { return id; }
            set
            {
                if (Config.IsIdValid(value)) id = value;
            }
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
            id = Config.DefaultId;
            name = Config.DefaultName;
        }

        public Person(string name)
        {
            id = Config.DefaultId;

            if (Config.IsNameValid(name)) this.name = name;
            else this.name = Config.DefaultName;
        }
        #endregion

        #endregion
    }
}
