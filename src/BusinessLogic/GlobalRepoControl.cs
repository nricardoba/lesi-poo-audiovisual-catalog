using BusinessObjects;
using Data;

namespace BusinessLogic
{
    public static class GlobalRepoControl<T> where T : Identifier
    {
        #region Generic
        public static bool AddElement(T? element)
        {
            if (!RuleValidator.IsElementValid(element))
                return false;
            
            return GlobalRepo<T>.AddElement(element);
        }

        public static bool RemoveElement(T? element)
        {
            return GlobalRepo<T>.RemoveElement(element);
        }

        public static bool RemoveElementById(Guid id)
        {
            return GlobalRepo<T>.RemoveElementById(id);
        }

        public static bool RemoveElementByIndex(int index)
        {
            return GlobalRepo<T>.RemoveElementByIndex(index);
        }

        public static bool EditElement(T? element, object? dto)
        {
            if (element is null
                || !GlobalRepo<T>.DoesElementExist(element)
                || !RuleValidator.IsElementValid(dto))
                return false;

            return element.EditAttributes(dto);
        }

        public static bool EditElementById(Guid id, object? dto)
        {
            T? element = GlobalRepo<T>.GetElementById(id);

            if (element is null
                || !RuleValidator.IsElementValid(dto))
                return false;

            return element.EditAttributes(dto);
        }
        
        public static bool EditElementByIndex(int index, object? dto)
        {
            T? element = GlobalRepo<T>.GetElementByIndex(index);

            if (element is null
                || !RuleValidator.IsElementValid(dto))
                return false;

            return element.EditAttributes(dto);
        }

        public static object? GetElementById(Guid id)
        {
            T? element = GlobalRepo<T>.GetElementById(id);

            if (element is null)
                return null;

            return element.Clone();
        }

        public static object? GetElementByIndex(int index)
        {
            T? element = GlobalRepo<T>.GetElementByIndex(index);

            if (element is null)
                return null;

            return element.Clone();
        }

        public static List<object> GetRepository()
        {
            List<T> repository = GlobalRepo<T>.GetRepository();
            List<object> cloneList = new List<object>();

            foreach (T element in repository)
            {
                cloneList.Add(element.Clone());
            }

            return cloneList;
        }
        #endregion
    }
}
