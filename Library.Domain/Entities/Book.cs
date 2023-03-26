namespace Library.Domain.Entities;
public class Book
{
    public int Id { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime TakingTime { get; set; }
    public DateTime ReturnTime => TakingTime.AddDays(30);
}
