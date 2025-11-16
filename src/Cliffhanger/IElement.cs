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
        static abstract bool AddElement(ObjectType element);

        /// <summary>
        /// Signature of method RemoveElement.
        /// The purpose of the method is to remove an element from a data structure.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// The result of removal.
        /// </returns>
        static abstract bool RemoveElement(ObjectType element);
    }
}
