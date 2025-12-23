using BusinessObjects;
using BusinessLogic;

namespace Presentation
{
    public static class ConsoleIO
    {
        public static string? ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int? ReadInt(string message)
        {
            string? input = ReadString(message);

            if (!int.TryParse(input, out int num))
                return null;

            return num;
        }

        public static string GetName(string message)
        {
            string? name = ReadString(message);

            if (name is null || !RuleValidator.IsNameValid(name))
                name = Config.DefaultName;

            return name;
        }

        public static DateOnly GetBirthDay(string message)
        {
            const int InvalidNum = 0;

            int? input = ReadInt(message + " year: ");
            int year = input != null ? (int)input : InvalidNum;

            input = ReadInt(message + " month: ");
            int month = input != null ? (int)input : InvalidNum;

            input = ReadInt(message + " day: ");
            int day = input != null ? (int)input : InvalidNum;

            if (!RuleValidator.IsBirthDateValid(year, month, day))
                return Config.DefaultDate;

            return new DateOnly(year, month, day);
        }

        public static JobType GetJob(string message)
        {
            const int InvalidJob = -1;

            int? input = ReadInt(message);
            int jobNum = input != null ? (int)input : InvalidJob;

            if (!IntegrityValidator.IsJobValid(jobNum))
                return Config.DefaultJob;

            return (JobType)jobNum;
        }
    }
}
