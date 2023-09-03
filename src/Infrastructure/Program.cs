using FiapStore.Application.Users.AddUser;
using FiapStore.Domain.UserAggegate;
using FiapStore.Infrastructure.Behaviors;
using FiapStore.Infrastructure.Endpoints;
using FiapStore.Infrastructure.Extensions;
using FiapStore.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<AddUserCommand>();
builder.Services.AddMediatR(options => {
    options.RegisterServicesFromAssemblyContaining<AddUserCommand>();
    options.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

app.ConfigureExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.RoutePrefix = "";
        options.SwaggerEndpoint("swagger/v1/swagger.json", "FiapStore.Infrastructure v1");
    });
}

app.MapGroup("/api/user").WithTags("User").MapUserEndpoints();

app.Run();
