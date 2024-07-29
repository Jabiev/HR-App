using HRproject.Business.Exceptions;
using HRproject.Core.Entities;

namespace HRproject.Business.Interfaces;

public interface IEmployeeService
{
    void CreateEmployee(Employee employee);
    void DeleteEmployee(Guid id);
    void UpdateEmployee(Employee existEmployee, Employee updatingemployee);
    public Employee GetById(Guid id);
    List<Employee> ShowAll();
    List<Employee> ShowbyDepartment(Department department);
    List<Employee> ShowbyPosition(Position position);
}
