﻿namespace Week2_Assignment.Schema.Songs.Requests;

public class UserUpdateRequest
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }  
}