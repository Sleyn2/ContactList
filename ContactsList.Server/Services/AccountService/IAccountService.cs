using ContactsList.Server.Model;

namespace ContactsList.Server.Services.AccountService
{
    public interface IAccountService
    {
        Task<UserDto> LoginAsync(LoginRequest loginRequest);
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUser(string id);
        Task<List<ApplicationUser>> AddUser(ApplicationUser user);
        Task<List<ApplicationUser>> UpdateUser(ApplicationUser request);
        Task<List<ApplicationUser>> DeleteUser(ApplicationUser user);
    }
}
