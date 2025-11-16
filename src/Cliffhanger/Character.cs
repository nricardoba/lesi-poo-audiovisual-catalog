namespace Cliffhanger
{
    public class Character
    {
        #region Constants
        const int DefaultId = -1;
        const string DefaultName = "Unknown";
        const int StringMaxLength = 50;
        #endregion

        #region Attributes
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
        }
        #endregion

        #region Constructors
        public Character()
        {
            characterId = DefaultId;
            characterName = DefaultName;
            actorWhoPlays = new Actor();
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
        #endregion

        #endregion
    }
}
