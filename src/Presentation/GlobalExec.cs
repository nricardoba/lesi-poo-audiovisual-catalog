using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class GlobalExec
    {
        public static void Save()
        {
            string message = GlobalRepoControl<Star>.Save(Config.StarFilePath)
                ? "Stars information saved successfully!"
                : "Unable to save Stars information!";
            Console.WriteLine(message);

            // vais adicionando tipos de objetos...
        }
        
        public static void Load()
        {
            if (GlobalRepoControl<Star>.Load(Config.StarFilePath))
            {
                // depois tiras isto
                Console.WriteLine("Stars information loaded successfully!");
                // vais adicionando tipos de objetos...
            }
            else
                Console.WriteLine("Unable to load information!");
        }
    }
}
