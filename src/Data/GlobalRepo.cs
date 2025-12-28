using BusinessObjects;
using System.Runtime.Serialization.Formatters.Binary;

namespace Data
{
    public static class GlobalRepo<T> where T : Identifier
    {
        #region Attributes
        // Este readonly deixa manipular a lista, mas não deixa fazer
        // repository = null ou repository = OutraLista
        static readonly List<T> repository = new List<T>();
        #endregion

        #region Methods
        // o metodo 'Contains' usa o metodo 'Equals' para comparar objetos
        // ( deste override a esse metodo na class Person )
        public static bool AddElement(T? element)
        {
            if (element is null || DoesElementExist(element))
                return false;

            repository.Add(element);
            return true;
        }

        // o metodo 'Remove' usa o metodo 'Equals' para comparar objetos
        // ( deste override a esse metodo na class Person )
        public static bool RemoveElement(T? element)
        {
            if (element is null)
                return false;
                
            // retorna true se encontrou e removeu
            // retorna false se não existe na lista
            return repository.Remove(element);
        }

        public static bool RemoveElementById(Guid id)
        {
            T? element = GetElementById(id);

            if (element is null)
                return false;

            return repository.Remove(element);
        }

        public static bool RemoveElementByIndex(int index)
        {
            T? element = GetElementByIndex(index);

            if (element is null)
                return false;

            return repository.Remove(element);
        }

        public static T? GetElementById(Guid id)
        {
            foreach (T element in repository)
            {
                if (element.Id == id)
                    return element;
            }

            return null;
        }

        public static T? GetElementByIndex(int index)
        {
            if (index < 0 || index >= repository.Count)
                return null;

            return repository[index];
        }

        public static List<T> GetRepository()
        {
            return new List<T>(repository);
        }

        public static bool DoesElementExist(T? obj)
        {
            if (obj is null)
                return false;

            foreach (T element in repository)
            {
                if (element.Equals(obj))
                    return true;
            }

            return false;
        }

        // podes fazer aqui exceptions
        public static bool Save(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(repository.Count);
                    foreach (T element in repository)
                    {
                        string json = System.Text.Json.JsonSerializer.Serialize(element);
                        writer.Write(json);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Load(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int count = reader.ReadInt32();
                    repository.Clear();
                    
                    for (int i = 0; i < count; i++)
                    {
                        string json = reader.ReadString();
                        T? element = System.Text.Json.JsonSerializer.Deserialize<T>(json);
                        if (element is not null)
                            repository.Add(element);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
