namespace Exceptions
{
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
