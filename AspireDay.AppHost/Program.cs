using Microsoft.Extensions.Configuration;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

// Azure Resources
var serviceBus = builder.AddAzureServiceBus("aspiredaybus")
    .AddQueue("buy-order");

var cosmos = builder.AddAzureCosmosDB("aspiredaycosmos");
var cosmosdb = cosmos.AddDatabase("store");

var webApi = builder.AddProject<AspireDay_WebApi>("WebApi")
    .WithReference(serviceBus)
    .WithReference(cosmosdb);

builder.AddProject<AspireDay_WorkerService>("WorkerService")
    .WithReference(serviceBus)
    .WithReference(cosmosdb);

builder.Build().Run();