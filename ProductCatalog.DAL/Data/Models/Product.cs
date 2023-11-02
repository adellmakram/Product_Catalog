namespace ProductCatalog.DAL;

public class Product
{
    public int ProductId { get; set; }
    public string productName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime StartDate { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }

    public string CreatedBy { get; set; }
    public User User { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
