using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverrepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverrepository = driverRepository;
            _mapper = mapper;
        }
        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverrepository.GetAsync(userId);

            return await Task.FromResult(_mapper.Map<Driver, DriverDto>(driver));
        }
    }
}