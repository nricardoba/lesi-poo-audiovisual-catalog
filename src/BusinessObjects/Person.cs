namespace BusinessObjects
{
    public abstract class Person : IEquatable<Person>, IComparable<Person>
    {
        #region Attributes
        // ver melhor o readonly
        // acho que só pode ser alterado em duas ocasiões
        // 1 - Ao criar a variavel (aqui)
        // 2 - No construtor
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
                if (IntegrityValidator.IsNameOrTitleValid(value))
                    name = value;
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
            this.name = IntegrityValidator.IsNameOrTitleValid(name)
                ? name : Config.DefaultName;
        }
        #endregion

        #region Comparators
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
        
        public override bool Equals(object? other)
        {
            if (other is null || GetType() != other.GetType())
                return false;

            return Equals((Person)other);
        }

        public bool Equals(Person? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return id == other.id;
        }

        public int CompareTo(Person? other)
        {
            if (other is null) return 1;
            return id.CompareTo(other.id);
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

        #endregion
    }
}
