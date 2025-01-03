namespace StoreManagment.Core.Entities;

public abstract class BaseEntity:BaseAuditableEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
} 
