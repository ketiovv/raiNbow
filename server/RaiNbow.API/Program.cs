using RaiNbow;
using RaiNbow.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRaiNbowServices();

builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwaggerDocs();

app.UseHttpsRedirection();

app.UseRouting();

app.UseRaiNbow();

app.UseFrontend();

app.Run();