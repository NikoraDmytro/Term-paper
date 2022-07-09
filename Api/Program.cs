using DAL;
using DALAbstractions;
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

app.UseCors("CorsPolicy");
app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();