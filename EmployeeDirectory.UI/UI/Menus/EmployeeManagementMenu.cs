using EmployeeDirectory.Common;
using EmployeeDirectory.Controller.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.UI.Contract;
using static EmployeeDirectory.Models.Enums;

namespace EmployeeDirectory.UI.Menus
{
    public class EmployeeManagementMenu:IEmployeeManagementMenu
    {
        IEmployeeController _employeeController;
        IRoleController _roleController;
        
        public EmployeeManagementMenu(IEmployeeController employeeController,IRoleController roleController)
        {
            this._employeeController = employeeController;
            this._roleController = roleController;
        }

        public void EmployeeManagmentMenuOptions()
        {
            Console.WriteLine(Constant.employeeMenu);
            Console.Write(Constant.choice);
            int employeeMangementChoice = Parser.ParseToInt(Console.ReadLine()!);
            if (employeeMangementChoice==-1)
            {
                Console.WriteLine(Constant.invalidChoice+Constant.selectAgain);
                EmployeeManagmentMenuOptions();
            }
            else
            {
                switch (employeeMangementChoice)
                {
                    case 1:
                        OptionAddEmployee();
                        break;
                    case 2:
                        OptionDisplayAllEmployeeData();
                        break;
                    case 3:
                        OptionDisplayEmployeeById();
                        break;
                    case 4:
                        Console.WriteLine(Constant.editEmployeeDecorator);
                        Console.Write(Constant.enterEmployeeId);
                        string employeeID = Console.ReadLine()!;
                        Employee employeeData = _employeeController.GetDataById(employeeID)!;
                        if (!(employeeData == null ))
                        {
                            DisplayEmployeeData(employeeData);
                            OptionEditEmployee(employeeData, employeeID);
                        }
                        else
                        {
                            Console.WriteLine(Constant.employeeWithEmployeeId + employeeID + Constant.notFound);
                        }
                        break;
                    case 5:
                        OptionDeleteParticularEmployee();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine(Constant.invalidChoice);
                        break;

                }
            }
        }
        public  string GetEmployeeId()
        {
            Console.Write(Constant.enterEmployeeId);
            string employeeId = (Console.ReadLine()!);
            ValidationResult employeeIdValidator = _employeeController.ValidateEmployeeId(employeeId);
            if (!employeeIdValidator.IsValid)
            {
                Console.WriteLine(employeeIdValidator.Message);
                string empId = GetEmployeeId();
                return empId;
            }
            else
            {
                return employeeId;
            }
        }
        public  string GetFirstName()
        {
            Console.Write(Constant.enterFirstName);
            string firstName = (Console.ReadLine()!);
            ValidationResult firstNameValidator = _employeeController.ValidateFirstName(firstName);
            if (!firstNameValidator.IsValid)
            {
                Console.WriteLine(firstNameValidator.Message);
                string empFirstName = GetFirstName();
                return empFirstName;
            }
            else
            {
                return firstName;
            }
        }
        public  string GetLastName()
        {
            Console.Write(Constant.enterLastName);
            string lastName = (Console.ReadLine()!);
            ValidationResult lastNameValidator = _employeeController.ValidateLastName(lastName);
            if (!lastNameValidator.IsValid)
            {
                Console.WriteLine(lastNameValidator.Message);
                string empLastName = GetLastName();
                return empLastName;
            }
            else
            {
                return lastName;
            }
        }
        public  DateTime GetDob()
        {
            Console.Write(Constant.enterDob);
            string dob = (Console.ReadLine()!);
            ValidationResult dobValidator = _employeeController.ValidateDate(dob);
            if (!dobValidator.IsValid)
            {
                Console.WriteLine(dobValidator.Message);
                return GetDob();
            }
            else
            {
                return DateTime.Parse(dob);
            }

        }
        public string GetEmail()
        {
            Console.Write(Constant.enterEmail);
            string email = (Console.ReadLine()!);
            ValidationResult emailValidator = _employeeController.ValidateEmail(email);
            if (!emailValidator.IsValid)
            {
                Console.WriteLine(emailValidator.Message);
                string empEmail = GetEmail();
                return empEmail;
            }
            else
            {
                return email;
            }
        }
        public string GetPhoneNumber()
        {
            Console.Write(Constant.enterPhoneNo);
            string phoneNo = (Console.ReadLine()!);
            ValidationResult phoneNumberValidator = _employeeController.ValidatePhoneNumber(phoneNo);
            if (!phoneNumberValidator.IsValid)
            {
                Console.WriteLine(phoneNumberValidator.Message);
                string empPhoneNo = GetPhoneNumber();
                return empPhoneNo;
            }
            else
            {
                return phoneNo;
            }
        }
        public  DateTime GetJoiningDate()
        {
            Console.Write(Constant.enterJoiningDate);
            string joiningDate = (Console.ReadLine()!);
            ValidationResult joiningDateValidator = _employeeController.ValidateDate(joiningDate);
            if (joiningDateValidator.IsValid)
            {
                return DateTime.Parse(joiningDate);
            }
            else
            {
                Console.WriteLine(joiningDateValidator.Message);
                return GetJoiningDate();
            }

        }
        public int GetLocationId()
        {
            int i = 1;
            List<Location> locations =_roleController.GetLocations();
           
            Console.WriteLine(Constant.locationMenuDecorator);
            foreach (Location loc in locations)
            {
                Console.WriteLine(i + ". " + loc.Name);
                i++;
            }
            Console.Write("\n"+Constant.enterLocation);
            int selectedOption = Parser.ParseToInt(Console.ReadLine()!);
            if (selectedOption > (locations.Count) || selectedOption<=0)
            {
                Console.WriteLine(Constant.invalidChoice+" "+Constant.selectAgain);
                int empLocation = GetLocationId();
                return empLocation;
            }
            else
            {
                int location = locations[selectedOption - 1].ID;
                return location;
            }
        }
        public int GetDepartmentId(int location)
        {
            int selectedLocation = location;
            int i = 1;
            List<Department> departments = [];
            for (int j = 1; j <= _roleController.GetRoleCount(); j++)
            {
                if (selectedLocation == _roleController.GetDataById(j)!.LocationId)
                {
                    departments.Add(_roleController.GetDepartmentById(_roleController.GetDataById(j)!.DepartmentId)!);
                }
            }
            Department[] uniqueDepartments = departments.Distinct().ToArray();
            Console.WriteLine(Constant.departmentMenuDecorator);
            foreach (Department dep in uniqueDepartments)
            {
                Console.WriteLine(i + ". " + dep.Name);
                i++;
            }
            Console.Write("\n"+Constant.enterDepartment);
            int departmentChoice = Parser.ParseToInt(Console.ReadLine()!);
            if (departmentChoice > (uniqueDepartments.Length + 1) || departmentChoice<=0)
            {
                Console.WriteLine(Constant.invalidChoice + " " + Constant.selectAgain);
                int empDepartmentId = GetDepartmentId(selectedLocation);
                return empDepartmentId;
            }
            else
            {
                int departmentId = uniqueDepartments[departmentChoice - 1].ID;
                return departmentId;
            }
        }
        public string GetJobTitle(int location, int department)
        {
            int selectedLocation = location;
            int selectedDepartment = department;
            List<string> jobTitles = [];
            int i = 1;
            for (int j = 1; j <= _roleController.GetRoleCount(); j++)
            {
                if (selectedLocation == _roleController.GetDataById(j)!.LocationId)
                {
                    if (selectedDepartment == _roleController.GetDataById(j)!.DepartmentId)
                    {
                        jobTitles.Add(_roleController.GetDataById(j)!.Name);
                    }
                }
            }
            string[] uniqueJobTitles = jobTitles.Distinct().ToArray();
            Console.WriteLine(Constant.jobTitleDecorator);
            foreach (string jobtitle in uniqueJobTitles)
            {
                Console.WriteLine(i + ". " + jobtitle);
                i++;
            }

            Console.Write("\n"+Constant.enterJobTitle);
            int jobTitleChoice = Parser.ParseToInt(Console.ReadLine()!);
            if (jobTitleChoice > (uniqueJobTitles.Length + 1) || jobTitleChoice<=0)
            {
                Console.WriteLine(Constant.invalidChoice + " " + Constant.selectAgain);
                string empJobTitle = GetJobTitle(selectedLocation, selectedDepartment);
                return empJobTitle;
            }
            else
            {
                string jobTitle = uniqueJobTitles[jobTitleChoice - 1];
                return jobTitle;
            }
        }
        public int GetManagerId()
        {
            int i = 1;
            List<Manager> managerList = _employeeController.GetMangers();
            foreach (Manager manager in managerList)
            {
                Console.WriteLine(i + ". " + manager.Name);
                i++;
            }
            Console.Write(Constant.enterManager);
            int managerChoice  = Parser.ParseToInt(Console.ReadLine()!);
            if (managerChoice > (managerList.Count)||managerChoice<=0)
            {
                Console.WriteLine(Constant.invalidChoice + " " + Constant.selectAgain);
                int manager = GetManagerId();
                return manager;
            }
            else
            {
                int manager = managerList[managerChoice - 1].ID;
                return manager;
            }
        }
        public int? GetProjectId()
        {
            int i = 1;
            List<Project> projectList = _employeeController.GetProjects();
            foreach (Project project in projectList)
            {
                Console.WriteLine(i + ". " + project.Name);
                i++;
            }
            Console.Write(Constant.enterProject);
            int projectChoice = Parser.ParseToInt(Console.ReadLine()!);
            if (projectChoice<=0)
            {
                
                return null;
            }
            else
            {
                int project = projectList[projectChoice - 1].ID;
                return project;
            }
        }
        public void OptionDisplayEmployeeById()
        {
            Console.WriteLine(Constant.displayParticularEmployeeDecorator);
            Console.Write(Constant.enterEmployeeId);
            string employeeId = Console.ReadLine()!;
            Employee employeeData = _employeeController.GetDataById(employeeId)!;
            if (employeeData == null)
            {
                Console.WriteLine(Constant.employeeWithEmployeeId+ employeeId + Constant.notFound);
            }
            else
            {
                Console.WriteLine(Constant.tableDecorator);
                string header = string.Format("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", "EmpID", "Name", "Role", "Department", "Location", "Join Date", "Manager Name", "Project Name");
                Console.WriteLine(header);
                Console.WriteLine(Constant.tableDecorator);
                Role roleDetail = _roleController.GetDataById((int)employeeData.RoleId!)!;
                Console.WriteLine("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", employeeData.EmpId, employeeData.FirstName + " " + employeeData.LastName, roleDetail.Name, _roleController.GetDepartmentNameById(roleDetail.DepartmentId), _roleController.GetLocationNameById(roleDetail.LocationId), employeeData.JoiningDate, employeeData.ManagerId, employeeData.ProjectId);
                Console.WriteLine(Constant.tableDecorator);

            }

        }
        public void OptionAddEmployee()
        {
            Employee emp = new();
            Console.WriteLine(Constant.addEmployeeDecorator);
            emp.EmpId = GetEmployeeId();
            emp.FirstName = GetFirstName();
            emp.LastName = GetLastName();
            emp.Dob = GetDob();
            emp.Email = GetEmail();
            emp.PhoneNo = GetPhoneNumber();
            emp.JoiningDate = GetJoiningDate();
            int location = GetLocationId();
            int department = GetDepartmentId(location);
            string jobTitle = GetJobTitle(location, department);
            emp.ManagerId = GetManagerId();
            emp.ProjectId = GetProjectId();
            emp.RoleId = _roleController.GetRoleId(jobTitle,location, department)!;
            emp.IsDeleted = false;
            _employeeController.Add(emp);
            Console.WriteLine(Constant.employeeAddedSuccessFully);
            Console.Write(Constant.addMoreEmployee);
            string addMoreChoice = Console.ReadLine()!.ToLower();
            if (addMoreChoice == "y")
            {
                OptionAddEmployee();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public void OptionDisplayAllEmployeeData()
        {
            Console.WriteLine(Constant.displayAllEmployee);
            Console.WriteLine(Constant.tableDecorator);
            string header = string.Format("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", "EmpID", "Name", "Role", "Department", "Location", "Join Date", "Manager Name", "Project Name");
            Console.WriteLine(header);
            Console.WriteLine(Constant.tableDecorator);
            List<Employee> employeeDataList = _employeeController.GetEmployees();
            for (int i = 0; i < employeeDataList.Count; i++)
            {
                Employee empData = employeeDataList[i];
                Role roleDetail = _roleController.GetDataById(empData.RoleId!)!;
                if(roleDetail != null)
                {
                    string employeeData = string.Format("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", empData.EmpId, empData.FirstName + " " + empData.LastName, roleDetail.Name, _roleController.GetDepartmentNameById(roleDetail.DepartmentId), _roleController.GetLocationNameById(roleDetail.LocationId), empData.JoiningDate, _employeeController.GetManagerName(empData.ManagerId), _employeeController.GetProjectName(empData.ProjectId));
                    Console.WriteLine(employeeData);
                }else
                {
                    string employeeData = string.Format("|{0,10}|{1,25}|{2,30}|{3,20}|{4,15}|{5,20}|{6,20}|{7,20}|", empData.EmpId, empData.FirstName + " " + empData.LastName, null,null, null, empData.JoiningDate, _employeeController.GetManagerName(empData.ManagerId), _employeeController.GetProjectName(empData.ProjectId));
                    Console.WriteLine(employeeData);
                }
                Console.WriteLine(Constant.tableDecorator);
                
            }
            Console.WriteLine();
        }
        public void DisplayEmployeeData(Employee employeeData)
        {
            Console.WriteLine(Constant.firstName+ employeeData.FirstName);
            Console.WriteLine(Constant.lastName + employeeData.LastName);
            Console.WriteLine(Constant.dob + employeeData.Dob);
            Console.WriteLine(Constant.email + employeeData.Email);
            Console.WriteLine(Constant.phoneNo + employeeData.PhoneNo);
            Console.WriteLine(Constant.joiningDate + employeeData.JoiningDate);
            Role roleDetail = _roleController.GetDataById(employeeData.RoleId!)!;
            if (roleDetail != null)
            {
                Console.WriteLine(Constant.location + _roleController.GetLocationNameById(roleDetail.LocationId));
                Console.WriteLine(Constant.jobTitle + roleDetail.Name);
                Console.WriteLine(Constant.department+ _roleController.GetDepartmentNameById(roleDetail.DepartmentId));
            }
            else
            {
                Console.WriteLine(Constant.location+ "");
                Console.WriteLine(Constant.jobTitle + "");
                Console.WriteLine(Constant.department + "");
            }
            Console.WriteLine(Constant.managerName + _employeeController.GetManagerName(employeeData.ManagerId));
            Console.WriteLine(Constant.projectName+ _employeeController.GetProjectName(employeeData.ProjectId));
        }
        public void OptionEditEmployee(Employee employeeData, string employeeID)
        {
            Console.Write(Constant.fieldChoice);
            int choice = int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    string firstName = GetFirstName();
                    _employeeController.Edit(employeeID, EmployeeField.FirstName,firstName);
                    Console.WriteLine(Constant.firstNameChanged);
                    break;
                case 2:
                    string lastName = GetLastName();
                    _employeeController.Edit(employeeID,EmployeeField.LastName, lastName);
                    Console.WriteLine(Constant.lastNameChanged);
                    break;
                case 3:
                    DateTime dob = GetDob();
                    _employeeController.Edit(employeeID,EmployeeField.Dob ,dob);
                    Console.WriteLine(Constant.dobChanged);
                    break;
                case 4:
                    string email = GetEmail();
                    _employeeController.Edit(employeeID,EmployeeField.Email,email);
                    Console.WriteLine(Constant.emailChanged);
                    break;
                case 5:
                    string phoneNo = GetPhoneNumber();
                    _employeeController.Edit(employeeID,EmployeeField.PhoneNo ,phoneNo);
                    Console.WriteLine(Constant.phoneNoChanged);
                    break;
                case 6:
                    DateTime joiningDate = GetJoiningDate();
                    _employeeController.Edit(employeeID, EmployeeField.JoiningDate,joiningDate);
                    Console.WriteLine(Constant.joiningDateChanged);
                    break;
                case 7:
                    int changedLocation = GetLocationId();
                    int changedDepartment = GetDepartmentId(changedLocation);
                    string changedJobTitle = GetJobTitle(changedLocation, changedDepartment);
                    int? roleId = _roleController.GetRoleId(changedJobTitle,changedLocation, changedDepartment)!;
                    _employeeController.Edit(employeeID,EmployeeField.RoleId ,roleId);
                    Console.WriteLine(Constant.locationDepartmentJobTitleChanged);
                    break;
                case 8:
                    goto case 7;
                case 9:
                    goto case 7;
                case 10:
                    int manager = GetManagerId();
                    _employeeController.Edit(employeeID,EmployeeField.ManagerId, manager);
                    Console.WriteLine(Constant.managerNameChanged);
                    break;
                case 11:
                    int? project = GetProjectId();
                    _employeeController.Edit(employeeID,EmployeeField.ProjectId, project);
                    Console.WriteLine(Constant.projectNameChanged);
                    break;
                default:
                    Console.WriteLine(Constant.invalidChoice);
                    break;
            }
            Console.Write(Constant.editMoreField);
            string addMoreChoice = Console.ReadLine()!.ToLower();
            if (addMoreChoice == "y")
            {
                OptionEditEmployee(employeeData, employeeID);
            }
            else
            {
                Console.WriteLine(Constant.updatedDataDecorator);
                Employee updatedDetail=_employeeController.GetDataById(employeeID);
                DisplayEmployeeData(updatedDetail);
                Environment.Exit(0);
            }
        }
        public void OptionDeleteParticularEmployee()
        {
            Console.WriteLine(Constant.deleteEmployeeDecorator);
            Console.Write(Constant.enterEmployeeId);
            string empId = Console.ReadLine()!;
            Employee employeeData = _employeeController.GetDataById(empId)!;
            if (employeeData == null)
            {
                Console.WriteLine(Constant.employeeWithEmployeeId + empId + Constant.notFound);
            }
            else
            {
                _employeeController.Delete(empId);
                Console.WriteLine(Constant.employeeWithEmployeeId + empId + Constant.deletedSuccessfully);
            }

        }
    }

}
