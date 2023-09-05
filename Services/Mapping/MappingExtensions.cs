using Microsoft.Extensions.DependencyInjection;

namespace AspNetCodeReact.Services.Mapping
{
    public static class MappingExtensions
    {
        /// <summary>
        /// Добавляет поддержку автомаппера
        /// </summary>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(MappingProfile));
    }
}
