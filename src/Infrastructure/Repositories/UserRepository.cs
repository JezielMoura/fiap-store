using FiapStore.Domain.UserAggegate;

namespace FiapStore.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IList<User> _users = new List<User>();

    public async Task Add(User user)
    {
        await Task.Run(() => _users.Add(user));
    }

    public async Task<IEnumerable<User>> Get()
    {
        return await Task.FromResult(_users);
    }
}