var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");
var messaging = builder.AddRabbitMQ("messaging");
var mysql = builder.AddMySql("mysql");

var chargedb = mysql.AddDatabase("charge");
var dashboardsdb = mysql.AddDatabase("dashboards");
var journeydb = mysql.AddDatabase("journey");
var streamdb = mysql.AddDatabase("stream");
var userdb = mysql.AddDatabase("user");
var vehicledb = mysql.AddDatabase("vehicle");

// Service consumption
builder.AddProject<Projects.Tealse_Charge>("charge")
       .WithReference(redis)
       .WithReference(messaging)
       .WithReference(chargedb);

builder.AddProject<Projects.Tealse_Dashboards>("dashboards")
       .WithReference(redis)
       .WithReference(messaging)
       .WithReference(dashboardsdb);

builder.AddProject<Projects.Tealse_Journey>("journey")
       .WithReference(redis)
       .WithReference(messaging)
       .WithReference(journeydb);

builder.AddProject<Projects.Tealse_Stream>("stream")
       .WithReference(redis)
       .WithReference(messaging)
       .WithReference(streamdb);

builder.AddProject<Projects.Tealse_User>("user")
       .WithReference(redis)
       .WithReference(messaging)
       .WithReference(userdb);

builder.AddProject<Projects.Tealse_Vehicle>("vehicle")
       .WithReference(redis)
       .WithReference(messaging)
       .WithReference(vehicledb);

builder.Build().Run();
