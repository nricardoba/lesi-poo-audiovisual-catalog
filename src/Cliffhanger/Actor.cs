namespace Cliffhanger
{
    /// <summary>
    /// Class that represents an actor.
    /// Inherits the abstract class xPerson and the interface IElement.
    /// </summary>
    public class Actor : Person, IElement<Actor>
    {
        #region Constants
        const int MaxActors = 5;
        protected const int DefaultId = -1;
        #endregion

        #region Attributes
        // depois usar uma lista
        static Actor?[] groupOfActors = new Actor[MaxActors];
        static int counter = 0;

        int id;
        #endregion

        #region Methods

        #region Properties
        /// <summary>
        /// Property of attribute id.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public int Id
        {
            get { return id; }
            set
            {
                if (CheckId(value)) id = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor of class Actor.
        /// Assigns the default values.
        /// Calls the default constructor of class Person.
        /// </summary>
        public Actor() : base()
        {
            id = DefaultId;
            AddElement(this);
        }

        /// <summary>
        /// Constructor with all the parameters of class Actor.
        /// Checks and assigns the values ​​passed as parameters.
        /// Calls the constructor of class Person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public Actor(int id, string name, int year, int month, int day) : base(name, year, month, day)
        {
            if (CheckId(id))
            {
                this.id = id;
            }
            else
            {
                this.id = DefaultId;
            }

            AddElement(this);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Implementation of method ShowInformation of abstract class Person.
        /// Displays information about an object of class Actor in the console.
        /// </summary>
        public override void ShowInformation()
        {
            Console.WriteLine("Actor Id:    " + Id);
            Console.WriteLine("Actor Name:  " + Name);
            Console.WriteLine("Actor Birth: " + DateOfBirth + "\n");
        }
        #endregion

        #region Other Methods
        /// <summary>
        /// Checks if an id is valid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If the id is valid, returns true if it is invalid, returns false.
        /// </returns>
        // quando houver listas, verificar se este id não existe nas listas
        protected static bool CheckId(int id)
        {
            if (id > DefaultId)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Implementation of method AddElement defined in interface IElement.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// If successful insertion occurs, returns true, otherwise, returns false.
        /// </returns>
        // não é aqui que se verifica se o ID é o mesmo!!!
        public static bool AddElement(Actor element)
        {
            if (element == null) return false;

            if (counter < groupOfActors.Length)
            {
                groupOfActors[counter++] = element;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Implementation of method RemoveElement defined in interface IElement.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// If successful removal occurs, returns true, otherwise, returns false.
        /// </returns>
        public static bool RemoveElement(Actor element)
        {
            if (element == null) return false;

            for (int i = 0; i < counter; i++)
            {
                if (groupOfActors[i] == element)
                {
                    for (int j = i; j < counter - 1; j++)
                    {
                        groupOfActors[j] = groupOfActors[j + 1];
                    }

                    groupOfActors[counter - 1] = null;
                    counter--;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Displays information about all elements of the array.
        /// Use the ShowInformation method to display information about each element.
        /// </summary>
        // porque é que a verificação de null pode ser simplificada?
        public static void ShowGroupOfActors()
        {
            for (int i = 0; i < counter; i++)
            {
                Actor? element = groupOfActors[i];
                if (element != null)
                {
                    element.ShowInformation();
                }
            }
        }
        #endregion

        #endregion
    }
}
