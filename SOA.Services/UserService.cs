using AutoMapper;
using SOA.Common.Models;
using SOA.Data.Entities;
using SOA.Repositories;
using SOA.Services.Interfaces;

namespace SOA.Services;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateAsync(string firstNamae, string lastName)
    {
        var existing_user = _userRepository.AsNoTracking().Where(x => x.FirstName == firstNamae && x.LastName == lastName).FirstOrDefault();    

        if (existing_user != null)
        {
            throw new ApplicationException("User Already Exists");
        }

        var user = new UserEntity()
        {
            FirstName = firstNamae,
            LastName = lastName
        };

        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }

    public async Task DeleteAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            return;
        }

        await _userRepository.DeleteAsync(user);
    }

    public async Task<IEnumerable<UserEntityDto>> GetAllUsersAsync()
    {
        var allUsers = await _userRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<UserEntityDto>>(allUsers);
    }

    public async Task<PagedResult<UserDto>> GetUsersAsync(int skip, int take)
    {
        var users = await _userRepository.GetPagedAsync(skip, take);

        if (users == null)
        {
            return new PagedResult<UserDto>();
        }

        var result = new PagedResult<UserDto>()
        {
            Items = _mapper.Map<List<UserDto>>(users.Items),
            TotalCount = users.TotalCount
        };

        return result;
    }
}
