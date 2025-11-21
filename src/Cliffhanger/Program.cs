using System;

namespace Cliffhanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Star s1 = new Star();
            s1.Id = 10;
            s1.Name = "Steve Carell";
            s1.DateOfBirth = new DateOnly(1962, 8, 16);
            s1.Job = JobType.Actor;
            Star s2 = new Star(20, "Rainn Wilson", new DateOnly(1966, 1, 20), JobType.Writer);

            User u1 = new User(30, "MovieEnthusiast", AccountType.Normal);
            User u2 = new User();
            u2.Id = 40;
            u2.Name = "Mr. Critic";
            u2.Account = AccountType.Critic;
        }
    }
}
