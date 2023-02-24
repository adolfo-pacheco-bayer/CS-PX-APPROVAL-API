namespace PX.Approval.Domain.DomainObjects;

public interface ISoftDelete
{
    bool Deleted { get; set; }
}