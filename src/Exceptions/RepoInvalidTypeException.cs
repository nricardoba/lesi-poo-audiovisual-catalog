namespace Exceptions
{
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
