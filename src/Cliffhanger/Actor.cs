namespace Cliffhanger
{
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
        public Actor() : base()
        {
            id = DefaultId;
            AddElement(this);
        }

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

        #region Other Methods
        // quando houver listas, verificar se este id não existe nas listas
        protected static bool CheckId(int id)
        {
            if (id > DefaultId)
            {
                return true;
            }
            return false;
        }

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

        public static void ShowGroupOfActors()
        {
            for (int i = 0; i < counter; i++)
            {
                Actor? element = groupOfActors[i];
                if (element != null)
                {
                    Console.WriteLine("Actor Id:    " + element.Id);
                    Console.WriteLine("Actor Name:  " + element.Name);
                    Console.WriteLine("Actor Birth: " + element.DateOfBirth + "\n");
                }
            }
        }
        #endregion

        #endregion
    }
}
