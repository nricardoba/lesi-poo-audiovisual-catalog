/// <file>StarExec.cs</file>
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
    /// Execution of star menu options
    /// </summary>
    public class StarExec
    {
        /// <summary>
        /// Try to display the information of all elements in the Star repository on the console.
        /// </summary>
        public static void ShowRepo()
        {
            List<object> repository = GlobalRepoControl<Star>.GetRepository();

            if (repository.Count == 0)
            {
                Console.WriteLine("The repository is empty!");
                return;
            }

            foreach (object element in repository)
                ShowElement((Star)element);
        }

        /// <summary>
        /// Attempts to display all information about an object of type Star in the console.
        /// </summary>
        /// <param name="element"></param>
        public static void ShowElement(Star? element)
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

        /// <summary>
        /// It asks the user for an ID and if there is an element with that ID,
        /// it displays it in the console.
        /// </summary>
        public static void ShowById()
        {
            Guid? id = ConsoleIO.GetId();
            object? element = GlobalRepoControl<Star>.GetElementById(id ?? Config.InvalidId);
            ShowElement((Star?)element);
        }

        /// <summary>
        /// It asks the user for an index and if there is an element with that index,
        /// it displays it in the console.
        /// </summary>
        public static void ShowByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            object? element = GlobalRepoControl<Star>.GetElementByIndex(index ?? Config.InvalidIndex);
            ShowElement((Star?)element);
        }

        /// <summary>
        /// Asks the user for information about a Star on the console.
        /// Attempts to create and add that Star to the repository.
        /// </summary>
        public static void CreateAndAdd()
        {
            bool inputSuccess = ConsoleIO.GetStarInfo(out string? name,
                out DateOnly? birthDate, out int? jobNum);

            Star auxStar = StarService.Create(name, birthDate, jobNum);
            bool success = GlobalRepoControl<Star>.AddElement(auxStar);

            Console.WriteLine();
            string message = success
                ? "Star added successfully!"
                : "Star is invalid or already exists!";

            Console.WriteLine(message);
        }

        /// <summary>
        /// Asks the user for an ID.
        /// If there is a Star with that ID, it removes it from the repository.
        /// </summary>
        public static void RemoveById()
        {
            Guid? id = ConsoleIO.GetId();
            bool success = GlobalRepoControl<Star>.RemoveElementById(id ?? Config.InvalidId);

            string message = success
                ? "Star removed successfully!"
                : "Id is invalid!";

            Console.WriteLine(message);
        }

        /// <summary>
        /// Asks the user for an index.
        /// If there is a Star with that index, it removes it from the repository.
        /// </summary>
        public static void RemoveByIndex()
        {
            int? index = ConsoleIO.ReadInt("index");
            bool success = GlobalRepoControl<Star>.RemoveElementByIndex(index ?? Config.InvalidIndex);

            string message = success
                ? "Star removed successfully!"
                : "Index is invalid!";

            Console.WriteLine(message);
        }

        /// <summary>
        /// It asks the user for an ID and new information about the Star.
        /// If the ID exists and the information about the Star is valid,
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

            object? element = GlobalRepoControl<Star>.GetElementById((Guid)id);
            if (element is null)
            {
                Console.WriteLine("There is no element with id: " + id + "!");
                return;
            }
            
            bool inputSuccess = ConsoleIO.GetStarInfo(out string? name,
                out DateOnly? birthDate, out int? jobNum);
            if (!inputSuccess)
            {
                Console.WriteLine("Invalid info!");
                return;
            }

            bool editSuccess = StarService.Edit((Star)element, name, birthDate, jobNum);
            if (!editSuccess)
            {
                Console.WriteLine("Star cannot be edited!");
                return;
            }

            Console.WriteLine("Star edited successfully!");
        }

        /// <summary>
        /// It asks the user for an index and new information about the Star.
        /// If the index exists and the information about the Star is valid,
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

            object? element = GlobalRepoControl<Star>.GetElementByIndex((int)index);
            if (element is null)
            {
                Console.WriteLine("There is no element with index: " + index + "!");
                return;
            }
            
            bool inputSuccess = ConsoleIO.GetStarInfo(out string? name,
                out DateOnly? birthDate, out int? jobNum);
            if (!inputSuccess)
            {
                Console.WriteLine("Invalid info!");
                return;
            }

            bool editSuccess = StarService.Edit((Star)element, name, birthDate, jobNum);
            if (!editSuccess)
            {
                Console.WriteLine("Star cannot be edited!");
                return;
            }

            Console.WriteLine("Star edited successfully!");
        }

        /// <summary>
        /// Sort the repository.
        /// </summary>
        public static void SortRepository()
        {
            string message = GlobalRepoControl<Star>.SortRepository()
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
                if (GlobalRepoControl<Star>.Save(Config.StarFilePath))
                    Console.WriteLine("Stars information saved successfully!");
                else
                    Console.WriteLine("Stars file does not exist!");
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
                if (GlobalRepoControl<Star>.Load(Config.StarFilePath))
                    Console.WriteLine("Stars information loaded successfully!");
                else
                    Console.WriteLine("Stars file does not exist!");
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
