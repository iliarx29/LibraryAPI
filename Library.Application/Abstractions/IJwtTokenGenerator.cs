using Library.Domain.Entities;

namespace Library.Application.Abstractions;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
