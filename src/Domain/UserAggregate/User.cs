using FiapStore.Domain.Shared;

namespace FiapStore.Domain.UserAggegate;

public class User : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; } = null!;

    public User(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public void SetPasswordHash(string hash)
    {
        PasswordHash = hash;
    }

    // EF Consctructor
    private User() 
    {
        (Name, Email, PasswordHash) = (string.Empty, string.Empty, string.Empty);
    }
}