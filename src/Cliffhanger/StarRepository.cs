namespace Cliffhanger
{
    public class StarRepository : IElement<Star>
    {
        #region Attributes
        Dictionary<int, Star> repository;
        #endregion

        #region Methods

        #region Constructors
        public StarRepository()
        {
            repository = new Dictionary<int, Star>();
        }
        #endregion

        #region Other Methods
        // tás a passar o objeto já criado
        // tens que verificar se os atributos são validos antes de criar o objeto
        public bool AddElement(Star element)
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

        public bool IsRepositoryFull()
        {
            if (repository.Count <= Config.MaxId) return false;
            return true;
        }

        public void ShowAllElements()
        {
            foreach (KeyValuePair<int, Star> item in repository)
            {
                Console.WriteLine("Id:   " + item.Value.Id);
                Console.WriteLine("Name: " + item.Value.Name);
                Console.WriteLine("Date: " + item.Value.DateOfBirth);
                Console.WriteLine("Job:  " + item.Value.Job + "\n");
            }
        }
        #endregion
        
        #endregion
    }
}
