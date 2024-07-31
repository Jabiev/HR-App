using HRproject.Business.Exceptions;
using HRproject.Business.Interfaces;
using HRproject.Core.Entities;
using System.Xml.Linq;

namespace HRproject.Business.Implementations;

public class DepartmentService : IDepartmentService
{
    internal static List<Department>? _departments;

    public DepartmentService()
    {
        _departments = new List<Department>();
    }

    public void Create(Department department)
    {
        if (string.IsNullOrEmpty(department.Name))
            throw new ValueNullorEmptyException("Invalid value");
        var checkname = _departments?.Find(d => d.Name == department.Name);
        if (checkname is not null)
            throw new ValueMessException("Already Exists the Value");
        _departments?.Add(department);
    }

    public void Delete(int id, EmployeeService service)
    {
        var department = _departments?.Find(d => d.Id == id);
        if (department is null)
            throw new NotFoundException("Not Found Value");
        var checkany = service.ShowbyDepartment(department);
        foreach (var item in checkany)
            if (item.DepartmentId == department.Id)
                throw new NotRemovedbyContainSomeItemsException("Not removed because of the values contains some values");
        _departments?.Remove(department);
    }

    public Department GetById(int id)
    {
        var department = _departments?.Find(d => d.Id == id);
        if (department is null)
            throw new NotFoundException("Not Found that with the Value");
        return department;
    }

    public List<Department> Info() =>
        _departments ?? new List<Department>();

    public void Update(int id, string? name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValueNullorEmptyException("Invalid value");
        var department = _departments?.Find(d => d.Id == id);
        if (department is null)
            throw new NotFoundException("Not Found Value");
        var checkname = _departments?.Find(d => d.Name == name);
        if (checkname is not null)
            throw new ValueMessException("Already Exists the Value");
        department.Name = name;
    }
}
