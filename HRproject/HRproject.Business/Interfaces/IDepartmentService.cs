using HRproject.Business.Implementations;
using HRproject.Core.Entities;

namespace HRproject.Business.Interfaces;

public interface IDepartmentService
{
    void Create(string? name);
    void Delete(int id, EmployeeService service);
    void Update(int id, string? name);
    List<Department> Info();
    Department GetById(int id);
}
