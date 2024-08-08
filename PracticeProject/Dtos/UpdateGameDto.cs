namespace PracticeProject.Dtos;

public record class UpdateGameDto
(
    string Title,
    string? Genre,
    decimal Price,
    DateOnly ReleaseDate
);