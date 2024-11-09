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
using OnlineShop.Domain.Entities;
using Microsoft.AspNetCore.Identity; // Adjust based on where your repository implementations are located
using Microsoft.EntityFrameworkCore;
using OnlineShop.API.Hubs;
using OnlineShop.Application.Message.Hub;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddDbContext<OnlineShopDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

// Add MediatR to the container for handling CQRS requests
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // Correct usage

// Register repositories to DI container (adjust these classes based on actual implementation)
builder.Services.AddScoped<IProductVariantRepository, ProductVariantRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageHub, ChatHub>();
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
builder.Services.AddSignalR();
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("api/identity").WithTags("Identity").MapIdentityApi<User>();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chathub");
app.Run();
