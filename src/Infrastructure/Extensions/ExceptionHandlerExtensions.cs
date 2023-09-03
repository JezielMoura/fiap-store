using FiapStore.Domain.Shared;
using Microsoft.AspNetCore.Diagnostics;

namespace FiapStore.Infrastructure.Extensions;

public static class ExceptionHandlerExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app) =>
        app.UseExceptionHandler(handlerApp => handlerApp.Run(HandleException));

    private static async Task HandleException(HttpContext context)
    {
        var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        if (exception is Domain.Shared.ValidationException validationException)
            await context.CreateResponse(validationException.Errors);
        else if (exception is DomainException domainException)
            await context.CreateResponse(new List<Error>{ new (domainException.Code, domainException.Message) });
        // else if (exception is AuthorizationException)
        //     await context.CreateResponse(statusCode: 403);
        else if (exception is Exception ex)
            await context.CreateResponse(ex.Message, statusCode: 500);
    }

    public static async Task CreateResponse(this HttpContext httpContext, object? content = null, int statusCode = 400)
    {
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(content);
    }
}