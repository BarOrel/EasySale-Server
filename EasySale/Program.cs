using EasySale.Data;
using EasySale.Data.Repository;
using EasySale.Services.DepratmentService;
using EasySale.Services.TasksService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IDepratmentService, DepratmentService>();



builder.Services.AddDbContext<Tasks_DbContext>(options => options.UseSqlServer("Data Source=desktop-mgpqkat;Initial Catalog=EasySale_DB;Integrated Security=True;Pooling=False;trustServerCertificate=true"));


builder.Services.AddCors(options => options.AddPolicy(name: "clientsOrigins",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("clientsOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
