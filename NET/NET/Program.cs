using NET.Repository;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args); //

// Add services to the container.

builder.Services.AddControllers(); //
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //
builder.Services.AddSwaggerGen(); //

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<ICabinetRepository, CabinetRepository>(sp => new CabinetRepository(connectionString));
builder.Services.AddScoped<IUserRepository, UserRepository>(sp => new UserRepository(connectionString));

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //
{ //
    app.UseSwagger(); //
    app.UseSwaggerUI(); //
} //

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

//app.UseAuthorization(); //

app.MapControllers(); //

app.Run(); //
