using Microsoft.Extensions.DependencyInjection;
using Api_Dapper_Test; // Replace with the actual namespace of your service and repository

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Retrieve the connection string from appsettings.json
string connectionString = configuration.GetConnectionString("DefaultConnection");

// Configure the services for dependency injection.
builder.Services.AddScoped<IPlayerService, PlayerService>(); // Replace with your service implementation
builder.Services.AddScoped<IPlayerRepository>(provider => new PlayerRepository(connectionString)); // Replace with your repository implementation

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
