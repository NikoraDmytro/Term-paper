using System.Net;
using Api;
using Api.Helpers;
using BLL.Services;
using BLLAbstractions;
using DAL;
using DALAbstractions;
using Microsoft.AspNetCore.Diagnostics;
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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddAutoMapper(typeof(Program));

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