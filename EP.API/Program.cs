using EP.BL.Abstract;
using EP.BL.Concrete;
using EP.DAL.Abstact;
using EP.DAL.Concrete;
using EP.DAL.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IEducationServices, EducationManager>();
builder.Services.AddScoped<IEducationDal, EfEducationDal>();

builder.Services.AddScoped<IEducationUserServices, EducationUserManager>();
builder.Services.AddScoped<IEducationUserDal, EfEducationUserDal>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
