
using WebApi;
using WebApi.Middlewares;
using WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<WorkContext>(builder.Configuration.GetConnectionString("cnWork"));
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); //Agregando dependencias con Interfases
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService()); //Agregando dependencias sin Interfases
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IWorkService, WorkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage(); // middlewares que crea una pagina de bienvenida automatico
//app.UseTimeMiddleWare();

app.MapControllers();

app.Run();
