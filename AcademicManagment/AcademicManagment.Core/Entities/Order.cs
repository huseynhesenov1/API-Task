namespace AcademicManagment.Core.Entities;

public class Order:BaseAuditable
{
    public DateTime OrderDate { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }  
    public decimal TotalPrice { get; set; }
}
