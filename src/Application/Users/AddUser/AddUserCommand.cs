using FiapStore.Domain.UserAggegate;

namespace FiapStore.Application.Users.AddUser;

public record AddUserCommand(string Name, string Email, string Password) : IRequest<Guid>
{
    public User MapToUser() =>
        new(Guid.NewGuid(), Name, Email);
}