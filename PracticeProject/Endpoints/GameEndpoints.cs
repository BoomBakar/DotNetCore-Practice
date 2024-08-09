using PracticeProject.Dtos;

namespace PracticeProject.Endpoints;

public static class GameEndpoints
{
    private static readonly List<GameDto> games = [
    new GameDto(1, "Super Mario", "Adventure", 20.00m, new DateOnly(1985, 9, 13)),
    new GameDto(2, "Contra", "Shooting", 15.00m, new DateOnly(1987, 2, 20)),
    new GameDto(3, "Duck Hunt", "Shooting", 10.00m, new DateOnly(1984, 4, 21)),
    new GameDto(4, "PacMan", "Arcade", 5.00m, new DateOnly(1980, 5, 22)),
    ];

    public static WebApplication MapGameEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        //get all games
        app.MapGet("/games", () => games);

        //get a game by id
        app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id) ?? new GameDto(0, "Not Found", null, 0.00m, new DateOnly(1900, 1, 1)));

        app.MapGet("/users", () => "Welcome to Users Page");

        app.MapPost("/games", (CreateGameDto newGame) =>
        {
            int id = games.Count + 1;
            games.Add(new GameDto(id, newGame.Title, newGame.Genre, newGame.Price, newGame.ReleaseDate));
            return Results.Created($"/games/{id}", games[id - 1]);
        });

        app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var existingGame = games.Find(g => g.Id == id);
            if (existingGame == null)
            {
                return Results.NotFound();
            }

            var index = games.IndexOf(existingGame);
            games[index] = existingGame with
            {
                Title = updatedGame.Title,
                Genre = updatedGame.Genre,
                Price = updatedGame.Price,
                ReleaseDate = updatedGame.ReleaseDate
            };

            return Results.NoContent();
        });

        app.MapDelete("/games/{id}", (int id) =>
        {
            var existingGame = games.Find(g => g.Id == id);
            if (existingGame == null)
            {
                return Results.NotFound();
            }

            games.Remove(existingGame);
            return Results.NoContent();
        });
        return app;
    }
}