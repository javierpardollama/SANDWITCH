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
        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <returns>Instance of <see cref="IList{ViewProvincia}"/></returns>
        Task<IList<ViewProvincia>> FindAllProvincia();

        /// <summary>
        /// Finds Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Provincia"/></returns>
        Task<Provincia> FindProvinciaById(int id);

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        Task RemoveProvinciaById(int id);

        /// <summary>
        /// Updates Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateProvincia"/></param>
        /// <returns>Instance of <see cref="ViewProvincia"/></returns>
        Task<ViewProvincia> UpdateProvincia(UpdateProvincia viewModel);

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="ViewProvincia"/></returns>
        Task<ViewProvincia> AddProvincia(AddProvincia viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Provincia"/></returns>
        Task<Provincia> CheckName(AddProvincia viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Provincia"/></returns>
        Task<Provincia> CheckName(UpdateProvincia viewModel);
    }
}
