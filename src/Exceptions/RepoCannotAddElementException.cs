/// <file>RepoCannotAddElementException.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

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
