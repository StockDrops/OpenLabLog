using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;
using OpenLabLog.Ef.Models;
using OpenLabLog.Ef.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services:
builder.Services.AddScoped<IRepositoryService<Experiment>, CrudService<LabContext, Experiment>>();
builder.Services.AddScoped<IRepositoryService<LogBook>, CrudService<LabContext, LogBook>>();
builder.Services.AddScoped<IRepositoryService<Log>, CrudService<LabContext, Log>>();
builder.Services.AddScoped<IRepositoryService<LogEntry>, CrudService<LabContext, LogEntry>>();
builder.Services.AddScoped<IRepositoryService<Parameter>, CrudService<LabContext, Parameter>>();
builder.Services.AddScoped<IRepositoryService<ValuedParameter>, CrudService<LabContext, ValuedParameter>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
