using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IBanderaService : IBaseService
    {
        Task<ICollection<ViewBandera>> FindAllBandera();

        Task<Bandera> FindBanderaById(int id);

        Task RemoveBanderaById(int id);

        Task<ViewBandera> UpdateBandera(UpdateBandera viewModel);

        Task<ViewBandera> AddBandera(AddBandera viewModel);

        Task<Bandera> CheckName(AddBandera viewModel);
    }
}
