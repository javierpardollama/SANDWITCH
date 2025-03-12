using AutoMapper;
using Microsoft.Extensions.Options;

using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.Settings.Classes;

namespace Sandwitch.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="BaseService"/> class. Implements <see cref="IBaseService"/>
    /// </summary>
    public class BaseService : IBaseService
    {
        /// <summary>
        /// Instance of <see cref="IApplicationContext"/>
        /// </summary>
        protected readonly IApplicationContext Context;

        /// <summary>
        /// Instance of <see cref="IMapper"/>
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        /// Instance of <see cref="IOptions{ApiSettings}"/>
        /// </summary>
        protected readonly IOptions<ApiSettings> ApiSettings;

        /// <summary>
        /// Initializes a new Instance of <see cref="BaseService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        public BaseService(IApplicationContext @context,
                           IMapper @mapper)
        {
            Context = @context;
            Mapper = @mapper;
        }

        /// <summary>
        /// Initializes a new Instance of <see cref="BaseService"/>
        /// </summary>
        /// <param name="apiSettings">Injected <see cref="IOptions{ApiSettings}"/></param>
        public BaseService(IOptions<ApiSettings> @apiSettings)
        {
            ApiSettings = @apiSettings;
        }
    }
}
