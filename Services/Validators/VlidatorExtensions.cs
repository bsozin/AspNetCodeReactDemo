using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCodeReact.Services.Validators
{
    public static class VlidatorExtensions
    {
        /// <summary>
        /// Добавляет поддержку автоматической валидации в контроллеры ASP
        /// </summary>
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
            => services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining(typeof(VlidatorExtensions));
    }
}
