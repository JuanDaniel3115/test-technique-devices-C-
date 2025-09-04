using Database;
using Interfaz;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services he Interface
builder.Services.AddScoped<ICreateDevice, CreateDevice>();
builder.Services.AddScoped<IConsultDevice, ConsultDevice>();

//DB Creacion memoria
builder.Services.AddDbContext<Database2>(options =>
    options.UseInMemoryDatabase("DeviceDB"));

//builder.Services.Configure<RouteOptions>(options =>
//{
//    options.LowercaseUrls = true;
//    options.ConstraintMap["catchall"] = typeof(CatchAllRouteConstraint);
//});


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
