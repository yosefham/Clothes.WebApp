using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Clothes_WebApp>("WebApp");
builder.Build().Run();