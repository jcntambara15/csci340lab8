using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class Music
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public string? Genre { get; set; }
    public string? Country { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
}