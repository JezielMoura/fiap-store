namespace FiapStore.Domain.Shared;

public class ValidationException : Exception
{
    public IEnumerable<Error> Errors { get; }
    
    public ValidationException(IEnumerable<Error> errors) =>
        Errors = errors;
}
