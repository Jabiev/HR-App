namespace HRproject.Core.IEntities;

public interface IEntity<Type>
{
    public Type Id { get; set; }
}
