using System.Collections.Generic;
using System.Threading.Tasks;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IArenalService : IBaseService
    {
        Task<ICollection<ViewArenal>> FindAllArenal();

        Task<ICollection<ViewArenal>> FindAllArenalByPoblacionId(int id);

        Task<Arenal> FindArenalById(int id);

        Task<Poblacion> FindPoblacionById(int id);

        Task RemoveArenalById(int id);

        Task<ViewArenal> UpdateArenal(UpdateArenal viewModel);

        Task<ViewArenal> AddArenal(AddArenal viewModel);

        Task AddArenalPoblacion(AddArenal viewModel, Arenal entity);

        Task UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity);

        Task<Arenal> CheckName(AddArenal viewModel);
    }
}
