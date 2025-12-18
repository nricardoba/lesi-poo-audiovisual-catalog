using BusinessObjects;
using Data;

namespace BusinessLogic
{
    public static class PersonControl<T> where T : Person
    {
        #region Star
        #endregion

        #region Generic
        public static bool AddElement(T element)
        {
            return PersonGlobalRepo<T>.AddElement(element);
        }

        public static bool RemoveElement(T element)
        {
            return PersonGlobalRepo<T>.RemoveElement(element);
        }

        public static bool RemoveElementById(Guid id)
        {
            return PersonGlobalRepo<T>.RemoveElementById(id);
        }

        public static bool RemoveElementByIndex(int index)
        {
            return PersonGlobalRepo<T>.RemoveElementByIndex(index);
        }

        public static T? GetElementById(Guid id)
        {
            return PersonGlobalRepo<T>.GetElementById(id);
        }

        public static T? GetElementByIndex(int index)
        {
            return PersonGlobalRepo<T>.GetElementByIndex(index);
        }
        #endregion
    }
}
