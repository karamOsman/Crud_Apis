using hireAPI.Models;

namespace hireAPI.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel registerModel);

        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);

        Task<AuthModel> RefreshTokenAsync(string Token);

        Task<bool> RevokeTokenAsync(string Token);
    }
}
