using HRproject.Business.Exceptions;
using HRproject.Business.Interfaces;
using HRproject.Core.Entities;

namespace HRproject.Business.Implementations;

public class EmployeeService : IEmployeeService
{
    List<Employee>? _employees;

    public EmployeeService()
    {
        _employees = new List<Employee>();
    }

    public void CreateEmployee(Employee employee)
    {
        if (employee == null)
            throw new ValueNullorEmptyException("Invalid Value");
        if (_employees.Any(e => e.Id == employee.Id))
            throw new ValueMessException("Already Exists Value");
        _employees?.Add(employee);
    }

    public void UpdateEmployee(Employee existingEmployee, Employee updatingEmployee)
    {
        if (existingEmployee == null || updatingEmployee is null)
            throw new ValueNullorEmptyException("Invalid Value");
        var exemployee = _employees?.Find(e => e.Id == existingEmployee.Id);
        if (exemployee == null)
            throw new NotFoundException("Not Found Value");
        if ((_employees?.Find(e => e.Id == updatingEmployee.Id)) is not null)
            throw new ValueMessException("Already Exists The Value");
        exemployee.Name = updatingEmployee.Name;
        exemployee.Surname = updatingEmployee.Surname;
        exemployee.PositionId = updatingEmployee.PositionId;
        exemployee.DepartmentId = updatingEmployee.DepartmentId;
    }

    public void DeleteEmployee(Employee employee)
    {
        if (employee == null)
            throw new ValueNullorEmptyException("Invalid Value");
        var checkemployee = _employees?.Find(e => e.Id == employee.Id);
        if (checkemployee == null)
            throw new NotFoundException("Not Found Value");
        _employees?.Remove(checkemployee);

    }

    public List<Employee> ShowAll() =>
        _employees ?? new List<Employee>();

    public List<Employee> ShowbyDepartment(Department department)
    {
        if (department == null)
            throw new ValueNullorEmptyException("Invalid Value");
        var getEmployees = _employees?.FindAll(e => e.DepartmentId == department.Id);
        return getEmployees ?? new List<Employee>();
    }
    public List<Employee> ShowbyPosition(Position position)
    {
        if (position == null)
            throw new ValueNullorEmptyException("Invalid Value");
        var getEmployees = _employees?.FindAll(e => e.PositionId == position.Id);
        return getEmployees ?? new List<Employee>();
    }
}
