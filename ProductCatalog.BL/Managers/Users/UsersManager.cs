using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductCatalog.DAL;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ProductCatalog.BL;

public class UsersManager : IUsersManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _manager;
    private readonly SignInManager<User> _signInManager;

    public UsersManager(IUnitOfWork unitOfWork,
                            UserManager<User> manager,
                            SignInManager<User> signInManager)
    {
        _unitOfWork = unitOfWork;
        _manager = manager;
        _signInManager = signInManager;
    }

    public async Task<UserManagerResponse> Login(UserLoginVM loginCredientials)
    {
            User? user = await _manager.FindByEmailAsync(loginCredientials.Email);
            if (user is null)
            {
                return new UserManagerResponse
                {
                    Message = "User Not Found",
                    IsSuccess = false,

                };
            }

            bool isValiduser = await _manager.CheckPasswordAsync(user, loginCredientials.Password);
            if (!isValiduser)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid Password!",
                    IsSuccess = false,
                };
            }


            var claims = await _manager.GetClaimsAsync(user);

            _signInManager.SignInWithClaimsAsync(user, true, claims).Wait();

            return new UserManagerResponse
            {
                IsSuccess = true,
                Role = user.Role.ToString(),
                UserId = user.Id,
            };
    }

    public async Task<UserManagerResponse> Register(UserRegisterVM registerCredientials)
    {
        try
        {
            User user = new()
            {
                FName = registerCredientials.FName,
                LName = registerCredientials.LName,
                Email = registerCredientials.Email,
                UserName = registerCredientials.Email,
                Age = registerCredientials.Age,
                Role = UserRole.Customer,
            };

            User? checkUser = await _manager.FindByEmailAsync(registerCredientials.Email);
            if (checkUser is not null)
            {
                return new UserManagerResponse
                {
                    Message = "Email already in use",
                    IsSuccess = false,

                };
            }

            var result = await _manager.CreateAsync(user, registerCredientials.Password);

            if (!result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Try another password",
                    IsSuccess = false,
                };
            }

            List<Claim> claims = new()
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id),
                 new Claim(ClaimTypes.Role, user.Role.ToString()),
             };
            var claimsResult = await _manager.AddClaimsAsync(user, claims);

            if (!claimsResult.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                };
            }

            return new UserManagerResponse
            {
                Message = "Register Successfully",
                IsSuccess = true,
                Role = user.Role.ToString(),
            };
        }
        catch
        {
            return new UserManagerResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
            };
        }
    }

    public void Logout()
    {
        _signInManager.SignOutAsync().Wait();
    }

}
