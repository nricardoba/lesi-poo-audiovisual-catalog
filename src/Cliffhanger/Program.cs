using System;

namespace Cliffhanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor actor1 = new Actor();
            actor1.Name = "Pedro Pascal";
            actor1.DateOfBirth = new DateOnly(1975, 4, 2);
            actor1.Id = 10;

            Actor actor2 = new Actor(11, "Samuel L. Jackson", 1948, 12, 21);

            Character character1 = new Character();
            character1.CharacterName = "Jules Winnfield";
            character1.CharacterId = 8;
            character1.ActorWhoPlays = actor2;

            Actor actor3 = new Actor(7, "Rainn Wilson", 1966, 1, 20);

            Actor.ShowGroupOfActors();
            Character.ShowgroupOfCharacters();
        }
    }
}
