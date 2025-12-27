using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class StarExec
    {
        const int InvalidIndex = -1;

        public static void StarMenu()
        {
            bool end = false;
            while (!end)
            {
                int option = ConsoleUI.StarMenu();
                switch (option)
                {
                    case 1:
                        GenericExec.ShowRepo(GlobalRepoControl<Star>.GetRepository());
                        break;
                    case 2:
                        Console.WriteLine("Work in progress!");
                        break;
                    case 3:
                        ShowByIndex();
                        break;
                    case 4:
                        CreateAndAdd();
                        break;
                    case 5:
                        Console.WriteLine("Work in progress!");
                        break;
                    case 6:
                        RemoveByIndex();
                        break;
                    case 7:
                        Console.WriteLine("Work in progress!");
                        break;
                    case 8:
                        Console.WriteLine("Work in progress!");
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
            List<object> repository = GlobalRepoControl<Star>.GetRepository();

            if (repository.Count == 0)
            {
                Console.WriteLine("The repository is empty!");
                return;
            }
            
            foreach (object element in repository)
            {
                StarDTO aux = (StarDTO)element;
                ShowElement(aux);
            }
        }

        public static bool ShowElement(StarDTO? element)
        {
            if (element is null)
            {
                Console.WriteLine("Invalid Star!");
                return false;
            }

            Console.WriteLine("ID: " + element.Id);
            Console.WriteLine("Name: " + element.Name);
            Console.WriteLine("BirthDate: " + element.BirthDate);
            Console.WriteLine("Job: " + element.Job + "\n");

            return true;
        }

        public static void ShowByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            var element = GlobalRepoControl<Star>.GetElementByIndex(index ?? InvalidIndex);
            ShowElement((StarDTO?)element);
        }

        public static void CreateAndAdd()
        {
            string? name = ConsoleIO.ReadString("name");
            DateOnly? birthDate = ConsoleIO.GetDate();
            int? jobNum = ConsoleIO.ReadInt("job number");

            Star aux = StarService.Create(name, birthDate, jobNum);
            bool success = GlobalRepoControl<Star>.AddElement(aux);

            Console.WriteLine();
            string message = success ? "Star added successfully!"
                : "Star is invalid or already exists!";

            Console.WriteLine(message);
        }

        public static void RemoveByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            bool success = GlobalRepoControl<Star>.RemoveElementByIndex(index ?? InvalidIndex);

            string message = success ? "Star removed successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }
    }
}
