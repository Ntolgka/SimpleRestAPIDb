using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Week2_Assesment.Models;

public class Song
{
    [DisplayName("Song ID")]
    [Key]   //Because this project works with a list and not database, this annotation doesn't provide any functional benefits...
    public int Id { get; set; }
    public string Band { get; set; }
    [DisplayName("Song Name")]
    public string Name { get; set; }
    public string Album { get; set; } 
    [DisplayName("Release Date")]
    public int ReleaseDate { get; set; }
    
}