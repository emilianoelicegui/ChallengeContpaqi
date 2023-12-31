using Contpaqi.Application.Services.Impl;
using Contpaqi.Application.Services;
using Contpaqi.Data.Contexts;
using Contpaqi.Data.Mappings;
using Contpaqi.Data.UnitOfWork;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//add cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("https://localhost:7183").AllowAnyMethod().AllowAnyHeader();
}));

// Add services to the container.

builder.Services.AddControllers()
        //data annotations validation disabled
        .ConfigureApiBehaviorOptions(o =>
            o.SuppressModelStateInvalidFilter = true)
        .AddJsonOptions(o =>
        {
            o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

#region services

//app setings
//builder.Services.AddOptions<AppSettings>()
//                   .Bind(builder.Configuration.GetSection(AppSettings.Config))
//                   .ValidateDataAnnotations();

//services 
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion services

//add automapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// connect to postgres with connection string from app settings
builder.Services.AddDbContext<ContpaqiDbContext>(opt => opt
    .UseSqlServer(builder.Configuration.GetConnectionString("Contpaqi"),
    o => o.MigrationsAssembly("Contpaqi.Web")));

builder.Services.AddControllers();
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
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
