using FiapStore.Application.GetUsers;
using FiapStore.Application.Users.AddUser;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FiapStore.Infrastructure.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this RouteGroupBuilder builder)
    {
        builder.MapGet("", async (ISender sender) => 
            TypedResults.Ok(await sender.Send(new GetUsersQuery())));

        builder.MapPost("", async Task<Results<Ok<Guid>, BadRequest>> (ISender sender, AddUserCommand command) => 
            await sender.Send(command) is Guid id ? TypedResults.Ok(id) : TypedResults.BadRequest());
    }
}