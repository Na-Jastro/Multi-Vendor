using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MultiVendor.Core.Repositories;
using MultiVendor.Infrastructure.Repository;
using MultiVendor.Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ISystemInfoRepositories, SystemInfoRepository>();
builder.Services.AddDbContext<MultiVendorDbContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("MultiVendorAppCon")));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Multi Vendor",
            Version = "v1"
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
