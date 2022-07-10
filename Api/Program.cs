using System.Net;
using Api;
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
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        var errorStatusCode = (int)HttpStatusCode.InternalServerError;

        context.Response.StatusCode = errorStatusCode;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            await context.Response.WriteAsync(
                new ErrorDetails("Internal Server Error.", errorStatusCode).ToString());
        }
    });
});
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();