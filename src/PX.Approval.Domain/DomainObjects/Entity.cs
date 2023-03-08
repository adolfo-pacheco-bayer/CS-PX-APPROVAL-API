namespace PX.Approval.Domain.DomainObjects;

/// <summary>
/// WARNING: IF ANY related database attribute was put here, remember to map in <see cref="EntityMapping.cs"/> file.
/// </summary>
public abstract class Entity : IDomainEvent
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public bool Deleted { get; set; }

    public string? LastModifiedBy { get; set; }

    public Guid IntegrationId { get; set; }

    public List<DomainEvent> DomainEvents { get; private set; } = new List<DomainEvent>();

    protected Entity()
    {
    }

    public override bool Equals(object obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id) && IntegrationId.Equals(compareTo.IntegrationId);
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, IntegrationId);
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}, IntegrationId={IntegrationId}]";
    }

    public void AddEvent(DomainEvent @event)
    {
        DomainEvents.Add(@event);
    }
}