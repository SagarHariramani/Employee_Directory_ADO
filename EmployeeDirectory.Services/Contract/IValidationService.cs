using EmployeeDirectory.Common;

namespace EmployeeDirectory.Services.Contract
{
    public interface IValidationService
    {
        ValidationResult ValidateDate(string date);
        ValidationResult ValidateDepartment(string department);
        ValidationResult ValidateEmail(string email);
        ValidationResult ValidateEmailFormate(string email);
        ValidationResult ValidateEmployeeId(string empId);
        ValidationResult ValidateEmployeeIdFormate(string empId);
        ValidationResult ValidateEmployeeIdUnique(string empId);
        ValidationResult ValidateFirstName(string firstName);
        ValidationResult ValidateLastName(string lastName);
        ValidationResult ValidateLocation(string location);
        ValidationResult ValidateName(string name);
        ValidationResult ValidateNotEmpty(string inputField);
        ValidationResult ValidatePhoneNoFormate(string phoneNo);
        ValidationResult ValidatePhoneNumber(string phoneNo);
        ValidationResult ValidateRoleName(string roleName);
    }
}