using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.API.Extensions;
using OnlineShop.API.Middlewares;
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
using OnlineShop.Infrastructure.Repositories;
using OnlineShop.Domain.Entities; // Adjust based on where your repository implementations are located

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
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
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
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
