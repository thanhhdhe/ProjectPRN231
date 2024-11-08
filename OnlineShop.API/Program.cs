using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Extensions;
using OnlineShop.Infrastructure.Extensions;
using OnlineShop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MediatR;
using System.Reflection; // <-- Make sure this is included
using OnlineShop.Application.ProductVariant.Queries; // Adjust based on where your handlers/queries are located
using OnlineShop.Domain.Repositories; // Adjust based on where your repository interfaces are located
using OnlineShop.Infrastructure.Repositories; // Adjust based on where your repository implementations are located

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication(); // Assuming this method registers application services (like MediatR)
builder.Services.AddInfrastructure(builder.Configuration); // Assuming this registers infrastructure services like EF Core, Repositories
builder.Services.AddControllers();

// Add MediatR to the container for handling CQRS requests
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // Correct usage

// Register repositories to DI container (adjust these classes based on actual implementation)
builder.Services.AddScoped<IProductVariantRepository, ProductVariantRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Replace with your actual implementation

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext (ensure your connection string is correct)
builder.Services.AddDbContext<OnlineShopDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase"))
);

builder.Services.AddAuthorization();

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
