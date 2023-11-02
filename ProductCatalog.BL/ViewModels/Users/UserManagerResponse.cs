using Microsoft.AspNetCore.Identity;

namespace ProductCatalog.BL;

public class UserManagerResponse
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public string? Role { get; set; }
    public string? UserId { get; set; }
}
