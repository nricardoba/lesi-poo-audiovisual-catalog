namespace Exceptions
{
    /// <summary>
    /// Exception to be thrown when GlobalRepo is attempted to be used with an invalid data type
    /// </summary>
    public class RepoInvalidTypeException : Exception
    {
        public RepoInvalidTypeException()
            : base("This data type is invalid on this repository") { }

        public RepoInvalidTypeException(string s)
            : base(s) { }
        
        public RepoInvalidTypeException(string s, Exception e)
        {
            throw new RepoInvalidTypeException(e.Message + " - " + s);
        }
    }
}
