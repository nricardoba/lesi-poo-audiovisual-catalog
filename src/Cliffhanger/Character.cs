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
        static Character?[] groupOfCharacters = new Character[MaxCharacters];
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
            set
            {
                if (value != null)
                {
                    Actor.RemoveElement(actorWhoPlays);
                    actorWhoPlays = value;
                }
            }
        }
        #endregion

        #region Constructors
        public Character()
        {
            characterId = DefaultId;
            characterName = DefaultName;

            // quando igualar a um ator, este fica a ocupar espaço
            actorWhoPlays = new Actor();

            AddElement(this);
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

            AddElement(this);
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

        // não é aqui que se verifica se o ID é o mesmo!!!
        static bool AddElement(Character aux)
        {
            if (aux == null) return false;

            if (counter < groupOfCharacters.Length)
            {
                groupOfCharacters[counter++] = aux;
                return true;
            }

            return false;
        }

        // usar interface para estes métodos
        static bool RemoveElement(Character aux)
        {
            if (aux == null) return false;

            for (int i = 0; i < counter; i++)
            {
                if (groupOfCharacters[i] == aux)
                {
                    for (int j = i; j < counter - 1; j++)
                    {
                        groupOfCharacters[j] = groupOfCharacters[j + 1];
                    }

                    groupOfCharacters[counter - 1] = null;
                    counter--;
                    return true;
                }
            }

            return false;
        }

        public static void ShowgroupOfCharacters()
        {
            for (int i = 0; i < counter; i++)
            {
                Character? aux = groupOfCharacters[i];
                if (aux != null)
                {
                    Console.WriteLine("Character Id:    " + aux.CharacterId);
                    Console.WriteLine("Character Name:  " + aux.CharacterName);
                    Console.WriteLine("Character Name:  " + aux.ActorWhoPlays.Name + "\n");
                }
            }
        }
        #endregion

        #endregion
    }
}
