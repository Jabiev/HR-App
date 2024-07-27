using HRproject.Core.Entities;

namespace HRproject.Business.Interfaces;

public interface IPositionService
{
    void Add(string? name);
    void Change(int id, string? name);
    void Delete(int id);
    List<Position> Info();
}