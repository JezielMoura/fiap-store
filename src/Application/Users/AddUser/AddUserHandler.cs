using FiapStore.Domain.UserAggegate;

namespace FiapStore.Application.Users.AddUser;

public class AddUserHandler : IRequestHandler<AddUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.MapToUser();
        var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        user.SetPasswordHash(hash);
        await _userRepository.Add(user);

        return user.Id;
    }
}