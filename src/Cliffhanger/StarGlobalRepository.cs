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
            if (repository.Contains(element)) return false;

            // usar um sistema de Id (Guid)
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
        #endregion
    }
}
