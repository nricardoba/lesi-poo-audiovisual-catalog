using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
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
            string message = GlobalRepoControl<Movie>.Save(Config.StarFilePath)
                ? "Movie information saved successfully!"
                : "Unable to save Movie information!";
            Console.WriteLine(message);
        }
        
        public static void Load()
        {
            string message = GlobalRepoControl<Movie>.Load(Config.StarFilePath)
                ? "Movie information loaded successfully!"
                : "Unable to load Movie information!";
            Console.WriteLine(message);
        }
    }
}
