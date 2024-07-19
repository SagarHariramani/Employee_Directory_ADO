using EmployeeDirectory.Common;
using EmployeeDirectory.Controller.Contract;
using EmployeeDirectory.Models;
using EmployeeDirectory.UI.Contract;

namespace EmployeeDirectory.UI.Menus
{

    public class RoleManagmentMenu:IRoleManagmentMenu
    {
        IRoleController _roleController;
        public RoleManagmentMenu(IRoleController roleController)
        {
            _roleController = roleController;
        }

        public void RoleManagmentMenuOptions()
        {
            Console.WriteLine(Constant.roleManagmentMenu);
            Console.Write(Constant.choice);
            int roleManagmentChoice = Parser.ParseToInt(Console.ReadLine()!);
            if (roleManagmentChoice==-1)
            {
                Console.WriteLine(Constant.invalidChoice+" "+Constant.selectAgain);
                RoleManagmentMenuOptions();
            }
            else
            {
                switch (roleManagmentChoice)
                {
                    case 1:
                        OptionAddRole();
                        break;
                    case 2:
                        OptionDisplayAllRoles();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine(Constant.invalidChoice);
                        break;
                }
            }

        }
        public string GetRoleName()
        {
            Console.Write(Constant.enterRoleName);
            string roleName = Console.ReadLine()!;
            ValidationResult RoleNameValidator = _roleController.ValidateRoleName(roleName);
            if (!RoleNameValidator.IsValid)
            {
                Console.WriteLine(RoleNameValidator.Message);
                string rName = GetRoleName();
                return rName;
            }
            else
            {
                return roleName;
            }
        }
        public  int GetLocationId()
        {
            int i = 1;
            List<Location> locations = _roleController.GetLocations();
            Console.WriteLine(Constant.locationDecorator);
            foreach (Location loc in locations)
            {
                Console.WriteLine(i + ". " + loc.Name);
                i++;
            }
            Console.Write("\n"+Constant.enterLocation);
            int selectedOption = int.Parse(Console.ReadLine()!);
            if (selectedOption > (locations.Count))
            {
                Console.WriteLine(Constant.invalidChoice);
                int empLocationId = GetLocationId();
                return empLocationId;
            }
            else
            {
                int locationId = locations[selectedOption - 1].ID;
                return locationId;
            }
        }
        public int GetDepartmentId()
        {
            int i = 1;
            List<Department> departments = _roleController.GetDepartments();
            Console.WriteLine(Constant.departmentDecorator);
            foreach (Department dep in departments)
            {
                Console.WriteLine(i + ". " + dep.Name);
                i++;
            }
            Console.Write("\n"+Constant.enterDepartment);
            int selectedOption = Parser.ParseToInt(Console.ReadLine()!);
            if (selectedOption > (departments.Count)||selectedOption<=0)
            {
                Console.WriteLine(Constant.invalidChoice);
                int empDepartmentId = GetDepartmentId();
                return empDepartmentId;
            }
            else
            {
                int departmentId = departments[selectedOption - 1].ID;
                return departmentId;
            }
        }
        public  string GetRoleDescription()
        {
            Console.Write(Constant.enterJobTitle);
            string roleDescription = Console.ReadLine()!;
            return roleDescription;
        }
        public void OptionAddRole()
        {
            Role role = new();
            Console.WriteLine(Constant.addRole);
            role.Name = GetRoleName();
            role.LocationId=GetLocationId();
            role.DepartmentId = GetDepartmentId();
            role.Description = GetRoleDescription();
            _roleController.Add(role);
            Console.WriteLine(Constant.roleAddedSuccessfully);
            Console.Write(Constant.addMoreRoleChoice);
            string addMoreChoice = Console.ReadLine()!.ToLower();
            if (addMoreChoice == "y")
            {
                OptionAddRole();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        public void OptionDisplayAllRoles()
        {
            int countRoleObj = _roleController.GetRoleCount();
            Console.WriteLine(Constant.roleTableDecorator);
            string header = string.Format("|{0,30}|{1,20}|{2,20}|{3,30}|", "Role Name", "Location", "Department", "Description");
            Console.WriteLine(header);
            Console.WriteLine(Constant.roleTableDecorator);
            List<Role> roleDataList = _roleController.GetRoles();
            for (int i = 0; i < roleDataList.Count; i++)
            {
                Role roleData = roleDataList[i];
                string formatedRoleData = string.Format("|{0,30}|{1,20}|{2,20}|{3,30}|", roleData.Name, _roleController.GetLocationNameById(roleData.LocationId), _roleController.GetDepartmentNameById(roleData.DepartmentId), roleData.Description);
                Console.WriteLine(formatedRoleData);
                Console.WriteLine(Constant.roleTableDecorator);
            }
        }
    }
}
