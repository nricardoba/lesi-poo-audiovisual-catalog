namespace Cliffhanger
{
    public class UserRepository : IElement<User>
    {
        #region Attributes
        Dictionary<int, User> repository;
        #endregion

        #region Methods

        #region Constructors
        public UserRepository()
        {
            repository = new Dictionary<int, User>();
        }
        #endregion
        
        #region Other Methods
        public bool AddElement(User element)
        {
            if (IsIdAvailable(element.Id))
            {
                repository.Add(element.Id, element);
                return true;
            }

            return false;
        }
        
        public bool RemoveElement(int id)
        {
            if (!repository.ContainsKey(id)) return false;

            repository.Remove(id);
            return true;
        }

        public bool IsIdAvailable(int id)
        {
            if (Person.IsIdValid(id) && !repository.ContainsKey(id))
                return true;

            return false;
        }

        public void ShowAllElements()
        {
            foreach (KeyValuePair<int, User> item in repository)
            {
                Console.WriteLine("Id:   " + item.Value.Id);
                Console.WriteLine("Name: " + item.Value.Name);
                Console.WriteLine("Job:  " + item.Value.Account + "\n");
            }
        }
        #endregion
        
        #endregion
    }
}
