namespace Cliffhanger
{
    public static class ConsoleUI
    {
        public static string? ReadString(string message)
        {
            Console.Write(message + ": ");
            string? input = Console.ReadLine();

            return input;
        }

        public static int GetId(string message)
        {
            string? input = ReadString(message);

            bool success = int.TryParse(input, out int num);
            if (success) return num;
            else return Config.DefaultId;
        }

        public static string? GetNameOrTitle(string message)
        {
            string? input = ReadString(message);

            if (string.IsNullOrWhiteSpace(input))
                return null;

            return input;
        }

        public static DateOnly GetDate(string message)
        {
            string? input;
            bool success;
            int year, month, day;

            input = ReadString(message + " year: ");
            success = int.TryParse(input, out int yearNum);
            if (success && DateRules.IsYearValid(yearNum)) year = yearNum;
            else year = Config.CurrentYear;

            input = ReadString(message + " month: ");
            success = int.TryParse(input, out int monthNum);
            if (success && DateRules.IsMonthValid(monthNum)) month = monthNum;
            else month = Config.DefaultMonth;

            input = ReadString(message + " day: ");
            success = int.TryParse(input, out int dayNum);
            if (success && DateRules.IsDayValid(year, month, dayNum)) day = dayNum;
            else day = Config.DefaultDay;

            return new DateOnly(year, month, day);
        }

        public static JobType GetJob(string message)
        {
            string? input = ReadString(message);

            bool success = int.TryParse(input, out int jobNum);
            if (success)
            {
                if (Star.IsJobValid(jobNum)) return (JobType)jobNum;
            }

            return Config.DefaultJob;
        }

        public static AccountType GetAccount(string message)
        {
            string? input = ReadString(message);

            bool success = int.TryParse(input, out int accountNum);
            if (success)
            {
                AccountType aux = (AccountType)accountNum;
                if (User.IsAccountValid(aux)) return aux;
            }

            return Config.DefaultAccount;
        }
    }
}
