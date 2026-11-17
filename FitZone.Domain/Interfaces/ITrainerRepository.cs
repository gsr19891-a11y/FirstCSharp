
using FitZone.Domain.Models.Entities;

namespace FitZone.Domain.Interfaces
{
    public interface ITrainerRepository
    {
        void Add(Trainer trainer);

        List<Trainer> GetAll();

        Trainer? GetById(int id);
    }
}
