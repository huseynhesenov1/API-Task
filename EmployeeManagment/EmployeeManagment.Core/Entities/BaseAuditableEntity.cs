namespace EmployeeManagment.Core.Entities;

public class BaseAuditableEntity:BaseEntity
{
    public DateTime CreateAt { get; set; }
    public DateTime? CreateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? UpdateBy { get; set; }
    public DateTime? DeleteAt { get; set; }
    public DateTime? DeleteBy { get; set; }
}
