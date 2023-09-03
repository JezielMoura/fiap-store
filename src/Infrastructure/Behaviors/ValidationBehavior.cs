using FiapStore.Domain.Shared;

namespace FiapStore.Infrastructure.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
        _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken token)
    {
        var results = _validators.Select(v => v.Validate(request));
        var failures = results.SelectMany(r => r.Errors.Where(e => e != null));

        if (failures.Any())
            throw new Domain.Shared.ValidationException(failures.Select(f => new Error(f.ErrorCode, f.ErrorMessage)));

        return await next();
    }
}