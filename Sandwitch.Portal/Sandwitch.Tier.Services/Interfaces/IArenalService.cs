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
        Task<IList<ViewArenal>> FindAllArenal();

        Task<IList<ViewArenal>> FindAllArenalByPoblacionId(int id);

        Task<Arenal> FindArenalById(int id);

        Task<Poblacion> FindPoblacionById(int id);

        Task RemoveArenalById(int id);

        Task<ViewArenal> UpdateArenal(UpdateArenal viewModel);

        Task<ViewArenal> AddArenal(AddArenal viewModel);

        void AddArenalPoblacion(AddArenal viewModel, Arenal entity);

        void UpdateArenalPoblacion(UpdateArenal viewModel, Arenal entity);

        Task<Arenal> CheckName(AddArenal viewModel);

        Task<Arenal> CheckName(UpdateArenal viewModel);
    }
}
