using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IHistoricoService
    {       
        Task<ICollection<Historico>> FindAllHistoricoByArenalId(int id);

        Task<Arenal> FindArenalById(int id);

        Task<Bandera> FindBanderaById(int id);

        Task<Historico> FindHistoricoById(int id);

        Task<Historico> UpdateHistorico(UpdateHistorico viewModel);
    }
}
