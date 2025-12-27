using BusinessObjects;

namespace Presentation
{
    public static class GenericExec
    {
        public static bool ShowElement(object? element)
        {
            if (element is null)
            {
                Console.WriteLine("Invalid Element!");
                return false;
            }

            var elementType = element.GetType();

            if (elementType == typeof(Star))
                return StarExec.ShowElement((StarDTO)element);

            // vais adicionando tipos de objetos...

            Console.WriteLine("Invalid Element!");
            return false;
        }

        public static bool ShowRepo(List<object>? repository)
        {
            if (repository is null || repository.Count == 0)
            {
                Console.WriteLine("The repository is null or empty!");
                return false;
            }

            foreach (object element in repository)
            {
                ShowElement(element);
                Console.WriteLine();
            }

            return true;
        }
    }
}
