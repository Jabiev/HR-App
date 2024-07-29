using HRproject.Business.Exceptions;
using HRproject.Business.Interfaces;
using HRproject.Core.Entities;

namespace HRproject.Business.Implementations;

public class PositionService : IPositionService
{
    List<Position>? _positions;

    public PositionService()
    {
        _positions = new List<Position>();
    }

    public void Add(Position position)
    {
        if (string.IsNullOrEmpty(position.Name))
            throw new ValueNullorEmptyException("Invalid Value");
        var checkname = _positions?.Find(d => d.Name == position.Name);
        if (checkname is not null)
            throw new ValueMessException("Already Exists the Value");
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

    public Position GetById(int id)
    {
        var position = _positions?.Find(d => d.Id == id);
        if (position is null)
            throw new NotFoundException("Not Found that with the Value");
        return position;
    }

    public List<Position> Info() =>
        _positions ?? new List<Position>();
}
