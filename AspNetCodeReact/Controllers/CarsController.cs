using System.Net;
using AspNetCodeReact.Services.DTO;
using AspNetCodeReact.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCodeReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;
        private readonly ILogger _logger;

        public CarsController(ICarsService carsService, ILogger<CarsController> logger)
            => (_carsService, _logger) = ( carsService, logger);

        [HttpGet("cars")]
        public Task<IEnumerable<Car>> GetCars(CancellationToken cancellationToken)
            => _carsService.GetCars(cancellationToken);

        [HttpGet("brands")]
        public Task<IEnumerable<NamedId>> GetBrands(CancellationToken cancellationToken)
            => _carsService.GetBrands(cancellationToken);

        [HttpGet("bodytypes")]
        public Task<IEnumerable<NamedId>> GetBodyTypes(CancellationToken cancellationToken)
            => _carsService.GetBodyTypes(cancellationToken);

        [HttpPost("update")]
        public Task<ActionResult<Car>> UpdateCar([FromBody] UpdateCarRequest request, CancellationToken cancellationToken)
        {
            if (request.Id.HasValue) {
                return UpdateCarImpl(request, cancellationToken);
            }
            else {
                return CreateCarImpl(request, cancellationToken);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteCar([FromQuery] int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Удаление записи с id={Id}", id);
            bool isDeleted = await _carsService.DeleteCar(id, cancellationToken);
            if (isDeleted)
                _logger.LogInformation("Запись с id={Id} успешно удалена", id);
            else
                _logger.LogWarning("Не найдена запись с id={Id} для удаления", id);
            return Ok();
        }

        private async Task<ActionResult<Car>> UpdateCarImpl(UpdateCarRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Обновление записи с id={Id}", request.Id);
            var updatedCar = await _carsService.UpdateCar(request, cancellationToken);
            if (updatedCar is not null) {
                _logger.LogInformation("Запись с id={Id} успешно обновлена", request.Id);
                return Ok(updatedCar);
            }
            else {
                _logger.LogError("Не найдена запись с id={Id} для обновления", request.Id);
                return StatusCode((int)HttpStatusCode.Gone);
            }
        }

        private async Task<ActionResult<Car>> CreateCarImpl(UpdateCarRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Создание записи");
            var createdCar = await _carsService.CreateCar(request, cancellationToken);
            _logger.LogInformation("Запись успешно создана с id={Id}", createdCar.Id);
            return CreatedAtAction(nameof(UpdateCar), createdCar);
        }
    }
}