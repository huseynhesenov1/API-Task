using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagment.Core.Entities;

public class Product: BaseEntity
{
   
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Catagory Catagory { get; set; }
    public int CatagoryId { get; set; } 
    public Size Size { get; set; }
    public int SizeId { get; set; } 
    public Color Color { get; set; }
    public int? ColorId { get; set; }
    public string ImgPath { get; set; }
}
