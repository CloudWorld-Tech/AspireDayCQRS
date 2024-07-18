using Microsoft.Extensions.Configuration;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

// Azure Resources
var serviceBus = builder.AddAzureServiceBus("aspiredaybus")
    .AddQueue("buy-order");

var cosmos = builder.AddAzureCosmosDB("aspiredaycosmos");
var cosmosdb = cosmos.AddDatabase("store");
var signalR = builder.AddAzureSignalR("aspiredaysignalr");
var webApi = builder.AddProject<AspireDay_WebApi>("webapi")
    .WithReference(serviceBus)
    .WithReference(cosmosdb)
    .WithReference(signalR);
var webApp = builder.AddProject<AspireDay_WebApp>("webapp")
    .WithReference(signalR)
    .WithReference(webApi);

builder.AddProject<AspireDay_WorkerService>("WorkerService")
    .WithReference(serviceBus)
    .WithReference(cosmosdb)
    .WithExternalHttpEndpoints()
    .WithReference(webApi);

builder.Build().Run();