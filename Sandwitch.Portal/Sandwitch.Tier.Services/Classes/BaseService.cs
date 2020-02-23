using AutoMapper;

using Microsoft.Extensions.Logging;

using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Services.Interfaces;

namespace Sandwitch.Tier.Services.Classes
{
    public class BaseService : IBaseService
    {
        protected readonly IApplicationContext Context;

        protected readonly IMapper Mapper;

        protected readonly ILogger Logger;

        public BaseService(IApplicationContext context,
                           IMapper mapper,
                           ILogger logger)
        {
            Context = context;
            Mapper = mapper;
            Logger = logger;
        }       
    }
}
