namespace EmployeeDirectory.Common
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public static ValidationResult OnSuccess()
        {
            return new ValidationResult
            {
                IsValid = true
            };
        }
        public static ValidationResult OnFailure(string message)
        {
            return new ValidationResult
            {
                IsValid = false,
                Message = message
            };
        }
    }
}
