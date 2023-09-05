using AspNetCodeReact.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AspNetCodeReact.Services
{
    /// <inheritdoc/>
    public sealed class CarsService : Interfaces.ICarsService
    {
        private readonly CarsDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarsService(CarsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<DTO.Car>> GetCars(CancellationToken cancellationToken)
        {
            var cars = await CompleteAsNoTrackingCars.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<DTO.Car>>(cars);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<DTO.NamedId>> GetBrands(CancellationToken cancellationToken)
        {
            var brands = await _dbContext.Brands.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<DTO.NamedId>>(brands);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<DTO.NamedId>> GetBodyTypes(CancellationToken cancellationToken)
        {
            var bodyTypes = await _dbContext.BodyTypes.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<DTO.NamedId>>(bodyTypes);
        }

        /// <inheritdoc/>
        public async Task<DTO.Car?> UpdateCar(DTO.UpdateCarRequest request, CancellationToken cancellationToken)
        {
            var existingCar = await _dbContext.Cars.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (existingCar is null)
                return null;

            _mapper.Map(request, existingCar);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var actualCar = await CompleteAsNoTrackingCars.SingleAsync(x => x.Id == request.Id, cancellationToken);

            return _mapper.Map<DTO.Car>(actualCar);
        }

        /// <inheritdoc/>
        public async Task<DTO.Car> CreateCar(DTO.UpdateCarRequest request, CancellationToken cancellationToken)
        {
            var newCar = _mapper.Map<Data.Models.Car>(request);
            await _dbContext.Cars.AddAsync(newCar, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var actualCar = await CompleteAsNoTrackingCars.SingleAsync(x => x.Id == newCar.Id, cancellationToken);
            return _mapper.Map<DTO.Car>(actualCar);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteCar(int id, CancellationToken cancellationToken)
        {
            var existingCar = await _dbContext.Cars.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (existingCar is null)
                return false;

            _dbContext.Cars.Remove(existingCar);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        private IQueryable<Data.Models.Car> CompleteAsNoTrackingCars
            => _dbContext.Cars.AsNoTracking().Include(x => x.Brand).Include(x => x.BodyType);
    }
}