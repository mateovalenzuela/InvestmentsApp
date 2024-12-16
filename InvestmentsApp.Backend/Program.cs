using AutoMapper;
using InvestmentsApp.Backend.Models;
using InvestmentsApp.Backend.Repositories;
using InvestmentsApp.Backend.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Entity Framework 
builder.Services.AddDbContext<InvestmentsAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"))
);

// Mappers
builder.Services.AddAutoMapper(typeof(MapperProfile));

// Services
builder.Services.AddScoped<ITypeInvestmentService, TypeInvestmentService>();
builder.Services.AddScoped<IInvestmentService,  InvestmentService>();


// Repositories
builder.Services.AddScoped<ITypeInvestmentRepository, TypeInvestmentRepository>();
builder.Services.AddScoped<IInvestmentRepository, InvestmentRepository>();

var myPolicy = "MyCorsPolicy";

// Agregar servicios CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(myPolicy, policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyHeader() 
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Crear Db
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<InvestmentsAppContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Estableciendo mi politica de acceso
app.UseCors(myPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
