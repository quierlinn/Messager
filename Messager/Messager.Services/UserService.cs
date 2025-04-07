using Messager.Data;
using Messager.Messager.Services.Abstractions;
using Messager.Messager.UnitOfWork.Abstractions;
using Messager.Messager.UnitOfWork.CustomExceptions;
using Messager.Models;

namespace Messager.Messager.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task RegisterUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (string.IsNullOrWhiteSpace(user.userName))
        {
            throw new InvalidUserDataException("User name cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(user.password))
        {
            throw new InvalidUserDataException("Password cannot be empty");
        }

        if (await _userRepository.UsernameExistsAsync(user.userName))
        {
            throw new UserAlreadyExistsException(user.userName);
        }
        
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CommitAsync();
    }
}