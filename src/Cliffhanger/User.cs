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
                if (IsValidAccount(value)) account = value;
            }
        }
        #endregion

        #region Constructors
        public User() : base()
        {
            account = ProgramConfig.DefaultAccount;
        }

        public User(int id, string name, AccountType account) : base(id, name)
        {
            if (IsValidAccount(account)) this.account = account;
            else this.account = ProgramConfig.DefaultAccount;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        static bool IsValidAccount(AccountType account)
        {
            int aux = (int)account;
            if (aux >= ProgramConfig.MinAccountType && aux < ProgramConfig.AccountTypeLength)
                return true;
            return false;
        }
        #endregion

        #endregion
    }
}
