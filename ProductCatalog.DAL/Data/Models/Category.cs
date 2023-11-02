namespace ProductCatalog.DAL;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    public IEnumerable<Product> products { get; set; } = new HashSet<Product>();
}
