namespace Cliffhanger
{
    /// <summary>
    /// Class that represents an character.
    /// Inherits the interface IElement.
    /// </summary>
    public class Character : IElement<Character>
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
        /// <summary>
        /// Property of attribute characterId.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public int CharacterId
        {
            get { return characterId; }
            set
            {
                if (CheckId(value)) characterId = value;
            }
        }

        /// <summary>
        /// Property of attribute characterName.
        /// If the variable value is valid, it's assigned.
        /// </summary>
        public string CharacterName
        {
            get { return characterName; }
            set
            {
                if (CheckName(value)) characterName = value;
            }
        }

        /// <summary>
        /// Property of attribute actorWhoPlays.
        /// If the variable value is valid, it's assigned.
        /// Before assigning the value, remove the Actor object created in the default constructor.
        /// </summary>
        public Actor ActorWhoPlays
        {
            get { return actorWhoPlays; }
            set
            {
                if (value != null)
                {
                    if (actorWhoPlays.Id == DefaultId)
                    {
                        Actor.RemoveElement(actorWhoPlays);
                    }
                    actorWhoPlays = value;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor of class Character.
        /// Assigns the default values.
        /// Creates a new object of type Actor.
        /// </summary>
        public Character()
        {
            characterId = DefaultId;
            characterName = DefaultName;

            actorWhoPlays = new Actor();

            AddElement(this);
        }

        /// <summary>
        /// Constructor with all the parameters of class Character.
        /// Checks and assigns the values ​​passed as parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="actorWhoPlays"></param>
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
        /// <summary>
        /// Checks if an id is valid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If the id is valid, returns true if it is invalid, returns false.
        /// </returns>
        static bool CheckId(int id)
        {
            if (id > DefaultId)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a name is valid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// If the name is valid, returns true if it is invalid, returns false.
        /// </returns>
        static bool CheckName(string name)
        {
            if (name.Length < StringMaxLength)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Implementation of method AddElement defined in interface IElement.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// If successful insertion occurs, returns true, otherwise, returns false.
        /// </returns>
        // não é aqui que se verifica se o ID é o mesmo!!!
        public static bool AddElement(Character element)
        {
            if (element == null) return false;

            if (counter < groupOfCharacters.Length)
            {
                groupOfCharacters[counter++] = element;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Implementation of method RemoveElement defined in interface IElement.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        /// If successful removal occurs, returns true, otherwise, returns false.
        /// </returns>
        public static bool RemoveElement(Character element)
        {
            if (element == null) return false;

            for (int i = 0; i < counter; i++)
            {
                if (groupOfCharacters[i] == element)
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

        /// <summary>
        /// Displays information about all elements of the array.
        /// </summary>
        public static void ShowgroupOfCharacters()
        {
            for (int i = 0; i < counter; i++)
            {
                Character? element = groupOfCharacters[i];
                if (element != null)
                {
                    Console.WriteLine("Character Id:    " + element.CharacterId);
                    Console.WriteLine("Character Name:  " + element.CharacterName);
                    Console.WriteLine("Character Name:  " + element.ActorWhoPlays.Name + "\n");
                }
            }
        }
        #endregion

        #endregion
    }
}
