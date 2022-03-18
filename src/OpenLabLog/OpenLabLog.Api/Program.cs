using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using OpenLabLog.Api.Extensions;
using OpenLabLog.Api.Handlers;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;
using OpenLabLog.Core.Models.Configuration;
using OpenLabLog.Ef.Models;
using OpenLabLog.Ef.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

////

builder.Services
    .AddAuthentication()
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"),
                                jwtBearerScheme: JwtBearerDefaults.AuthenticationScheme);

builder.Services.AddAuthorization(options =>
{
    var predefinedRoles = builder.Configuration.GetSection(nameof(PredifinedRoles)).Get<PredifinedRoles>();
    if (predefinedRoles != null && predefinedRoles.Admins != null && predefinedRoles.Admins.RoleAdValue != null)
        options.AddPolicy(PredifinedRoles.AdminsPolicyName, policy => policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme)
                                                                            .RequireRole(predefinedRoles.Admins.RoleAdValue)
                                                                            .RequireAuthenticatedUser()
                                                                            );
    else
        throw new ArgumentNullException(nameof(predefinedRoles));

    options.AddPolicy("JwtPolicy", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
    //define the public access policy that allows for openIdConnect to be used. (off by default)
    options.AddPolicy("OpenIdConnect", policy =>
    {
        policy.AuthenticationSchemes.Add(OpenIdConnectDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });

    //the fallback accepts the jwt bearer tokens.
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
});



builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services:
//database:
var opts = builder.Configuration.GetSection(nameof(DatabaseConfigurationOptions)).Get<DatabaseConfigurationOptions>();
builder.Services.AddDbContextFactory<LabContext>(config =>
{
    config.UseLazyLoadingProxies().UseSqlServer(opts.ConnectionString);
});

builder.Services.AddDbContext<LabContext>(config => config.UseLazyLoadingProxies().UseSqlServer(opts.ConnectionString));

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


if (app.Environment.IsDevelopment())
    app.MapControllers().WithMetadata(new AllowAnonymousAttribute());
else
    app.MapControllers();


app.MigrateDatabase<LabContext>();

app.Run();
