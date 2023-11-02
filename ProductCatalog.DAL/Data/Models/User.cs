using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.DAL;

public class User : IdentityUser
{
    //public Guid Id { get; set; }
    public string FName { get; set; } = string.Empty;
    public string LName { get; set; } = string.Empty;
    //public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public UserRole Role { get; set; }

    public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
}
