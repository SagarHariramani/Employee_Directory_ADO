using EmployeeDirectory.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmployeeDirectory.Services.Contract;
using EmployeeDirectory.Services;
using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Data;
using EmployeeDirectory.Controller.Contract;
using EmployeeDirectory.Controller;
using EmployeeDirectory.UI.Contract;
using EmployeeDirectory.UI.Menus;
using EmployeeDirectory.Services.Common;

namespace MainMenu
{

    public class EmployeeDirectory
    {
        public static void Main(string[] args)
        {
            //makes configured services available throughout an app.
            var services = new ServiceCollection();
            //Definition of an interface for objects that can create a configuration.creating the configuration that's used at run time from the configuration files you provide.
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //Getting the connection string from the JSON
            string connectionString = configBuilder.GetSection("ConnectionStrings")["MyDBConnectionString"]!;
            if (connectionString != null)
            { 
                //service is created when requested 
                services.AddScoped<IDbConnection,DbConnection>(db => new DbConnection(connectionString));
            }
            else
            {
                throw new Exception("Error");
            }
            //service is created when requested. Registering the dependencies here in the service block
            services.AddScoped<IEmployeeHandler, EmployeeHandler>();
            services.AddScoped<IRoleHandler, RoleHandler>();
            services.AddScoped<IManagerHandler, ManagerHandler>();
            services.AddScoped<IProjectHandler, ProjectHandler>();
            services.AddScoped<IDepartmentHandler, DepartmentHandler>();
            services.AddScoped<ILocationHandler, LocationHandler>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IManagerService,ManagerService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IDepartmentService,DepartmentService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IEmployeeController, EmployeeController>();
            services.AddScoped<IRoleController, RoleController>();
            services.AddScoped<IEmployeeManagementMenu,EmployeeManagementMenu>();
            services.AddScoped<IRoleManagmentMenu, RoleManagmentMenu>();
            services.AddScoped<IMainMenu,MainMenuOptions>();

            // Build the service provider and store it in a variable when the developer wants to resolve a service when registering another service.
            var serviceProvider = services.BuildServiceProvider();
            //GetRequiredService triggers an exception in this case.
            //GetService returns null if the requested service cannot be resolved by the ServiceProvider interface.
            var mainMenu = serviceProvider.GetRequiredService<IMainMenu>();

            mainMenu.DisplayMainMenuOptions();
        }
    }
}