/// <file>MovieExec.cs</file>
/// <author>Nuno Ricardo Araújo (a21150@alunos.ipca.pt)</author>
/// <date>16-01-2026</date>
/// 
/// <copyright>Copyright (c) 2026</copyright>
/// 

using BusinessObjects;
using BusinessLogic;
using Exceptions;

namespace Presentation
{
    /// <summary>
    /// Execution of movie menu options
    /// </summary>
    public class MovieExec
    {
        /// <summary>
        /// Try to display the information of all elements in the Movie repository on the console.
        /// </summary>
        public static void ShowRepo()
        {
            List<object> repository = GlobalRepoControl<Movie>.GetRepository();

            if (repository.Count == 0)
            {
                Console.WriteLine("The repository is empty!");
                return;
            }
            
            foreach (object element in repository)
                ShowElement((Movie)element);
        }

        /// <summary>
        /// Attempts to display all information about an object of type Movie in the console.
        /// </summary>
        /// <param name="element"></param>
        public static void ShowElement(Movie? element)
        {
            if (element is null)
                Console.WriteLine("Invalid Movie!");
            else
            {
                Console.WriteLine("ID: " + element.Id);
                Console.WriteLine("Name: " + element.Name);
                Console.WriteLine("Year: " + element.Year);
                Console.WriteLine("Duration: " + element.Duration);
                Console.WriteLine("AgeRating: " + element.AgeRating + "\n");
            }
        }

        /// <summary>
        /// It asks the user for an ID and if there is an element with that ID,
        /// it displays it in the console.
        /// </summary>
        public static void ShowById()
        {
            Guid? id = ConsoleIO.GetId();
            object? element = GlobalRepoControl<Movie>.GetElementById(id ?? Config.InvalidId);
            ShowElement((Movie?)element);
        }

        /// <summary>
        /// It asks the user for an index and if there is an element with that index,
        /// it displays it in the console.
        /// </summary>
        public static void ShowByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            object? element = GlobalRepoControl<Movie>.GetElementByIndex(index ?? Config.InvalidIndex);
            ShowElement((Movie?)element);
        }

        /// <summary>
        /// Asks the user for information about a Movie on the console.
        /// Attempts to create and add that Movie to the repository.
        /// </summary>
        public static void CreateAndAdd()
        {
            bool inputSuccess = ConsoleIO.GetMovieInfo(out string? name, out int? year,
                out int? duration, out int? ageRatingNum);

            Movie auxMovie = MovieService.Create(name, year, duration, ageRatingNum);
            bool success = GlobalRepoControl<Movie>.AddElement(auxMovie);

            Console.WriteLine();
            string message = success
                ? "Movie added successfully!"
                : "Movie is invalid or already exists!";

            Console.WriteLine(message);
        }

        /// <summary>
        /// Asks the user for an ID.
        /// If there is a Movie with that ID, it removes it from the repository.
        /// </summary>
        public static void RemoveById()
        {
            Guid? id = ConsoleIO.GetId();
            bool success = GlobalRepoControl<Movie>.RemoveElementById(id ?? Config.InvalidId);

            string message = success
                ? "Movie removed successfully!"
                : "Id is invalid!";

            Console.WriteLine(message);
        }

        /// <summary>
        /// Asks the user for an index.
        /// If there is a Movie with that index, it removes it from the repository.
        /// </summary>
        public static void RemoveByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            bool success = GlobalRepoControl<Movie>.RemoveElementByIndex(index ?? Config.InvalidIndex);

            string message = success
                ? "Movie removed successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }

        /// <summary>
        /// It asks the user for an ID and new information about the Movie.
        /// If the ID exists and the information about the Movie is valid,
        /// it attempts to edit the information in its attributes.
        /// </summary>
        public static void EditById()
        {
            Guid? id = ConsoleIO.GetId();
            if (id is null)
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            object? element = GlobalRepoControl<Movie>.GetElementById((Guid)id);
            if (element is null)
            {
                Console.WriteLine("There is no element with id: " + id + "!");
                return;
            }
            
            bool inputSuccess = ConsoleIO.GetMovieInfo(out string? name, out int? year,
                out int? duration, out int? ageRatingNum);
            if (!inputSuccess)
            {
                Console.WriteLine("Invalid info!");
                return;
            }

            bool editSuccess = MovieService.Edit((Movie)element, name, year, duration, ageRatingNum);
            if (!editSuccess)
            {
                Console.WriteLine("Movie cannot be edited!");
                return;
            }

            Console.WriteLine("Movie edited successfully!");
        }

        /// <summary>
        /// It asks the user for an index and new information about the Movie.
        /// If the index exists and the information about the Movie is valid,
        /// it attempts to edit the information in its attributes.
        /// </summary>
        public static void EditByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            if (index is null)
            {
                Console.WriteLine("Invalid index!");
                return;
            }

            object? element = GlobalRepoControl<Movie>.GetElementByIndex((int)index);
            if (element is null)
            {
                Console.WriteLine("There is no element with index: " + index + "!");
                return;
            }
            
            bool inputSuccess = ConsoleIO.GetMovieInfo(out string? name, out int? year,
                out int? duration, out int? ageRatingNum);
            if (!inputSuccess)
            {
                Console.WriteLine("Invalid info!");
                return;
            }

            bool editSuccess = MovieService.Edit((Movie)element, name, year, duration, ageRatingNum);
            if (!editSuccess)
            {
                Console.WriteLine("Movie cannot be edited!");
                return;
            }

            Console.WriteLine("Movie edited successfully!");
        }

        /// <summary>
        /// Sort the repository.
        /// </summary>
        public static void SortRepository()
        {
            string message = GlobalRepoControl<Movie>.SortRepository()
                ? "Repository successfully sorted!"
                : "The repository is empty!";
            
            Console.WriteLine(message);
        }

        /// <summary>
        /// Attempts to save the information about the repository in a binary file.
        /// If an exception occurs, it catches it and displays its message in the console.
        /// </summary>
        public static void Save()
        {
            try
            {
                GlobalRepoControl<Movie>.Save(Config.MovieFilePath);
                Console.WriteLine("Movies information saved successfully!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (RepoInvalidTypeException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        
        /// <summary>
        /// Attempts to load information about the repository from the console.
        /// If an exception occurs, it catches it and displays its message in the console.
        /// </summary>
        public static void Load()
        {
            try
            {
                GlobalRepoControl<Movie>.Load(Config.MovieFilePath);
                Console.WriteLine("Movies information loaded successfully!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (RepoInvalidTypeException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (RepoCannotAddElementException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
