using FluentValidation;
using Library.Application.Books.Commands.CreateBook;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

       // services.AddTransient<IValidator<CreateBookCommand>, CreateBookCommandValidator>();

        return services;
    }
}
