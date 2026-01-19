/// <file>IdRepo.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>19-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;

namespace Data
{
    public class IdRepo<T> where T : Identifier
    {
        #region Attributes
        // lista de IDs que existem para um T
        static List<int> repository;
        #endregion

        #region Constructors
        static IdRepo()
        {
            repository = new List<int>();
        }
        #endregion

        #region Methods   
        public static bool AddId(int? id)
        {
            if (id is null || DoesIdExist(id))
                return false;

            repository.Add((int)id);
            return true;
        }

        public static bool RemoveId(int? id)
        {
            if (id is null || !DoesIdExist(id))
                return false;

            return repository.Remove((int)id);
        }

        public static bool SortRepository()
        {
            if (repository.Count == 0)
                return false;

            repository.Sort();

            return true;
        }

        public static bool DoesIdExist(int? id)
        {
            if (id is null)
                return false;

            foreach (int element in repository)
            {
                if (element == id)
                    return true;
            }

            return false;
        }
        #endregion
    }
}
