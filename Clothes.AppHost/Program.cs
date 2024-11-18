using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var api= builder.AddProject<Clothes_Api>("WebApi");
builder.AddProject<Clothes_WebApp>("WebApp")
    .WithReference(api);

builder.Build().Run();
