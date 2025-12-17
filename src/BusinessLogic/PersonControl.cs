using BusinessObjects;
using Data;

namespace BusinessLogic
{
    public static class PersonControl<T> where T : Person
    {
        #region Star
        public static Star CreateStar(StarDTO element)
        {
            if (!RuleValidator.IsNameOrTitleValid(element.Name))
                element.Name = Config.DefaultName;

            if (!RuleValidator.IsBirthDateValid(element.Birthdate.Year,
                element.Birthdate.Month, element.Birthdate.Day))
                element.Birthdate = Config.DefaultDate;

            return new Star(element.Name, element.Birthdate, element.Job);
        }
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

        public static List<PersonDTO>? Clone()
        {
            return PersonGlobalRepo<T>.Clone();
        }
        #endregion
    }
}
