using HRproject.Core.IEntities;

namespace HRproject.Core.Entities;

public class Position : IEntity<int>
{
    public int Id { get; set; }
    static int _id;
    public string? Name { get; set; } = null!;

    public Position(string? name)
    {
        Id = _id++;
        Name = name;
    }
    public override string ToString()
    {
        return $"Id: {Id} | {Name}";
    }
}
