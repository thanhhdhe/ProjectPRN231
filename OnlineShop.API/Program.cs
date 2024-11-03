using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Extensions;
using OnlineShop.Infrastructure.Persistence;
using OnlineShop.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configure logging for better diagnostics
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

// Configure Authentication and JWT Bearer settings
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:JwtSecurityKey"]))
    };
});

// Configure Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<OnlineShopDbContext>()
    .AddDefaultTokenProviders();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Shop API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Register additional services
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<OnlineShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase")));

// Register Repositories and Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IShippingRepository, ShippingRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IShippingService, ShippingService>();

var app = builder.Build();

// Seed roles and admin user
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

    if (roleManager == null || userManager == null)
    {
        throw new Exception("RoleManager or UserManager service not available. Check Identity configuration.");
    }

    try
    {
        var log = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        string[] roleNames = { "Admin", "Staff" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        string adminEmail = "admin@gmail.com";
        string adminPassword = "Admin@123";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new User
            {
                Email = adminEmail,
                FirstName = "Default",
                LastName = "Admin",
                Phone = "123456789",
                Address = "Admin Address",
                Active = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                // Log lỗi nếu việc tạo người dùng không thành công
                foreach (var error in result.Errors)
                {
                    log.LogError($"Error creating user: {error.Description}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        // Log any errors during role/user seeding
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding roles and admin user.");
        throw; // Re-throw to allow further investigation if necessary
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add middleware in the correct order
app.UseHttpsRedirection();
app.UseAuthentication(); // Important: Place UseAuthentication before UseAuthorization
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
