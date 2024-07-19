using EmployeeDirectory.UI.Contract;
using EmployeeDirectory.UI.Menus;

namespace EmployeeDirectory.UI
{
    public class MainMenuOptions:IMainMenu
    {
        IEmployeeManagementMenu _employeeManagementMenu;
        IRoleManagmentMenu _roleManagmentMenu;
        public MainMenuOptions(IEmployeeManagementMenu employeeManagementMenu,IRoleManagmentMenu roleManagmentMenu)
        {
            this._employeeManagementMenu = employeeManagementMenu;
            this._roleManagmentMenu = roleManagmentMenu;
        }
        public void DisplayMainMenuOptions()
        {
            _displayMainMenuOptions:
            Console.WriteLine(Constant.mainMenuOptions);
            Console.Write(Constant.choice);
            int mainMenuOptionChoice= Parser.ParseToInt(Console.ReadLine()!);
            if (mainMenuOptionChoice==-1)
            {
                Console.WriteLine(Constant.invalidChoice+" "+Constant.selectAgain);
                DisplayMainMenuOptions();
            }
            else
            {
                switch (mainMenuOptionChoice)
                {
                    case 1:
                        _employeeManagementMenu.EmployeeManagmentMenuOptions();
                        goto _displayMainMenuOptions;

                    
                    case 2:
                        _roleManagmentMenu.RoleManagmentMenuOptions();
                        goto _displayMainMenuOptions;

                       
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(Constant.invalidChoice);
                        break;

                }
            }
        }
    }
}
