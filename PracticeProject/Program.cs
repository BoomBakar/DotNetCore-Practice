using PracticeProject.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGameEndpoints();

app.Run();
