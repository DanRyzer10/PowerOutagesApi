using AppLightBreaksSolution.DTOS;
using AppLightBreaksSolution.Services;
using AppLightBreaksSolution.Validations;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//services
builder.Services.AddScoped<ISchedulerService, ScheduleService>();

//Http CLients

builder.Services.AddHttpClient<ISchedulerService, ScheduleService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["baseUrlCnel"]);
});
//validators
builder.Services.AddScoped<IValidator<ScheduleDTO>, QueryScheduleValidator>();
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
