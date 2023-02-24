namespace PX.Approval.Domain.DomainObjects;

public interface IDomainValidationHandler
{ };

public interface IDomainValidationHandler<TRequest> : IDomainValidationHandler
{
    Task<DomainValidationResult> Validate(TRequest request);
}