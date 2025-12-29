using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class StarExec
    {
        const int InvalidIndex = -1;
        static readonly Guid InvalidId = Guid.Empty;

        public static void StarMenu()
        {
            bool end = false;
            while (!end)
            {
                int option = ConsoleUI.StarMenu();
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

        public static void ShowById()
        {
            Guid? id = ConsoleIO.GetId();
            var element = GlobalRepoControl<Star>.GetElementById(id ?? InvalidId);
            ShowElement((StarDTO?)element);
        }

        public static void ShowByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            var element = GlobalRepoControl<Star>.GetElementByIndex(index ?? InvalidIndex);
            ShowElement((StarDTO?)element);
        }

        public static void CreateAndAdd()
        {
            StarDTO dto = ConsoleIO.GetStarInfo();
            Star auxStar = StarService.Create(dto);
            bool success = GlobalRepoControl<Star>.AddElement(auxStar);

            Console.WriteLine();
            string message = success ? "Star added successfully!"
                : "Star is invalid or already exists!";

            Console.WriteLine(message);
        }

        public static void RemoveById()
        {
            Guid? id = ConsoleIO.GetId();
            bool success = GlobalRepoControl<Star>.RemoveElementById(id ?? InvalidId);

            string message = success ? "Star removed successfully!"
                : "Id is invalid!";

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

        public static void EditById()
        {
            StarDTO dto = ConsoleIO.GetStarInfo();
            Guid? id = ConsoleIO.GetId();
            bool success = GlobalRepoControl<Star>.EditElementById(id ?? InvalidId, dto);

            string message = success ? "Star edited successfully!"
                : "Id is invalid!";

            Console.WriteLine(message);
        }

        public static void EditByIndex()
        {
            StarDTO dto = ConsoleIO.GetStarInfo();
            int? index = ConsoleIO.ReadInt("index");
            bool success = GlobalRepoControl<Star>.EditElementByIndex(index ?? InvalidIndex, dto);

            string message = success ? "Star edited successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }
    }
}
