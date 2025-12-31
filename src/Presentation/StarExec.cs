using BusinessObjects;
using BusinessLogic;
using Exceptions;

namespace Presentation
{
    /// <summary>
    /// Execution of star menu options
    /// </summary>
    public static class StarExec
    {
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

        public static void ShowElement(StarDTO? element)
        {
            if (element is null)
                Console.WriteLine("Invalid Star!");
            else
            {
                Console.WriteLine("ID: " + element.Id);
                Console.WriteLine("Name: " + element.Name);
                Console.WriteLine("BirthDate: " + element.BirthDate);
                Console.WriteLine("Job: " + element.Job + "\n");
            }
        }

        public static void ShowById()
        {
            Guid? id = ConsoleIO.GetId();
            var element = GlobalRepoControl<Star>.GetElementById(id ?? Config.InvalidId);
            ShowElement((StarDTO?)element);
        }

        public static void ShowByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            var element = GlobalRepoControl<Star>.GetElementByIndex(index ?? Config.InvalidIndex);
            ShowElement((StarDTO?)element);
        }

        public static void CreateAndAdd()
        {
            StarDTO dto = ConsoleIO.GetStarInfo();
            Star auxStar = StarService.Create(dto);
            bool success = GlobalRepoControl<Star>.AddElement(auxStar);

            Console.WriteLine();
            string message = success
                ? "Star added successfully!"
                : "Star is invalid or already exists!";

            Console.WriteLine(message);
        }

        public static void RemoveById()
        {
            Guid? id = ConsoleIO.GetId();
            bool success = GlobalRepoControl<Star>.RemoveElementById(id ?? Config.InvalidId);

            string message = success
                ? "Star removed successfully!"
                : "Id is invalid!";

            Console.WriteLine(message);
        }

        public static void RemoveByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            bool success = GlobalRepoControl<Star>.RemoveElementByIndex(index ?? Config.InvalidIndex);

            string message = success
                ? "Star removed successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }

        public static void EditById()
        {
            Guid? id = ConsoleIO.GetId();
            StarDTO dto = ConsoleIO.GetStarInfo();
            bool success = GlobalRepoControl<Star>.EditElementById(id ?? Config.InvalidId, dto);

            string message = success
                ? "Star edited successfully!"
                : "Id is invalid!";

            Console.WriteLine(message);
        }

        public static void EditByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            StarDTO dto = ConsoleIO.GetStarInfo();
            bool success = GlobalRepoControl<Star>.EditElementByIndex(index ?? Config.InvalidIndex, dto);

            string message = success
                ? "Star edited successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }

        public static void Save()
        {
            try
            {
                if (GlobalRepoControl<Star>.Save(Config.StarFilePath))
                    Console.WriteLine("Stars information saved successfully!");
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
                if (GlobalRepoControl<Star>.Load(Config.StarFilePath))
                    Console.WriteLine("Stars information loaded successfully!");
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
