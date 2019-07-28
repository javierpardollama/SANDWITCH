using System.Threading.Tasks;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IHistoricoService : IBaseService
    {
        Task<Arenal> FindArenalById(int id);

        Task<Bandera> FindBanderaById(int id);

        Task<ViewHistorico> AddHistorico(AddHistorico viewModel);
    }
}
