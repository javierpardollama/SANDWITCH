using AutoMapper;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Services.Interfaces;

namespace Sandwitch.Tier.Services.Classes
{
    public class BaseService : IBaseService
    {
        protected readonly IApplicationContext IContext;

        protected readonly IMapper IMapper;

        protected readonly ILogger ILogger;

        public BaseService(IApplicationContext iContext,
                           IMapper iMapper,
                           ILogger iLogger)
        {
            IContext = iContext;
            IMapper = iMapper;
            ILogger = iLogger;
        }
    }
}
