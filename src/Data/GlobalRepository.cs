using BusinessObjects;

namespace Data
{
    public static class GlobalRepository<T> where T : Person
    {
        #region Attributes
        // Este readonly deixa manipular a lista, mas não deixa fazer
        // repository = null ou repository = OutraLista
        static readonly List<T> repository = new List<T>();
        #endregion

        #region Methods
        // o metodo 'Contains' usa o metodo 'Equals' para comparar objetos
        // ( deste override a esse metodo na class Person )
        public static bool AddElement(T element)
        {
            if (element is null || repository.Contains(element))
                return false;

            repository.Add(element);
            return true;
        }

        // o metodo 'Remove' usa o metodo 'Equals' para comparar objetos
        // ( deste override a esse metodo na class Person )
        public static bool RemoveElement(T element)
        {
            // retorna true se encontrou e removeu
            // retorna false se não existe na lista
            return repository.Remove(element);
        }

        public static bool RemoveElementById(Guid id)
        {
            T? element = GetElement(id);

            if (element is null)
                return false;

            return repository.Remove(element);
        }

        public static T? GetElement(Guid id)
        {
            foreach (T element in repository)
            {
                if (element.Id == id)
                    return element;
            }

            return null;
        }
        #endregion
    }
}
