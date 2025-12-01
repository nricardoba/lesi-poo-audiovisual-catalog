namespace Cliffhanger
{
    public static class StarGlobalRepository
    {
        #region Attributes
        static List<Star> repository = new List<Star>();
        #endregion

        #region Methods
        public static bool AddElement(Star element)
        {
            if (IsRepositoryFull()) return false;

            element.Id = repository.Count;
            repository.Add(element);

            return true;
        }

        public static bool RemoveElement(int id)
        {
            Star? aux = GetElement(id);

            if (aux == null) return false;

            repository.Remove(aux);
            return true;
        }

        public static Star? GetElement(int id)
        {
            foreach (Star element in repository)
            {
                if (element.Id == id) return element;
            }

            return null;
        }

        public static bool IsRepositoryFull()
        {
            if (repository.Count < Config.MaxId + 1)
                return false;
            return true;
        }
        #endregion
    }
}
