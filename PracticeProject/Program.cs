using PracticeProject.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new GameDto(1, "Super Mario", "Adventure", 20.00m, new DateOnly(1985, 9, 13)),
    new GameDto(2, "Contra", "Shooting", 15.00m, new DateOnly(1987, 2, 20)),
    new GameDto(3, "Duck Hunt", "Shooting", 10.00m, new DateOnly(1984, 4, 21)),
    new GameDto(4, "PacMan", "Arcade", 5.00m, new DateOnly(1980, 5, 22)),
];

app.MapGet("/", () => "Hello World!");

//get all games
app.MapGet("/games", () => games);

//get a game by id
app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id) ?? new GameDto(0, "Not Found", null, 0.00m, new DateOnly(1900, 1, 1)));

app.MapGet("/users", () => "Welcome to Users Page");

app.Run();
