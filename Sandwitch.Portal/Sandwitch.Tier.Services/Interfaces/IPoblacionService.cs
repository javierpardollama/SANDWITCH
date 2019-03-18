using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    public interface IPoblacionService
    {
        Task<ICollection<Poblacion>> FindAllPoblacion();

        Task<ICollection<Poblacion>> FindAllPoblacionByProvinciaId(int id);

        Task<Poblacion> FindPoblacionById(int id);

        Task<Provincia> FindProvinciaById(int id);

        Task RemovePoblacionById(int id);

        Task<Poblacion> UpdatePoblacion(UpdatePoblacion viewModel);

        Task<Poblacion> AddPoblacion(AddPoblacion viewModel);

        Task<Poblacion> CheckName(AddPoblacion viewModel);
    }
}
