namespace Cliffhanger
{
    public enum AccountType
    {
        Normal,
        Critic
    }

    public class User : Person
    {
        #region Constants
        const AccountType DefaultAccount = AccountType.Normal;
        static int AccountTypeLength = Enum.GetValues<AccountType>().Length;
        #endregion

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
            account = DefaultAccount;
        }

        public User(int id, string name, AccountType account) : base(id, name)
        {
            if (IsValidAccount(account)) this.account = account;
            else this.account = DefaultAccount;
        }
        #endregion

        #region Overrides
        #endregion

        #region Other Methods
        static bool IsValidAccount(AccountType account)
        {
            int aux = (int)account;
            if (aux >= 0 && aux < AccountTypeLength) return true;
            return false;
        }
        #endregion

        #endregion
    }
}
