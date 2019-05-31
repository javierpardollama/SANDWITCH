using AutoMapper;
using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Services.Interfaces;

namespace Sandwitch.Tier.Services.Classes
{
    public class BaseService : IBaseService
    {
        protected readonly IApplicationContext Icontext;

        protected readonly IMapper Imapper;

        protected readonly ILogger ILogger;

        public BaseService(
            IApplicationContext iContext,
            IMapper iMapper,
            ILogger iLogger)
        {
            Icontext = iContext;
            Imapper = iMapper;
            ILogger = iLogger;
        }
    }
}
