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
using OnlineShop.Infrastructure.Seeder; // Adjust based on where your repository implementations are located
using Microsoft.AspNetCore.Identity; // Adjust based on where your repository implementations are located
using Microsoft.EntityFrameworkCore;
using OnlineShop.API.Hubs;
using OnlineShop.Application.Message.Hub;
using OnlineShop.API.Swagger;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddDbContext<OnlineShopDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

// Add MediatR to the container for handling CQRS requests
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Register repositories to DI container (adjust these classes based on actual implementation)
builder.Services.AddScoped<IProductVariantRepository, ProductVariantRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Replace with your actual implementation
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageHub, ChatHub>();
// Add Swagger/OpenAPI support
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "My API";
    options.Version = "v1";
    options.Description = "API Documentation";
    options.DocumentProcessors.Add(new InlineSchemaProcessor());
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ISeedData>();

await seeder.Seed();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseOpenApi();  // Tạo Swagger JSON
app.UseSwaggerUI(); // Tạo Swagger JSON

app.MapGroup("api/identity").WithTags("Identity").MapCustomIdentityApi<User>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chathub");
app.Run();
