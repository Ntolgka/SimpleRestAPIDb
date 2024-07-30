namespace Week2_Assignment.Schema.Songs.Requests;

public class SongUpdateRequest
{
    public string Band { get; set; }
    public string Name { get; set; }
    public string Album { get; set; }
    public int ReleaseYear { get; set; }
}