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
        // o ID entra semore como -1
        public bool AddElement(Star element)
        {
            if (IsIdAvailable(element.Id))
            {
                repository.Add(element.Id, element);
                return true;
            }
            // else if ()

            return false;
        }

        public bool RemoveElement(int id)
        {
            if (!repository.ContainsKey(id)) return false;

            repository.Remove(id);
            return true;
        }
        
        public static bool IsKeyValid(int key)
        {
            if (key >= Config.MinId && key <= Config.MaxId)
                return true;

            return false;
        }

        public bool IsIdAvailable(int id)
        {
            if (IsKeyValid(id) && !repository.ContainsKey(id))
                return true;

            return false;
        }

        // acho que está correto, mas verificar melhor mais tarde!
        public bool IsRepositoryFull()
        {
            if (repository.Count <= Config.MaxId) return false;
            return true;
        }
        #endregion
        
        #endregion
    }
}
