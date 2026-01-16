/// <file>Identifier.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

namespace BusinessObjects
{
    /// <summary>
    /// Abstract class that serves as a model for all classes that can be part of a repository
    /// </summary>
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
        /// <summary>
        /// Property of attribute id.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public Guid Id
        {
            get { return id; }
        }

        /// <summary>
        /// Property of attribute name.
        /// If the variable value is valid, it's assigned.
        /// </summary>
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
        /// <summary>
        /// Default constructor.
        /// Assigns the default values.
        /// </summary>
        public Identifier()
        {
            id = Guid.NewGuid();
            name = Config.DefaultName;
        }

        /// <summary>
        /// Constructor with all the parameters.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="name"></param>
        public Identifier(string name)
        {
            id = Guid.NewGuid();
            this.name = IntegrityValidator.IsNameValid(name)
                ? name : Config.DefaultName;
        }

        /// <summary>
        /// This constructor will only be called when manipulating binary files.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Identifier(Guid id, string name)
        {
            this.id = id;
            this.name = IntegrityValidator.IsNameValid(name)
                ? name : Config.DefaultName;
        }
        #endregion

        #region Comparators
        /// <summary>
        /// Method that returns the hashcode of the class through the id attribute.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        /// <summary>
        /// Method that receives an object of any type and,
        /// if it is of the same type as the current instance of this class,
        /// checks whether they are the same.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object? other)
        {
            if (other is null || GetType() != other.GetType())
                return false;

            return Equals((Identifier)other);
        }

        /// <summary>
        /// Method that receives an object of the same type as the current instance of this class
        /// and checks if they are equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Identifier? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return id == other.id;
        }

        /// <summary>
        /// Method that receives an object of any type and,
        /// if it is of the same type as the current instance of this class,
        /// checks whether its ID is less than,
        /// equal to, or greater than the ID of the current instance of this class.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(object? other)
        {
            if (other is null || GetType() != other.GetType())
                return 1;

            return CompareTo((Identifier)other);
        }

        /// <summary>
        /// Method that receives an object and checks whether its Name is less than,
        /// equal to, or greater than the Name of the current instance of this class.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Identifier? other)
        {
            if (other is null) return 1;
            return name.CompareTo(other.name);
        }

        /// <summary>
        /// Method that receives an object and checks whether its ID is less than,
        /// equal to, or greater than the ID of the current instance of this class.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareToWithId(Identifier? other)
        {
            if (other is null) return 1;
            return id.CompareTo(other.id);
        }

        /// <summary>
        /// Override of the '==' operator that checks whether two objects of this class are equal.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Override of the '!=' operator that checks whether two objects of this class are not equal.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        public static bool operator !=(Identifier? i1, Identifier? i2)
        {
            return !(i1 == i2);
        }
        #endregion

        #endregion
    }
}
