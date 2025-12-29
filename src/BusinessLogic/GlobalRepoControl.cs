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
            if (!GlobalRepo<T>.DoesElementExist(element))
                return false;

            return GlobalService.Edit(element, dto);
        }

        public static bool EditElementById(Guid id, object? dto)
        {
            T? element = GlobalRepo<T>.GetElementById(id);
            return GlobalService.Edit(element, dto);
        }
        
        public static bool EditElementByIndex(int index, object? dto)
        {
            T? element = GlobalRepo<T>.GetElementByIndex(index);
            return GlobalService.Edit(element, dto);
        }

        public static object? GetElementById(Guid id)
        {
            T? element = GlobalRepo<T>.GetElementById(id);
            return GlobalService.Clone(element);
        }

        public static object? GetElementByIndex(int index)
        {
            T? element = GlobalRepo<T>.GetElementByIndex(index);
            return GlobalService.Clone(element);
        }

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

        public static bool Save(string filePath)
        {
            return GlobalRepo<T>.Save(filePath);
        }

        public static bool Load(string filePath)
        {
            return GlobalRepo<T>.Load(filePath);
        }
        #endregion
    }
}
