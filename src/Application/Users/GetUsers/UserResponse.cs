using FiapStore.Domain.UserAggegate;

namespace FiapStore.Application.GetUsers;

public record UserResponse(Guid Id, string Name, string Email)
{
    public static UserResponse CreateFromUser(User user) =>
        new (user.Id, user.Name, user.Email);
}