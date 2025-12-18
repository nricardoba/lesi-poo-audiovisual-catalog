using BusinessObjects;
using Data;

namespace BusinessLogic
{
    public static class GlobalRepoControl<T> where T : Identifier
    {
        #region Star
        #endregion

        #region Generic
        public static bool AddElement(T element)
        {
            return GlobalRepo<T>.AddElement(element);
        }

        public static bool RemoveElement(T element)
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

        public static T? GetElementById(Guid id)
        {
            return GlobalRepo<T>.GetElementById(id);
        }

        public static T? GetElementByIndex(int index)
        {
            return GlobalRepo<T>.GetElementByIndex(index);
        }
        #endregion
    }
}
