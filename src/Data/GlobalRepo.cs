using BusinessObjects;
using Exceptions;

namespace Data
{
    /// <summary>
    /// Global DL generic repository of classes Star and Movie
    /// </summary>
    /// <typeparam name="T">
    /// T can be Identifier or any class that inherits from it
    /// </typeparam>
    public static class GlobalRepo<T> where T : Identifier
    {
        #region Attributes
        // Este readonly deixa manipular a lista, mas não deixa fazer
        // repository = null ou repository = OutraLista
        static readonly List<T> repository = new List<T>();
        #endregion

        #region Methods
        /// <summary>
        /// Checks whether the element can be added to the repository. If it can, adds it.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool AddElement(T? element)
        {
            if (element is null || DoesElementExist(element))
                return false;

            repository.Add(element);
            return true;
        }

        // o metodo 'Remove' usa o metodo 'Equals' para comparar objetos
        // ( deste override a esse metodo na class Person )

        /// <summary>
        /// If the element is not null, try to remove it from the repository.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool RemoveElement(T? element)
        {
            if (element is null)
                return false;

            // retorna true se encontrou e removeu
            // retorna false se não existe na lista
            return repository.Remove(element);
        }

        /// <summary>
        /// Searches for an element with the ID passed by parameters.
        /// If found, removes it from the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool RemoveElementById(Guid id)
        {
            T? element = GetElementById(id);

            if (element is null)
                return false;

            return repository.Remove(element);
        }

        /// <summary>
        /// Searches for an element with the index passed by parameters.
        /// If found, removes it from the repository.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool RemoveElementByIndex(int index)
        {
            T? element = GetElementByIndex(index);

            if (element is null)
                return false;

            return repository.Remove(element);
        }

        /// <summary>
        /// Searches for an element in the repository with the ID passed by parameters.
        /// If found, returns that element.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T? GetElementById(Guid id)
        {
            foreach (T element in repository)
            {
                if (element.Id == id)
                    return element;
            }

            return null;
        }

        /// <summary>
        /// If the index passed as a parameter is valid, it returns the element with that index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static T? GetElementByIndex(int index)
        {
            if (index < 0 || index >= repository.Count)
                return null;

            return repository[index];
        }

        /// <summary>
        /// Returns the repository.
        /// </summary>
        /// <returns></returns>
        public static List<T> GetRepository()
        {
            return repository;
        }

        /// <summary>
        /// Checks whether an object passed by parameters exists in the repository.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool DoesElementExist(T? obj)
        {
            if (obj is null)
                return false;

            foreach (T element in repository)
            {
                if (element.Equals(obj))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Save the repository in a binary file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="RepoInvalidTypeException"></exception>
        public static bool Save(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(repository.Count);
                foreach (T element in repository)
                {
                    writer.Write(element.Id.ToString());
                    writer.Write(element.Name);

                    if (element is Star auxStar)
                    {
                        writer.Write(auxStar.BirthDate.DayNumber);
                        writer.Write((int)auxStar.Job);
                    }
                    else if (element is Movie auxMovie)
                    {
                        writer.Write(auxMovie.Year);
                        writer.Write(auxMovie.Duration);
                        writer.Write((int)auxMovie.AgeRating);
                    }

                    // vais adicionando tipos de objetos...

                    else
                    {
                        throw new RepoInvalidTypeException();
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Loads the repository from a binary file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="RepoCannotAddElementException"></exception>
        /// <exception cref="RepoInvalidTypeException"></exception>
        public static bool Load(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int count = reader.ReadInt32();
                repository.Clear();

                for (int i = 0; i < count; i++)
                {
                    // isto pode atirar uma FormatException
                    Guid id = Guid.Parse(reader.ReadString());
                    string name = reader.ReadString();

                    var tType = typeof(T);

                    if (tType == typeof(Star))
                    {
                        int dayNum = reader.ReadInt32();
                        DateOnly birthDate = DateOnly.FromDayNumber(dayNum);
                        JobType job = (JobType)reader.ReadInt32();

                        T element = (T)(object)new Star(id, name, birthDate, job);

                        if (!AddElement(element))
                        {
                            throw new RepoCannotAddElementException();
                        }
                    }
                    else if (tType == typeof(Movie))
                    {
                        int year = reader.ReadInt32();
                        int duration = reader.ReadInt32();
                        AgeRatingType ageRating = (AgeRatingType)reader.ReadInt32();

                        T element = (T)(object)new Movie(id, name, year, duration, ageRating);

                        if (!AddElement(element))
                        {
                            throw new RepoCannotAddElementException();
                        }
                    }

                    // vais adicionando tipos de objetos...

                    else
                    {
                        throw new RepoInvalidTypeException();
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
