using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Sandwitch_Tier_Service>("api");

builder.Build().Run();
