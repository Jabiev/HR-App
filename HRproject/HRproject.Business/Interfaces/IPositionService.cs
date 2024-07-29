using HRproject.Business.Exceptions;
using HRproject.Business.Implementations;
using HRproject.Core.Entities;

namespace HRproject.Business.Interfaces;

public interface IPositionService
{
    void Add(Position position);
    void Change(int id, string? name);
    void Delete(int id, EmployeeService service);
    List<Position> Info();
    public Position GetById(int id);
}