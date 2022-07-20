using Api.ActionFilters;
using DAL;
using AutoMapper;
using Api.Helpers;
using BLL.Profiles;
using BLL.Services;
using BLLAbstractions;
using DALAbstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

string connectionString = builder.Configuration.GetConnectionString("PCConnection");

builder.Services.AddDbContext<HospitalContext>(options =>
{
    options.UseMySql(connectionString, 
        new MySqlServerVersion(
            new Version(8, 0, 29)));
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<DoctorProfile>();
    mc.AddProfile<HospitalUnitProfile>();
    mc.AddProfile<MedicineProfile>();
    mc.AddProfile<IllnessProfile>();
    mc.AddProfile<PatientProfile>();
    mc.AddProfile<HospitalWardProfile>();
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IIllnessService, IllnessService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IHospitalWardService, HospitalWardService>();
builder.Services.AddScoped<IHospitalUnitService, HospitalUnitService>();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();