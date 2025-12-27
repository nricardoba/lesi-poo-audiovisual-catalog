using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class StarExec
    {
        public static void RepoMenu()
        {
            bool end = false;
            while (!end)
            {
                // const int InvalidIndex = -1;
                int option = ConsoleUI.StarMenu();
                switch (option)
                {
                    case 1:
                        ConsoleUI.ShowRepo(GlobalRepoControl<Star>.GetRepository());
                        break;
                    case 2:
                        Console.WriteLine("Work in progress!");
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Work in progress!");
                        break;
                    case 6:
                        break;
                    case 7:
                        Console.WriteLine("Work in progress!");
                        break;
                    case 8:
                        Console.WriteLine("Work in progress!");
                        break;
                    default:
                        break;
                }
            }
        }

        public static bool ShowStar(StarDTO? element)
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

        public static bool CreateAndAdd()
        {
            string? name = ConsoleIO.ReadString("name");
            DateOnly? birthDate = ConsoleIO.GetDate();
            int? jobNum = ConsoleIO.ReadInt("job number");

            Star aux = StarService.Create(name, birthDate, jobNum);
            return GlobalRepoControl<Star>.AddElement(aux);
        }
    }
}
