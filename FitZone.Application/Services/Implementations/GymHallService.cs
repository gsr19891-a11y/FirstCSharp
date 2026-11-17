
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;

namespace FitZone.Application.Services.Implementations
{
    public class GymHallService : IGymHallService
    {
        private readonly IGymHallRepository _hallRepository;

        public GymHallService(IGymHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }

        public void CreateHall(string name, int capacity, string location)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Hall name is required.");

            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location is required.");

            var hall = new GymHall
            {
                Name = name,
                Capacity = capacity,
                Location = location
            };

            _hallRepository.AddHall(hall);
        }

        public List<GymHall> GetAllHalls()
        {
            return _hallRepository.GetAllHalls();
        }
    }
}
