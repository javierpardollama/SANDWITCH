using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IHistoricoService
    {   
        Task<Arenal> FindArenalById(int id);

        Task<Bandera> FindBanderaById(int id);        

        Task<Historico> AddHistorico(AddHistorico viewModel);
    }
}
