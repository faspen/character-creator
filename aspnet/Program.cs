using Microsoft.EntityFrameworkCore;
using CharacterCreator.Data;
using CharacterCreator.Interfaces;
using CharacterCreator.Repositories;
using CharacterCreator.Dtos; // Adjust this to your actual namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CharacterCreatorAutoMapper));
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework and other services here.
builder.Services.AddDbContext<CharacterCreatorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Your Angular app URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin"); // Apply the CORS policy
app.UseAuthorization();
app.MapControllers();

app.Run();
