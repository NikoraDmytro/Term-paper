using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

string connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<HospitalContext>(options =>
{
    options.UseMySql(connectionString, 
        new MySqlServerVersion(
            new Version(8, 0, 29)));
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();