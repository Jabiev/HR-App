using HRproject.Business.Exceptions;
using HRproject.Business.Interfaces;
using HRproject.Core.Entities;

namespace HRproject.Business.Implementations;

public class PositionService : IPositionService
{
    List<Position>? _positions;

    public PositionService(List<Position>? positions)
    {
        _positions = positions;
    }

    public void Add(string? name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValueNullorEmptyException("Invalid Value");
        var checkname = _positions?.Find(d => d.Name == name);
        if (checkname is not null)
            throw new ValueMessException("Already Exists the Value");
        Position position = new(name);
        _positions?.Add(position);
    }

    public void Change(int id, string? name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ValueNullorEmptyException("Invalid value");
        var position = _positions?.Find(d => d.Id == id);
        if (position is null)
            throw new NotFoundException("Not Found Value");
        var checkname = _positions?.Find(d => d.Name == name);
        if (checkname is not null)
            throw new ValueMessException("Already Exists the Value");
        if (position.Name != name)
            throw new InconsistencyException("Inconsistent circumstance");
        position.Name = name;
    }

    public void Delete(int id, EmployeeService service)
    {
        var position = _positions?.Find(d => d.Id == id);
        if (position is null)
            throw new NotFoundException("Not Found Value");
        var checkany = service.ShowbyPosition(position);
        foreach (var item in checkany)
            if (item.PositionId == position.Id)
                throw new NotRemovedbyContainSomeItemsException("Not removed because of the values contains some values");
        _positions?.Remove(position);
    }

    public List<Position> Info() =>
        _positions ?? new List<Position>();
}
