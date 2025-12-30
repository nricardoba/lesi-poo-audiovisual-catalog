using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class GlobalExec<T> where T : Identifier
    {
        public static void Menu()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            string message = string.Empty;

            if (tType == starType)
                message = "Star";
            else if (tType == movieType)
                message = "Movie";
            else
                message = Config.DefaultName;

            bool end = false;
            while (!end)
            {
                int option = ConsoleUI.RepoMenu(message);
                Console.Clear();

                switch (option)
                {
                    case 1:
                        ShowRepo();
                        break;
                    case 2:
                        ShowById();
                        break;
                    case 3:
                        ShowByIndex();
                        break;
                    case 4:
                        CreateAndAdd();
                        break;
                    case 5:
                        RemoveById();
                        break;
                    case 6:
                        RemoveByIndex();
                        break;
                    case 7:
                        EditById();
                        break;
                    case 8:
                        EditByIndex();
                        break;
                    default:
                        end = true;
                        break;
                }

                if (!end)
                    ConsoleUI.Pause();
            }
        }
        
        public static void ShowRepo()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.ShowRepo();

            if (tType == movieType)
                MovieExec.ShowRepo();

            // vais adicionando tipos de objetos...
        }

        public static void ShowById()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.ShowById();

            if (tType == movieType)
                MovieExec.ShowById();

            // vais adicionando tipos de objetos...
        }

        public static void ShowByIndex()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.ShowByIndex();
            
            if (tType == movieType)
                MovieExec.ShowByIndex();

            // vais adicionando tipos de objetos...
        }

        public static void CreateAndAdd()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.CreateAndAdd();
            
            if (tType == movieType)
                MovieExec.CreateAndAdd();

            // vais adicionando tipos de objetos...
        }

        public static void RemoveById()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.RemoveById();
            
            if (tType == movieType)
                MovieExec.RemoveById();

            // vais adicionando tipos de objetos...
        }

        public static void RemoveByIndex()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.RemoveByIndex();
            
            if (tType == movieType)
                MovieExec.RemoveByIndex();

            // vais adicionando tipos de objetos...
        }

        public static void EditById()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.EditById();
            
            if (tType == movieType)
                MovieExec.EditById();

            // vais adicionando tipos de objetos...
        }

        public static void EditByIndex()
        {
            var tType = typeof(T);
            var starType = typeof(Star);
            var movieType = typeof(Movie);

            if (tType == starType)
                StarExec.EditByIndex();
            
            if (tType == movieType)
                MovieExec.EditByIndex();

            // vais adicionando tipos de objetos...
        }
    }
}
