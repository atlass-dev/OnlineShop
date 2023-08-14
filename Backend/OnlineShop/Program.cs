using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Abstractions.Database;
using OnlineShop.Infrastructure.DataAccess;
using OnlineShop.Infrastructure.DependencyInjection;
using OnlineShop.Infrastructure.Middlewares;
using OnlineShop.Infrastructure.Startup;
using OnlineShop.Infrastructure.Web;

var builder = WebApplication.CreateBuilder(args);

var databaseConnectionString = builder.Configuration.GetConnectionString("AppDatabase")
            ?? throw new ArgumentNullException("ConnectionStrings:AppDatabase", "Database connection string is not initialized");

// Add services to the container.

builder.Services.AddIdentity<User, AppIdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<AppDbContext>(
    new DbContextOptionsSetup(databaseConnectionString).Setup);
builder.Services.AddAsyncInitializer<DatabaseInitializer>();

AutoMapperModule.Register(builder.Services);
MediatRModule.Register(builder.Services);
builder.Services.AddSingleton<IJsonHelper, SystemTextJsonHelper>();

builder.Services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
