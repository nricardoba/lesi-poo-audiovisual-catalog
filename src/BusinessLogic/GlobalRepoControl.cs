using BusinessObjects;
using Data;

namespace BusinessLogic
{
    /// <summary>
    /// Global BL generic repository of classes Star and Movie
    /// </summary>
    /// <typeparam name="T">
    /// T can be Identifier or any class that inherits from it
    /// </typeparam>
    public static class GlobalRepoControl<T> where T : Identifier
    {
        #region Generic
        /// <summary>
        /// If the element is valid, use the DL layer method to add it to the repository.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool AddElement(T? element)
        {
            if (!RuleValidator.IsElementValid(element))
                return false;
            
            return GlobalRepo<T>.AddElement(element);
        }

        /// <summary>
        /// Uses the DL layer method to remove it from the repository.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool RemoveElement(T? element)
        {
            return GlobalRepo<T>.RemoveElement(element);
        }

        /// <summary>
        /// Uses the DL layer method to remove it from the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool RemoveElementById(Guid id)
        {
            return GlobalRepo<T>.RemoveElementById(id);
        }

        /// <summary>
        /// Uses the DL layer method to remove it from the repository.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool RemoveElementByIndex(int index)
        {
            return GlobalRepo<T>.RemoveElementByIndex(index);
        }

        /// <summary>
        /// Checks if the element exists, and if it does, tries to edit its attributes.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool EditElement(T? element, object? dto)
        {
            if (!GlobalRepo<T>.DoesElementExist(element))
                return false;

            return GlobalService.Edit(element, dto);
        }

        /// <summary>
        /// Attempts to find an element with the ID passed by parameters.
        /// If found, tries to edit its attributes.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool EditElementById(Guid id, object? dto)
        {
            T? element = GlobalRepo<T>.GetElementById(id);
            return GlobalService.Edit(element, dto);
        }

        /// <summary>
        /// Attempts to find an element with the index passed by parameters.
        /// If found, tries to edit its attributes.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool EditElementByIndex(int index, object? dto)
        {
            T? element = GlobalRepo<T>.GetElementByIndex(index);
            return GlobalService.Edit(element, dto);
        }

        /// <summary>
        /// Use the DL layer method to find an element with the ID passed by parameters.
        /// If found, create a clone so that this object is not accessible in the PL layer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static object? GetElementById(Guid id)
        {
            T? element = GlobalRepo<T>.GetElementById(id);
            return GlobalService.Clone(element);
        }

        /// <summary>
        /// Use the DL layer method to find an element with the index passed by parameters.
        /// If found, create a clone so that this object is not accessible in the PL layer.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static object? GetElementByIndex(int index)
        {
            T? element = GlobalRepo<T>.GetElementByIndex(index);
            return GlobalService.Clone(element);
        }

        /// <summary>
        /// Creates a clone of the DL layer repository.
        /// </summary>
        /// <returns></returns>
        public static List<object> GetRepository()
        {
            List<T> repository = GlobalRepo<T>.GetRepository();
            List<object> cloneList = new List<object>();

            foreach (T element in repository)
            {
                object? aux = GlobalService.Clone(element);

                if (aux is not null)
                    cloneList.Add(aux);
            }

            return cloneList;
        }

        /// <summary>
        /// Uses the DL layer method to sort the repository.
        /// </summary>
        /// <returns></returns>
        public static bool SortRepository()
        {
            return GlobalRepo<T>.SortRepository();
        }

        /// <summary>
        /// Uses the DL layer method to save the repository in a binary file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool Save(string filePath)
        {
            return GlobalRepo<T>.Save(filePath);
        }

        /// <summary>
        /// Uses the DL layer method to load the repository from a binary file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool Load(string filePath)
        {
            return GlobalRepo<T>.Load(filePath);
        }
        #endregion
    }
}
