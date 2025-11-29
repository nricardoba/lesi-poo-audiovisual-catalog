namespace Cliffhanger
{
    public enum AccountType
    {
        Normal,
        Critic
    }

    public class User : Person
    {
        #region Attributes
        AccountType account;
        #endregion

        #region Methods

        #region Properties
        public AccountType Account
        {
            get { return account; }
            set
            {
                if (IsAccountValid((int)value)) account = value;
            }
        }
        #endregion

        #region Constructors
        public User() : base()
        {
            account = Config.DefaultAccount;
        }

        public User(string name, AccountType account) : base(name)
        {
            if (IsAccountValid((int)account)) this.account = account;
            else this.account = Config.DefaultAccount;
        }
        #endregion

        #region Other Methods
        public static bool IsAccountValid(int accountNum)
        {
            if (accountNum >= Config.MinAccountType && accountNum < Config.AccountTypeLength)
                return true;
            
            return false;
        }
        #endregion

        #endregion
    }
}
