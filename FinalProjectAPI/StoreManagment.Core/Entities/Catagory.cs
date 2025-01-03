namespace StoreManagment.Core.Entities;

public class Catagory: BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
