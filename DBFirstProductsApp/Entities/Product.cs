namespace DBFirstProductsApp.Entities;

public partial class Product // POCO
{
    //[Key]
    public int ProductId { get; set; }
    //[MaxLength(50)] // Data Annotations
    public string ProductName { get; set; } = null!;

    public int Cost { get; set; }

    public string? Brand { get; set; }

    public int? CatagoryId { get; set; }

    public virtual Catagory? Catagory { get; set; }
}
