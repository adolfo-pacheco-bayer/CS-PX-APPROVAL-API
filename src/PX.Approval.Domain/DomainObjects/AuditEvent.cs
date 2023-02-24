namespace PX.Approval.Domain.DomainObjects
{
    public class AuditEvent
    {
        public AuditEvent(AuditEventType auditEventType, object? entity, Type objectType)
        {
            DateOccurred = DateTimeOffset.UtcNow;
            AuditEventType = auditEventType;
            Entity = entity;
            ObjectTypeName = objectType.Name;
        }

        public AuditEventType AuditEventType { get; private set; }
        public bool IsPublished { get; set; }
        public object? Entity { get; set; }
        public string ObjectTypeName { get; set; }
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    }

    public enum AuditEventType
    {
        Create = 1,
        Update = 2,
        Delete = 3
    }


}