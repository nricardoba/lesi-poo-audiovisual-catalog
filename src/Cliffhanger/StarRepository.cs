namespace Cliffhanger
{
    public abstract class StarRepository : IElement<Star>
    {
        #region Attributes
        static List<Star> repository = new List<Star>();
        #endregion

        #region Methods
        public static bool AddElement(Star element)
        {
            if (!DoesIdExist(element.Id))
            {
                repository.Add(element);
                return true;
            }
            return false;
        }

        public static bool RemoveElement(Star element)
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

        public static bool DoesIdExist(int id)
        {
            if (id < ProgramConfig.MinId || id > ProgramConfig.MaxId)
                return true;
                
            foreach (Star item in repository)
            {
                if (item.Id == id) return true;
            }
            return false;
        }

        public static void ShowAllElements()
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
    }
}
