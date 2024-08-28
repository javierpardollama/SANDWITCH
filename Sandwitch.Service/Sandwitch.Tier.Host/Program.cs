using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var service = builder.AddProject<Projects.Sandwitch_Tier_Service>("service");

builder.Build().Run();
