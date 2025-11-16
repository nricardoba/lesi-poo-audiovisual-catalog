namespace Cliffhanger
{
    public class Actor : Person
    {
        #region Constants
        const int MaxActors = 5;
        protected const int DefaultId = -1;
        #endregion

        #region Attributes
        // depois usar uma lista
        static Actor[] groupOfActors = new Actor[MaxActors];
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
            if (counter < groupOfActors.Length) groupOfActors[counter++] = this;
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

            if (counter < groupOfActors.Length) groupOfActors[counter++] = this;
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

        public static void ShowGroupOfActors()
        {
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Actor Id:    " + groupOfActors[i].Id);
                Console.WriteLine("Actor Name:  " + groupOfActors[i].Name);
                Console.WriteLine("Actor Birth: " + groupOfActors[i].DateOfBirth + "\n");
            }
        }
        #endregion

        #endregion
    }
}
