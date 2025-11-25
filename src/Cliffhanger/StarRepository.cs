namespace Cliffhanger
{
    public class StarRepository : IElement<Star>
    {
        #region Attributes
        List<Star> repository;
        #endregion
        
        #region Methods
        
        #region Properties
        public List<Star> Repository
        {
            get { return repository; }
        }
        #endregion

        #region Constructors
        public StarRepository()
        {
            repository = new List<Star>();
        }
        #endregion
        
        #region Other Methods
        public bool AddElement(Star element)
        {
            if (!DoesIdExist(element.Id))
            {
                repository.Add(element);
                return true;
            }
            return false;
        }

        public bool RemoveElement(Star element)
        {
            foreach (Star item in repository)
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
                
            foreach (Star item in repository)
            {
                if (item.Id == id) return true;
            }
            return false;
        }

        public void ShowAllElements()
        {
            foreach (Star item in repository)
            {
                Console.WriteLine("Id:   " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Date: " + item.DateOfBirth);
                Console.WriteLine("Job:  " + item.Job + "\n");
            }
        }
        #endregion
        
        #endregion
    }
}
