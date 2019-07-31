using System.Collections.Generic;
using System.Threading.Tasks;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IPoblacionService : IBaseService
    {
        Task<ICollection<ViewPoblacion>> FindAllPoblacion();

        Task<ICollection<ViewPoblacion>> FindAllPoblacionByProvinciaId(int id);

        Task<Poblacion> FindPoblacionById(int id);

        Task<Provincia> FindProvinciaById(int id);

        Task RemovePoblacionById(int id);

        Task<ViewPoblacion> UpdatePoblacion(UpdatePoblacion viewModel);

        Task<ViewPoblacion> AddPoblacion(AddPoblacion viewModel);

        Task<Poblacion> CheckName(AddPoblacion viewModel);

        Task<Poblacion> CheckName(UpdatePoblacion viewModel);
    }
}
