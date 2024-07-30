namespace Week2_Assignment.Schema.Songs.Requests;

public record UserCreateRequest
{
    public string Username { get; set; }
    public string Password { get; set; }  
}