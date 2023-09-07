using Contpaqi.Data.Mappings;
using Contpaqi.Data.UnitOfWork;
using System.Text.Json.Serialization;
using System.Text.Json;
using Contpaqi.Application.Services;
using Contpaqi.Application.Services.Impl;
using Contpaqi.Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


//// Add services to the container.
//builder.Services.AddControllers()
//        //data annotations validation disabled
//        .ConfigureApiBehaviorOptions(o =>
//            o.SuppressModelStateInvalidFilter = true)
//        .AddJsonOptions(o =>
//        {
//            o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//            o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//            o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//        });

//#region services

////app setings
////builder.Services.AddOptions<AppSettings>()
////                   .Bind(builder.Configuration.GetSection(AppSettings.Config))
////                   .ValidateDataAnnotations();

////services 
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();

////repositories
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//#endregion services

////add automapper
//builder.Services.AddAutoMapper(typeof(MappingProfiles));

//// connect to postgres with connection string from app settings
//builder.Services.AddDbContext<ContpaqiDbContext>(opt => opt
//    .UseSqlServer(builder.Configuration.GetConnectionString("Contpaqi"),
//    o => o.MigrationsAssembly("Contpaqi.Web")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
