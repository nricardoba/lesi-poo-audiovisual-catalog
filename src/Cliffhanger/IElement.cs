namespace Cliffhanger
{
    /// <summary>
    /// Interface with the signatures of methods AddElement and RemoveElement.
    /// The variable ObjectType means that when a class inherits this interface, 
    /// it can replace ObjectType with any data type it wants.
    /// </summary>
    /// <typeparam name="ObjectType"></typeparam>
    public interface IElement<ObjectType>
    {
        /// <summary>
        /// Signature of method AddElement.
        /// The purpose of the method is to add an element to a data structure.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// The result of insertion.
        /// </returns>
        bool AddElement(ObjectType element);

        /// <summary>
        /// Signature of method RemoveElement.
        /// The purpose of the method is to remove an element from a data structure.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// The result of removal.
        /// </returns>
        bool RemoveElement(int id);

        /// <summary>
        /// Signature of method DoesIdExist.
        /// The purpose of the method is...
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The result...
        /// </returns>
        bool CheckId(int id);

        /// <summary>
        /// Show in console all elements in a data data structure.
        /// </summary>
        void ShowAllElements();
    }
}
