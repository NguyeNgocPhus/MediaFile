using Microsoft.EntityFrameworkCore;
using PNN.File.Databases;
using PNN.File.DependencyInjection.Extensions;
using PNN.File.DependencyInjection.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediaFile();
builder.Services.AddControllers();

var appDb = builder.Configuration.GetSection("AppDb").Get<AppDbOption>();
builder.Services.AddPooledDbContextFactory<MediaFileDbContext>(option =>
{
    option.UseNpgsql($"Server={appDb.Server};Port={appDb.Port};User Id={appDb.UserName};Password={appDb.Password};Database={appDb.Database}");
    option.UseLoggerFactory(LoggerFactory.Create(loggingBuilder =>
    {
        loggingBuilder.AddConsole();
    }
    ));
});
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
