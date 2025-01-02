namespace AcademicManagment.Core.Entities;

public abstract class BaseAuditable:BaseEntity
{
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }

}
