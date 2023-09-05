using AspNetCodeReact.Services.DTO;

namespace AspNetCodeReact.Services.Interfaces
{
    /// <summary>
    /// Операции над моделями машин (фасад к хранилищу)
    /// </summary>
    public interface ICarsService
    {
        /// <summary>
        /// Создать запись
        /// </summary>
        /// <returns>Созданная запись (из хранилища)</returns>
        Task<Car> CreateCar(UpdateCarRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить запись
        /// </summary>
        /// <returns>True если реально удалено, False если запись не найдена в хранилище</returns>
        Task<bool> DeleteCar(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список типов кузовов
        /// </summary>
        Task<IEnumerable<NamedId>> GetBodyTypes(CancellationToken cancellationToken);

        /// <summary>
        /// Получить список брендов
        /// </summary>
        Task<IEnumerable<NamedId>> GetBrands(CancellationToken cancellationToken);

        /// <summary>
        /// Получить список моделей машин
        /// </summary>
        Task<IEnumerable<Car>> GetCars(CancellationToken cancellationToken);

        /// <summary>
        /// Обновить данные модели машины
        /// </summary>
        /// <returns>Обновлённая запись (из хранилища) или null если существующие данные не найдены</returns>
        Task<Car?> UpdateCar(UpdateCarRequest request, CancellationToken cancellationToken);
    }
}