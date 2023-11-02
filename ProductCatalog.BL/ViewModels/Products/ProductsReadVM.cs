namespace ProductCatalog.BL;

public class ProductsReadVM
{
    public int ProductId { get; set; }
    public string productName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
}
