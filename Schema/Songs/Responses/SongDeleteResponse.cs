namespace Week2_Assignment.Schema.Songs.Responses;

public class SongDeleteResponse
{
    public int Id { get; set; }
    public string Band { get; set; }
    public string Name { get; set; }
    public string Album { get; set; }
    public int ReleaseYear { get; set; }
}