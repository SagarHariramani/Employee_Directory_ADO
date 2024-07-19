namespace EmployeeDirectory.UI
{
    public class Parser
    {
        public static int ParseToInt(string inputString)
        {
            bool isValidInput=int.TryParse(inputString, out int result);
            if (isValidInput)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
