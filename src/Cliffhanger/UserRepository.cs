namespace Cliffhanger
{
    public class UserRepository : IElement<User>
    {
        #region Attributes
        List<User> repository;
        #endregion
        
        #region Methods
        
        #region Properties
        public List<User> Repository
        {
            get { return repository; }
        }
        #endregion

        #region Constructors
        public UserRepository()
        {
            repository = new List<User>();
        }
        #endregion
        
        #region Other Methods
        public bool AddElement(User element)
        {
            if (!DoesIdExist(element.Id))
            {
                repository.Add(element);
                return true;
            }
            return false;
        }

        public bool RemoveElement(User element)
        {
            foreach (User item in repository)
            {
                if (item.Id == element.Id)
                {
                    repository.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public bool DoesIdExist(int id)
        {
            if (id < Config.MinId || id > Config.MaxId)
                return true;

            foreach (User item in repository)
            {
                if (item.Id == id) return true;
            }
            return false;
        }

        public void ShowAllElements()
        {
            foreach (User item in repository)
            {
                Console.WriteLine("Id:   " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Job:  " + item.Account + "\n");
            }
        }
        #endregion
        
        #endregion
    }
}
