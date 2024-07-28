using HRproject.Business.Implementations;

List<DepartmentService> departmentServices = new();
List<PositionService> positionServices = new();
List<EmployeeService> employeeServices = new();

bool check = true;
while (check)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Please Choose one of the following Options:\nCommands");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
    "*cdep ===== Create Department \n*cpos ===== Create Position \n*cemp ===== Create Employee" +
    "\n*udep ===== Update Department \n*upos ===== Update Position\n*uemp ===== Update Employee" +
    "\n*ddep ===== Delete Department\n*dpos ===== Delete Position\n*demp ===== Delete Employee" +
    "\n*shdep ===== Show Department by Id\n*shadep ===== ShowAll Departments\n*shemp ===== Show Employee by Department" +
    "\n*shaemp ===== ShowAll Employees\n*shposall ===== Show All Positions\n");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("<exit> Out of the App");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    string? switch_on = Console.ReadLine()?.ToLower();
    switch (switch_on)
    {
        case "cdep":
            Console.WriteLine("A");
            break;
        default:
            check = false;
            break;
    }
}