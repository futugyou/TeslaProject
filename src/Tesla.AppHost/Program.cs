var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

// Service consumption
builder.AddProject<Projects.Tealse_Charge>("charge")
       .WithReference(redis);
builder.AddProject<Projects.Tealse_Dashboards>("dashboards")
       .WithReference(redis);
builder.AddProject<Projects.Tealse_Journey>("journey")
       .WithReference(redis);
builder.AddProject<Projects.Tealse_Stream>("stream")
       .WithReference(redis);
builder.AddProject<Projects.Tealse_User>("user")
       .WithReference(redis);
builder.AddProject<Projects.Tealse_Vehicle>("vehicle")
       .WithReference(redis);

builder.Build().Run();
