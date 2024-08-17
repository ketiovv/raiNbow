using RaiNbow;
using RaiNbow.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRaiNbowServices();

builder.Services.AddSwagger();

const string corsAppSettingsPolicy = "AppSettings";
builder.Services.AddCors(o =>
{
    o.AddPolicy(corsAppSettingsPolicy, p =>
        p.WithOrigins(builder.Configuration.GetValue<string>("AllowedOrigins")?.Split(";") ?? [])
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

app.UseSwaggerDocs();

app.UseCors(corsAppSettingsPolicy);

app.UseHttpsRedirection();

app.UseRouting();

app.UseRaiNbow();

app.UseFrontend();

app.Run();