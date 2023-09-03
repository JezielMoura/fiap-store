using FiapStore.Domain.UserAggegate;

namespace FiapStore.Application.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserResponse>>
{
    private IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.Get();

        return users.Select(UserResponse.CreateFromUser);
    }
}