namespace Cliffhanger
{
    public interface IElement<ObjectType>
    {
        static abstract bool AddElement(ObjectType element);
        static abstract bool RemoveElement(ObjectType element);
    }
}
