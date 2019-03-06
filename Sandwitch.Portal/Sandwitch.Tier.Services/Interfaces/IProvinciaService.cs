using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Removes;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IProvinciaService
    {
        Task<ICollection<Provincia>> FindAllProvincia();

        Task<Provincia> FindProvinciaById(int id);

        Task RemoveProvinciaById(RemoveProvincia viewModel);

        Task<Provincia> UpdateProvincia(UpdateProvincia viewModel);

        Task<Provincia> AddProvincia(AddProvincia viewModel);

        Task<Provincia> CheckName(AddProvincia viewModel);
    }
}
