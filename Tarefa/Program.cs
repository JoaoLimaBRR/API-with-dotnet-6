using Tarefa.Data;

var builder = WebApplication.CreateBuilder(args);
//addicionando o servi�o de controler
builder.Services.AddControllers();
//criando o dbcontxt como servi�o, assim o aspnet gerencia o dispose do objeto
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();
//mapenado todas as controllers
app.MapControllers();


app.Run();
