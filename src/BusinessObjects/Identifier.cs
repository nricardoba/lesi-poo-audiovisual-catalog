using System.Text.Json.Serialization;

namespace BusinessObjects
{
    public abstract class Identifier : IEquatable<Identifier>, IComparable<Identifier>
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
        [JsonIgnore]
        public Guid Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (IntegrityValidator.IsNameValid(value))
                    name = value;
            }
        }
        #endregion

        #region Constructors
        public Identifier()
        {
            id = Guid.NewGuid();
            name = Config.DefaultName;
        }

        public Identifier(string name)
        {
            id = Guid.NewGuid();
            this.name = IntegrityValidator.IsNameValid(name)
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

            return Equals((Identifier)other);
        }

        public bool Equals(Identifier? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return id == other.id;
        }

        public int CompareTo(Identifier? other)
        {
            if (other is null) return 1;
            return id.CompareTo(other.id);
        }

        public static bool operator ==(Identifier? i1, Identifier? i2)
        {
            // 0 && 0 --> True
            // 0 && 1 --> False
            // 1 && 0 --> False
            // 1 && 1 --> Result

            if (i1 is null)
                return i2 is null;

            return i1.Equals(i2);
        }

        public static bool operator !=(Identifier? i1, Identifier? i2)
        {
            return !(i1 == i2);
        }
        #endregion

        #endregion
    }
}
