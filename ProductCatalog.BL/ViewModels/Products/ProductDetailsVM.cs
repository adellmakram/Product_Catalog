namespace ProductCatalog.BL;

public class ProductDetailsVM
{
    public int ProductId { get; set; }
    public string productName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime StartDate { get; set; }
    public string Duration { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}
