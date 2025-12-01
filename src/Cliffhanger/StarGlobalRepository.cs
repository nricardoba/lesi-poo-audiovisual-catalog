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
            int auxId = GenerateId();
            if (!Config.IsIdValid(auxId)) return false;

            element.Id = auxId;
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

        static int GenerateId()
        {
            if (IsRepositoryFull()) return Config.DefaultId;

            int id;
            do
            {
                id = Random.Shared.Next(Config.MinId, Config.MaxId + 1);

            } while (DoesIdExist(id));

            return id;
        }

        public static bool DoesIdExist(int id)
        {
            if (!Config.IsIdValid(id)) return false;

            foreach (Star element in repository)
            {
                if (element.Id == id) return true;
            }

            return false;
        }

        public static bool IsRepositoryFull()
        {
            if (repository.Count < Config.RepositoryMaxElements)
                return false;
            return true;
        }
        #endregion
    }
}
