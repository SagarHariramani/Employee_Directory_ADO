using EmployeeDirectory.Common;
using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Contract;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EmployeeDirectory.Services.Common
{
    public class ValidationService : IValidationService
    {
        IEmployeeHandler _employeeHandler;
        public ValidationService(IEmployeeHandler employeeHandler)
        {
            _employeeHandler = employeeHandler;
        }

        public ValidationResult ValidateNotEmpty(string inputField)
        {
            if (string.IsNullOrEmpty(inputField))
            {
                return ValidationResult.OnFailure("This field is required so cannot be empty");
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateEmployeeIdFormate(string empId)
        {
            var employeeIdRegex = @"^TZ\d{4}$";
            if (!Regex.IsMatch(empId, employeeIdRegex))
            {
                return ValidationResult.OnFailure("This Employee Id Isn't valid Try in this formate (TZ1234)");
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateEmployeeIdUnique(string empId)
        {
            List<Employee> employeeDataList = _employeeHandler.GetEmployees();
            if (employeeDataList.Any(emp => emp.EmpId == empId))
            {
                return ValidationResult.OnFailure("This Employee Id already Exist in the DataBase Try Different one..");
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateName(string name)
        {
            var nameRegex = @"^(?!\s+$)[a-zA-Z\s]+$";
            if (!Regex.IsMatch(name, nameRegex))
            {
                return ValidationResult.OnFailure("Please Enter Alphabets only");
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateEmailFormate(string email)
        {
            var emailRegex = @"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$";
            if (!Regex.IsMatch(email, emailRegex))
            {
                return ValidationResult.OnFailure("Please enter the correct Email");
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidatePhoneNoFormate(string phoneNo)
        {
            var phoneNoRegex = @"^\d{10}$";
            if (!Regex.IsMatch(phoneNo, phoneNoRegex))
            {
                return ValidationResult.OnFailure("Enter the Valid Phone No. of 10 Digits");
            }
            return ValidationResult.OnSuccess();

        }
        public ValidationResult ValidateDate(string date)
        {
            bool isDateValid = DateOnly.TryParse(date, CultureInfo.CurrentCulture, out DateOnly dateOutput);
            if (isDateValid)
            {
                return ValidationResult.OnSuccess();
            }
            else
            {
                return ValidationResult.OnFailure("Invalid Date Input ");
            }
        }
        public ValidationResult ValidateEmployeeId(string empId)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(empId);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult formatValidationResult = ValidateEmployeeIdFormate(empId);
            if (!formatValidationResult.IsValid)
            {
                return formatValidationResult;
            }
            ValidationResult uniqueValidation = ValidateEmployeeIdUnique(empId);
            if (!uniqueValidation.IsValid)
            {
                return uniqueValidation;
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateFirstName(string firstName)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(firstName);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult validateFirstName = ValidateName(firstName);
            if (!validateFirstName.IsValid)
            {
                return validateFirstName;
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateLastName(string lastName)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(lastName);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult validateLastName = ValidateName(lastName);
            if (!validateLastName.IsValid)
            {
                return validateLastName;
            }
            return ValidationResult.OnSuccess();
        }

        public ValidationResult ValidateEmail(string email)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(email);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult validateEmail = ValidateEmailFormate(email);
            if (!validateEmail.IsValid)
            {
                return validateEmail;
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidatePhoneNumber(string phoneNo)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(phoneNo);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult validatePhoneNo = ValidatePhoneNoFormate(phoneNo);
            if (!validatePhoneNo.IsValid)
            {
                return validatePhoneNo;
            }
            return ValidationResult.OnSuccess();
        }

        public ValidationResult ValidateRoleName(string roleName)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(roleName);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult validateRoleName = ValidateName(roleName);
            if (!validateRoleName.IsValid)
            {
                return validateRoleName;
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateLocation(string location)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(location);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult validateLocationName = ValidateName(location);
            if (!validateLocationName.IsValid)
            {
                return validateLocationName;
            }
            return ValidationResult.OnSuccess();
        }
        public ValidationResult ValidateDepartment(string department)
        {
            ValidationResult emptyValidationResult = ValidateNotEmpty(department);
            if (!emptyValidationResult.IsValid)
            {
                return emptyValidationResult;
            }
            ValidationResult validateDepartmentName = ValidateName(department);
            if (!validateDepartmentName.IsValid)
            {
                return validateDepartmentName;
            }
            return ValidationResult.OnSuccess();
        }

    }
}
