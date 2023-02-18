using SuaSaudeInfraData.Repository;
using SuaSaudeService;
using SuaSaudeService.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//scope é um ciclo de vida por requisição, cada pedida vai instanciar um novo objeto
builder.Services.AddScoped<ISuaSaudeService, SuaSaudeServices>();
builder.Services.AddScoped<IClassificacaoIMCRepository, ClassificacaoImcRepository>();


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
