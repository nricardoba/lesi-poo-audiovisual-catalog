using System;
using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            while (!end)
            {
                int option = ConsoleUI.MainMenu();
                switch (option)
                {
                    case 1:
                        StarExec.StarMenu();
                        break;
                    default:
                        end = true;
                        break;
                }

                if (!end)
                    ConsoleUI.Pause();
            }
        }
    }
}
