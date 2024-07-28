using HRproject.Core.Entities;

namespace HRproject.Business.Interfaces;

public interface IEmployeeService
{
    void CreateEmployee(Employee employee);
    void DeleteEmployee(Employee employee);
    void UpdateEmployee(Employee existEmployee, Employee updatingemployee);
    List<Employee> ShowAll();
    List<Employee> ShowbyDepartment(Department department);
    List<Employee> ShowbyPosition(Position position);
}
