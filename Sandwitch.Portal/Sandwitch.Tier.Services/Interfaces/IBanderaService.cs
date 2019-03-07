using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IBanderaService
    {
        Task<ICollection<Bandera>> FindAllBandera();

        Task<Bandera> FindBanderaById(int id);

        Task RemoveBanderaById(int id);

        Task<Bandera> UpdateBandera(UpdateBandera viewModel);

        Task<Bandera> AddBandera(AddBandera viewModel);

        Task<Bandera> CheckName(AddBandera viewModel);
    }
}
