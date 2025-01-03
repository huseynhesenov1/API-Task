namespace StoreManagment.Core.Entities;

public abstract class BaseAuditableEntity
{
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
}