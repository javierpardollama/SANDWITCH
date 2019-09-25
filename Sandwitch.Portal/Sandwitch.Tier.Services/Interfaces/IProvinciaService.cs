using System.Collections.Generic;
using System.Threading.Tasks;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IProvinciaService : IBaseService
    {
        Task<IList<ViewProvincia>> FindAllProvincia();

        Task<Provincia> FindProvinciaById(int id);

        Task RemoveProvinciaById(int id);

        Task<ViewProvincia> UpdateProvincia(UpdateProvincia viewModel);

        Task<ViewProvincia> AddProvincia(AddProvincia viewModel);

        Task<Provincia> CheckName(AddProvincia viewModel);

        Task<Provincia> CheckName(UpdateProvincia viewModel);
    }
}
