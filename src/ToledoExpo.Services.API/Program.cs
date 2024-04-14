using ToledoExpo.Services.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseWebApplication(builder.Configuration);

app.Run();