using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var service = builder.AddProject<Projects.Sandwitch_Tier_Service>("service");

var client = builder.AddNpmApp("client", "./../../Sandwitch.Client");

builder.Build().Run();
