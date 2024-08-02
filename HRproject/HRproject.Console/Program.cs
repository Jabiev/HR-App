using HRproject.Business.Implementations;
using HRproject.Core.Entities;

List<DepartmentService> departmentServices = new();
List<PositionService> positionServices = new();
List<EmployeeService> employeeServices = new();

int depcount = default;
int poscount = default;
int empcount = default;

Department department = null;
DepartmentService departmentService = new();
Position position = null;
PositionService positionService = new();
Employee employee = null;
EmployeeService employeeService = new();

bool check = true;
while (check)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Please Choose one of the following Options:\nCommands");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
    "*cdep ===== Create Department \n*cpos ===== Create Position \n*cemp ===== Create Employee" +
    "\n*udep ===== Update Department \n*upos ===== Update Position\n*uemp ===== Update Employee" +
    "\n*ddep ===== Delete Department\n*dpos ===== Delete Position\n*demp ===== Delete Employee" +
    "\n*shdep ===== Show Department by Id\n*shadep ===== ShowAll Departments\n*shemp ===== Show Employee by Department" +
    "\n*shaemp ===== ShowAll Employees\n*shposall ===== Show All Positions");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("<exit> Out of the App");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    string? option = Console.ReadLine()?.ToLower();
    switch (option)
    {
        case "cdep":
            Console.WriteLine("Please Enter The Department Name =>");
            var name = Console.ReadLine();
            if (name.ToLower() == "e")
                goto case "goon";
            department = new(name);
            departmentService.Create(department);
            departmentServices.Add(departmentService);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please choose <>cemp<> , if you want to add a employee =>");
            if (option == "cemp" || option == "udep" || option == "cdep" || option == "uemp" || option == "ddep" || option == "shdep" || option == "shadep" || option == "shaemp" || option == "shemp")
                depcount++;
            break;
        case "cpos":
            Console.WriteLine("Please Enter The Position Name =>");
            var pname = Console.ReadLine();
            if (pname.ToLower() == "e")
                goto case "goon";
            position = new(pname);
            positionService.Add(position);
            positionServices.Add(positionService);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please choose <>cemp<> , if you want to add a employee =>");
            if (option == "cemp" || option == "cpos" || option == "upos" || option == "uemp" || option == "dpos" || option == "shemp" || option == "shaemp" || option == "shposall")
                poscount++;
            break;
        case "cemp":
            if (poscount < 1)
            {
                if (depcount < 1)
                {
                    Console.WriteLine("Please preliminarily now choosing <>cdep<> because of must being Department\n" +
                    "and then choosing <>cpos<> because of must being Position for Employee");
                    goto case "cdep";
                }
                goto case "cpos";
            }
            Console.Write("Please Enter The Employee Name & Surname => ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("with clicking ENTER button gradually");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string? ename = Console.ReadLine();
            if (ename.ToLower() == "e")
                goto case "goon";
            employee = new(ename, Console.ReadLine(), position.Id, department.Id);
            employeeService.CreateEmployee(employee);
            employeeServices.Add(employeeService);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (option == "cemp" || option == "uemp" || option == "shemp" || option == "shaemp")
                empcount++;
            break;
        case "udep":
            if (depcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cdep<> because of must being Department");
                goto case "cdep";
            }
            Console.Write("Please enter the Department ID you would like to update and then new Department Name ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("with clicking ENTER button gradually");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Departments\n{string.Join("\n", departmentService.Info())}");
            int id = default;
            try
            {
                id = int.Parse(Console.ReadLine());
                if (id == -1)
                    goto case "goon";
            }
            catch (Exception)
            {
                throw new Exception("Please Enter Valid Value !!!");
            }
            if (departmentService?.GetById(id) is null)
                Console.WriteLine("Not Found the item with that id  begins from 0 1 2 3.. like that");
            departmentService.Update(id, Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case "upos":
            if (poscount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cpos<> because of must being Position");
                goto case "cpos";
            }
            Console.Write("Please enter the Position ID you would like to update and then new Position Name ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("with clicking ENTER button gradually");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Departments\n{string.Join("\n", positionService.Info())}");
            int idp = default;
            try
            {
                idp = int.Parse(Console.ReadLine());
                if (idp == -1)
                    goto case "goon";
            }
            catch (Exception)
            {
                throw new Exception("Please Enter Valid Value only number(integer) !!!");
            }
            if (positionService?.GetById(idp) is null)
                Console.WriteLine("Not Found the item with that id  begins from 0 1 2 3.. like that");
            positionService.Change(idp, Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case "uemp":
            if (empcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cemp<> because of must being Employee");
                goto case "cemp";
            }
            Console.WriteLine(string.Join("\n", employeeService.ShowAll()));
            Guid idg = default;
            Console.WriteLine("Please Enter one of the Guid(s) which showing");
            try
            {
                idg = Guid.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new Exception("Please Enter Valid Value only one of the Guid(s) which showing !!!");
            }
            var empl = employeeService?.GetById(idg);
            if (empl is null)
                Console.WriteLine("Not Found the item with that id  begins from 0 1 2 3.. like that");
            Console.Write("Hmm...Ok. Please Create the Employee you would like\n" +
                "Now Please Enter Name, Surname, Choose Position(Id), Choose Deparment(Id) only Those ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("with clicking ENTER button gradually");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var iname = Console.ReadLine();
            var surname = Console.ReadLine();
            Console.WriteLine($"Positions\t{string.Join("\n", positionService.Info())}");
            Console.WriteLine($"Departments\t{string.Join("\n", departmentService.Info())}");
            int pId = int.Parse(Console.ReadLine());
            int dId = int.Parse(Console.ReadLine());
            if (pId > position.Id || dId > department.Id)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nPlease Enter Valid Value; You can choose one of the following raws\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                goto case "goon";
            }
            Employee example = new(iname, surname, pId, dId);
            employeeService.UpdateEmployee(empl, example);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case "ddep":
            if (depcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cdep<> because of must being Department");
                goto case "cdep";
            }
            Console.WriteLine($"Departments\n{string.Join("\n", departmentService.Info())}");
            Console.WriteLine("Please Choose Deleting Department(ID)");
            int delId = int.Parse(Console.ReadLine());
            if (delId == -1)
                goto case "goon";
            departmentService.Delete(delId, employeeService);
            depcount--;
            if (depcount == 0)
                Console.WriteLine("It has no department. Please adding...");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case "dpos":
            if (poscount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cpos<> because of must being Position");
                goto case "cpos";
            }
            Console.WriteLine($"Positions\n{string.Join("\n", positionService.Info())}");
            Console.WriteLine("Please Choose Deleting Position(ID)");
            int dpId = int.Parse(Console.ReadLine());
            if (dpId == -1)
                goto case "goon";
            positionService.Delete(dpId, employeeService);
            poscount--;
            if (poscount == 0)
                Console.WriteLine("It has no position. Please adding...");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case "demp":
            if (empcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cemp<> because of must being Employee");
                goto case "cemp";
            }
            Console.WriteLine($"Employees\n{string.Join("\n", employeeService.ShowAll())}");
            Console.WriteLine("Please Choose Deleting Employee(ID)");
            employeeService.DeleteEmployee(Guid.Parse(Console.ReadLine()));
            empcount--;
            if (empcount == 0)
                Console.WriteLine("It has no employee. Please adding...");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Process successfully fulfillmenting...\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case "shdep":
            if (depcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cdep<> because of must being Department");
                goto case "cdep";
            }
            Console.WriteLine($"Department's Max ID <*{department.Id}*> Note: begins from 0..");
            Console.WriteLine("Please Choose Showing you want Department(ID)");
            Console.WriteLine(departmentService.GetById(int.Parse(Console.ReadLine())));
            break;
        case "shadep":
            if (depcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cdep<> because of must being Department");
                goto case "cdep";
            }
            Console.WriteLine($"Departments\n{string.Join("\n", departmentService.Info())}");
            break;
        case "shemp":
            if (empcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cemp<> because of must being Employee");
                goto case "cemp";
            }
            Console.WriteLine($"Departments\n{string.Join("\n", departmentService.Info())}" +
                $"\tPlease choose with Id and so we'll juxtapose");
            var depwithId = departmentService.GetById(int.Parse(Console.ReadLine()));
            Console.WriteLine(string.Join("\n", employeeService.ShowbyDepartment(depwithId)));
            break;
        case "shaemp":
            if (empcount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cemp<> because of must being Employee");
                goto case "cemp";
            }
            Console.WriteLine($"Employees\n{string.Join("\n", employeeService.ShowAll())}");
            break;
        case "shposall":
            if (poscount < 1)
            {
                Console.WriteLine("Please preliminarily now choosing <>cpos<> because of must being Position");
                goto case "cpos";
            }
            Console.WriteLine($"Positions\n{string.Join("\n", positionService.Info())}");
            break;
        case "goon":
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nGo on; with valid values\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        default:
            if (option != "exit")
            {
                Console.WriteLine("\nInvalid Command. And restarting...");
                goto case "goon";
            }
            check = false;
            break;
    }
}