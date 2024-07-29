using HRproject.Core.IEntities;

namespace HRproject.Core.Entities;

public class Employee : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Surname { get; set; }
    public int PositionId { get; set; }
    public int DepartmentId { get; set; }

    public Employee(string? name, string? surname, int positionId, int departmentId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        PositionId = positionId;
        DepartmentId = departmentId;
    }
    public override string ToString()
    {
        return $"Id: {Id} | {Name} | {Surname} | Pos.ID: {PositionId} | D.ID: {DepartmentId}";
    }
}
