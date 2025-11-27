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
                if (IsAccountValid(value)) account = value;
            }
        }
        #endregion

        #region Constructors
        public User() : base()
        {
            account = Config.DefaultAccount;
        }

        public User(int id, string name, AccountType account) : base(id, name)
        {
            if (IsAccountValid(account)) this.account = account;
            else this.account = Config.DefaultAccount;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        public static bool IsAccountValid(AccountType account)
        {
            int aux = (int)account;
            if (aux >= Config.MinAccountType && aux < Config.AccountTypeLength)
                return true;
            return false;
        }
        #endregion

        #endregion
    }
}
