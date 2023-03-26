namespace Library.API.Models;

public record AuthenticationResponse(
    string Name,
    string Email,
    string Token
);
