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
        // ver melhor o readonly
        // acho que só pode ser alterado em duas ocasiões
        // 1 - Ao criar a variavel (aqui)
        // 2 - No construtor
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
        public override bool Equals(object? obj)
        {
            if (obj is null || GetType() != obj.GetType())
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            Person other = (Person)obj;
            return id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(Person p1, Person p2)
        {
            // 0 && 0 --> True
            // 0 && 1 --> False
            // 1 && 0 --> False
            // 1 && 1 --> Result

            if (p1 is null)
                return p2 is null;

            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Other Methods
        #endregion

        #endregion
    }
}
