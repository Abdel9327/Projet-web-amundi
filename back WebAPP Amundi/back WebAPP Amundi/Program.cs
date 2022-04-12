
using back_WebAPP_Amundi.DataBaseManager;
using back_WebAPP_Amundi.JsonManager;
using back_WebAPP_Amundi.Models;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<RequeteRepositorie, RequeteRepositorie>();
builder.Services.AddSingleton<jsonManager, jsonManager>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.Requete.json",
                       optional: true,
                       reloadOnChange: true);
});

builder.Services.AddRazorPages();

builder.Services.AddMvc();
builder.Services.Configure<RequeteSettings>(
    builder.Configuration.GetSection("RequeteSettings"));


//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
}
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
