using Microsoft.EntityFrameworkCore;
using MyLetterBoxd.Database;
using MyLetterBoxd.Service;

var  AllowLocalhost4200 = "_myAllowLocalhost4200";

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Define CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowLocalhost4200,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<MyLetterBoxdContext>(options => 
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TMDBService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(AllowLocalhost4200);
app.UseAuthorization();
app.MapControllers();
app.Run();


