using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IArenalService
    {
        Task<ICollection<Arenal>> FindAllArenal();

        Task<ICollection<Arenal>> FindAllArenalByPoblacionId(int id);

        Task<Arenal> FindArenalById(int id);

        Task<Poblacion> FindPoblacionById(int id);

        Task RemoveArenalById(int id);

        Task<Arenal> UpdateArenal(UpdateArenal viewModel);

        Task<Arenal> AddArenal(AddArenal viewModel);

        Task AddArenalPoblacion(AddArenal viewModel, Arenal entity);

        Task UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity);

        Task<Arenal> CheckName(AddArenal viewModel);
    }
}
