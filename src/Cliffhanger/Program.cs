using System;

namespace Cliffhanger
{
    class Program
    {
        static void Main(string[] args)
        {
            StarRepository starGlobalRepo = new StarRepository();
            UserRepository userGlobalRepo = new UserRepository();

            Star s1 = new Star();
            s1.Id = 10;
            s1.Name = "Steve Carell";
            s1.DateOfBirth = new DateOnly(1962, 8, 16);
            s1.Job = JobType.Actor;
            starGlobalRepo.AddElement(s1);

            Star s2 = new Star(20, "Rainn Wilson", new DateOnly(1966, 1, 20), JobType.Writer);
            starGlobalRepo.AddElement(s2);

            User u1 = new User(30, "MovieEnthusiast", AccountType.Normal);
            userGlobalRepo.AddElement(u1);

            User u2 = new User();
            u2.Id = 40;
            u2.Name = "Mr. Critic";
            u2.Account = AccountType.Critic;
            userGlobalRepo.AddElement(u2);

            Star s3 = new Star(30, "Christopher Nolan", new DateOnly(1970, 7, 30), JobType.Director);
            starGlobalRepo.AddElement(s3);

            starGlobalRepo.ShowAllElements();
            userGlobalRepo.ShowAllElements();
        }
    }
}
