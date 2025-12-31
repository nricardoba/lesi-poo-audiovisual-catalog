namespace Exceptions
{
    /// <summary>
    /// Exception to be thrown when attempting to add an element to a repository,
    /// when this element is invalid or already present in the repository
    /// </summary>
    public class RepoCannotAddElementException : Exception
    {
        public RepoCannotAddElementException()
            : base("Element is invalid or already exists") { }

        public RepoCannotAddElementException(string s)
            : base(s) { }
        
        public RepoCannotAddElementException(string s, Exception e)
        {
            throw new RepoCannotAddElementException(e.Message + " - " + s);
        }
    }
}
