using System;

namespace Cliffhanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Star s1 = new Star();
            StarRepository.AddElement(s1);
            s1.Id = 10;
            s1.Name = "Steve Carell";
            s1.DateOfBirth = new DateOnly(1962, 8, 16);
            s1.Job = JobType.Actor;

            Star s2 = new Star(20, "Rainn Wilson", new DateOnly(1966, 1, 20), JobType.Writer);
            StarRepository.AddElement(s2);

            User u1 = new User(30, "MovieEnthusiast", AccountType.Normal);
            UserRepository.AddElement(u1);

            User u2 = new User();
            UserRepository.AddElement(u2);
            u2.Id = 40;
            u2.Name = "Mr. Critic";
            u2.Account = AccountType.Critic;

            Star s3 = new Star(30, "Christopher Nolan", new DateOnly(1970, 7, 30), JobType.Director);
            StarRepository.AddElement(s3);

            StarRepository.ShowAllElements();
            UserRepository.ShowAllElements();
        }
    }
}
