namespace Cliffhanger
{
    public class Character : Actor
    {
        #region Constants
        #endregion

        #region Attributes
        int characterId;
        string characterName = string.Empty;
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
        #endregion

        #region Constructors
        public Character() : base()
        {
            characterId = DefaultId;
            characterName = DefaultName;
        }
        #endregion

        #region Other Methods
        // depois dar override ao metodo CheckId, para verifocar se está na lista
        #endregion

        #endregion
    }
}
