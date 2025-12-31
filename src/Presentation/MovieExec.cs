using BusinessObjects;
using BusinessLogic;
using Exceptions;

namespace Presentation
{
    /// <summary>
    /// Execution of movie menu options
    /// </summary>
    public static class MovieExec
    {
        public static void ShowRepo()
        {
            List<object> repository = GlobalRepoControl<Movie>.GetRepository();

            if (repository.Count == 0)
            {
                Console.WriteLine("The repository is empty!");
                return;
            }
            
            foreach (object element in repository)
            {
                MovieDTO aux = (MovieDTO)element;
                ShowElement(aux);
            }
        }

        public static void ShowElement(MovieDTO? element)
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

        public static void ShowById()
        {
            Guid? id = ConsoleIO.GetId();
            var element = GlobalRepoControl<Movie>.GetElementById(id ?? Config.InvalidId);
            ShowElement((MovieDTO?)element);
        }

        public static void ShowByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            var element = GlobalRepoControl<Movie>.GetElementByIndex(index ?? Config.InvalidIndex);
            ShowElement((MovieDTO?)element);
        }

        public static void CreateAndAdd()
        {
            MovieDTO dto = ConsoleIO.GetMovieInfo();
            Movie auxMovie = MovieService.Create(dto);
            bool success = GlobalRepoControl<Movie>.AddElement(auxMovie);

            Console.WriteLine();
            string message = success
                ? "Movie added successfully!"
                : "Movie is invalid or already exists!";

            Console.WriteLine(message);
        }

        public static void RemoveById()
        {
            Guid? id = ConsoleIO.GetId();
            bool success = GlobalRepoControl<Movie>.RemoveElementById(id ?? Config.InvalidId);

            string message = success
                ? "Movie removed successfully!"
                : "Id is invalid!";

            Console.WriteLine(message);
        }

        public static void RemoveByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            bool success = GlobalRepoControl<Movie>.RemoveElementByIndex(index ?? Config.InvalidIndex);

            string message = success
                ? "Movie removed successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }

        public static void EditById()
        {
            Guid? id = ConsoleIO.GetId();
            MovieDTO dto = ConsoleIO.GetMovieInfo();
            bool success = GlobalRepoControl<Movie>.EditElementById(id ?? Config.InvalidId, dto);

            string message = success
                ? "Movie edited successfully!"
                : "Id is invalid!";

            Console.WriteLine(message);
        }

        public static void EditByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            MovieDTO dto = ConsoleIO.GetMovieInfo();
            bool success = GlobalRepoControl<Movie>.EditElementByIndex(index ?? Config.InvalidIndex, dto);

            string message = success
                ? "Movie edited successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }

        public static void Save()
        {
            try
            {
                if (GlobalRepoControl<Movie>.Save(Config.MovieFilePath))
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
        
        public static void Load()
        {
            try
            {
                if (GlobalRepoControl<Movie>.Load(Config.MovieFilePath))
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
