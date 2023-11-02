namespace ProductCatalog.BL;

public interface IUsersManager
{
    Task<UserManagerResponse> Login(UserLoginVM loginCredientials);
    Task<UserManagerResponse> Register(UserRegisterVM registerCredientials);
    public void Logout();
}
