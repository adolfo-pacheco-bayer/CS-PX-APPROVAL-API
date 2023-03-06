using System.Runtime.Serialization;

namespace PX.Crop.Domain.Enum;

public enum PartnerType
{
    [EnumMember(Value = "DISTRIBUIDOR")]
    Distributor = 1,
    [EnumMember(Value = "ATACADISTA")]
    Dealer = 2,
    [EnumMember(Value = "COOPERATIVA")]
    Cooperative = 3
}