using SOA.Common.Models;

namespace SOA.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateAsync(string firstNamae, string lastName);

    Task DeleteAsync(int userId);

    Task<PagedResult<UserDto>> GetUsersAsync(int skip, int take);

    Task<IEnumerable<UserEntityDto>> GetAllUsersAsync();
}
