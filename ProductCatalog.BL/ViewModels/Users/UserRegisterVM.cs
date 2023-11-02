using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.BL;

public class UserRegisterVM
{
    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "First Name must contain only alphabetic characters.")]
    public string FName { get; set; } = string.Empty;
    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Last Name must contain only alphabetic characters.")]
    public string LName { get; set; } = string.Empty;
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;
    [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
    public int Age { get; set; }
    public string Password { get; set; } = string.Empty;
}
