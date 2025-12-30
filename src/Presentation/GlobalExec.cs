using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class GlobalExec<T> where T : Identifier
    {
        public static void Menu()
        {
            string message = string.Empty;

            if (typeof(T) == typeof(Star))
                message = "Star";
            else if (typeof(T) == typeof(Movie))
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
            if (typeof(T) == typeof(Star))
                StarExec.ShowRepo();

            if (typeof(T) == typeof(Movie))
                MovieExec.ShowRepo();

            // vais adicionando tipos de objetos...
        }

        public static void ShowById()
        {
            if (typeof(T) == typeof(Star))
                StarExec.ShowById();

            if (typeof(T) == typeof(Movie))
                MovieExec.ShowById();

            // vais adicionando tipos de objetos...
        }

        public static void ShowByIndex()
        {
            if (typeof(T) == typeof(Star))
                StarExec.ShowByIndex();
            
            if (typeof(T) == typeof(Movie))
                MovieExec.ShowByIndex();

            // vais adicionando tipos de objetos...
        }

        public static void CreateAndAdd()
        {
            if (typeof(T) == typeof(Star))
                StarExec.CreateAndAdd();
            
            if (typeof(T) == typeof(Movie))
                MovieExec.CreateAndAdd();

            // vais adicionando tipos de objetos...
        }

        public static void RemoveById()
        {
            if (typeof(T) == typeof(Star))
                StarExec.RemoveById();
            
            if (typeof(T) == typeof(Movie))
                MovieExec.RemoveById();

            // vais adicionando tipos de objetos...
        }

        public static void RemoveByIndex()
        {
            if (typeof(T) == typeof(Star))
                StarExec.RemoveByIndex();
            
            if (typeof(T) == typeof(Movie))
                MovieExec.RemoveByIndex();

            // vais adicionando tipos de objetos...
        }

        public static void EditById()
        {
            if (typeof(T) == typeof(Star))
                StarExec.EditById();
            
            if (typeof(T) == typeof(Movie))
                MovieExec.EditById();

            // vais adicionando tipos de objetos...
        }

        public static void EditByIndex()
        {
            if (typeof(T) == typeof(Star))
                StarExec.EditByIndex();
            
            if (typeof(T) == typeof(Movie))
                MovieExec.EditByIndex();

            // vais adicionando tipos de objetos...
        }
    }
}
