namespace FiapStore.Application.GetUsers;

public record GetUsersQuery : IRequest<IEnumerable<UserResponse>>;