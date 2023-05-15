using Microsoft.EntityFrameworkCore;
using Prueba_TredaSolution.Data;
using Microsoft.Extensions.DependencyInjection;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PTSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PTSContext") ?? throw new InvalidOperationException("Connection string 'PTSContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cadena de conneccion 
builder.Services.AddDbContext<AplicationDbContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Enable CORS
builder.Services.AddCors(options =>
options.AddPolicy(name: myAllowSpecificOrigins,
builder =>
{
    builder.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
