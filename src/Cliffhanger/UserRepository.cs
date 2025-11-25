namespace Cliffhanger
{
    public abstract class UserRepository : IElement<User>
    {
        #region Attributes
        static List<User> repository = new List<User>();
        #endregion

        #region Methods
        public static bool AddElement(User element)
        {
            if (!DoesIdExist(element.Id))
            {
                repository.Add(element);
                return true;
            }
            return false;
        }

        public static bool RemoveElement(User element)
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

        public static bool DoesIdExist(int id)
        {
            if (id < ProgramConfig.MinId || id > ProgramConfig.MaxId)
                return true;

            foreach (User item in repository)
            {
                if (item.Id == id) return true;
            }
            return false;
        }

        public static void ShowAllElements()
        {
            foreach (User item in repository)
            {
                Console.WriteLine("Id:   " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Job:  " + item.Account + "\n");
            }
        }
        #endregion
    }
}
