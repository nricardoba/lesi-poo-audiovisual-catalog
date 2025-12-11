namespace BusinessObjects
{
    public static class Config
    {
        #region Constants
        public const int NameMaxLength = 50;
        public const string DefaultName = "Unknown";
        #endregion

        #region Methods
        public static bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > NameMaxLength)
                return false;
            return true;
        }
        #endregion
    }
}
