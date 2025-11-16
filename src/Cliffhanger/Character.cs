using System.Diagnostics.Metrics;

namespace Cliffhanger
{
    public class Character
    {
        #region Constants
        const int MaxCharacters = 5;
        const int DefaultId = -1;
        const string DefaultName = "Unknown";
        const int StringMaxLength = 50;
        #endregion

        #region Attributes
        static Character[] groupOfCharacters = new Character[MaxCharacters];
        static int counter = 0;

        int characterId;
        string characterName = string.Empty;

        Actor actorWhoPlays;
        #endregion

        #region Methods

        #region Properties
        public int CharacterId
        {
            get { return characterId; }
            set
            {
                if (CheckId(value)) characterId = value;
            }
        }

        public string CharacterName
        {
            get { return characterName; }
            set
            {
                if (CheckName(value)) characterName = value;
            }
        }

        public Actor ActorWhoPlays
        {
            get { return actorWhoPlays; }
            set { actorWhoPlays = value; }
        }
        #endregion

        #region Constructors
        public Character()
        {
            characterId = DefaultId;
            characterName = DefaultName;

            // quando igualar a um ator, este fica a ocupar espaço
            actorWhoPlays = new Actor();

            if (counter < groupOfCharacters.Length) groupOfCharacters[counter++] = this;
        }

        public Character(int id, string name, Actor actorWhoPlays)
        {
            if (CheckId(id))
            {
                characterId = id;
            }
            else
            {
                characterId = DefaultId;
            }

            if (CheckName(name))
            {
                characterName = name;
            }
            else
            {
                characterName = DefaultName;
            }

            this.actorWhoPlays = actorWhoPlays;

            if (counter < groupOfCharacters.Length) groupOfCharacters[counter++] = this;
        }
        #endregion

        #region Other Methods
        static bool CheckId(int id)
        {
            if (id > DefaultId)
            {
                return true;
            }
            return false;
        }

        static bool CheckName(string name)
        {
            if (name.Length < StringMaxLength)
            {
                return true;
            }
            return false;
        }

        public static void ShowgroupOfCharacters()
        {
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Character Id:    " + groupOfCharacters[i].CharacterId);
                Console.WriteLine("Character Name:  " + groupOfCharacters[i].CharacterName);
                Console.WriteLine("Character Name:  " + groupOfCharacters[i].ActorWhoPlays.Name + "\n");
            }
        }
        #endregion

        #endregion
    }
}
