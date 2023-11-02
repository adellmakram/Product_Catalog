using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.BL;

public class ProductEditVM
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "The product Name field is required.")]
    public string productName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date must be provided.")]
    [CurrentDate(ErrorMessage = "Date cannot be in the past.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [Range(1, 365, ErrorMessage = "Age must be between 1 and 365.")]
    public int Duration { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public int CategoryId { get; set; } 

}
