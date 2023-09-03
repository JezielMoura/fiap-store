namespace FiapStore.Domain.UserAggegate;

public interface IUserRepository
{
    public Task Add(User user);
    public Task<IEnumerable<User>> Get();
}