using System;

namespace Cliffhanger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int aux = Enum.GetValues<JobType>().Length;
            Console.WriteLine(aux);
        }
    }
}
