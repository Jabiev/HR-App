using HRproject.Core.Entities;

namespace HRproject.Business.Interfaces;

public interface IDepartmentService
{
    void Create(string? name);
    void Delete(int id);
    void Update(int id, string? name);
    List<Department> Info();
    Department GetById(int id);
}
