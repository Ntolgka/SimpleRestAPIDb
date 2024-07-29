using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week2_Assesment.Models;

public class Song
{
    [DisplayName("Song ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Band { get; set; }
    [DisplayName("Song Name")]
    public string Name { get; set; }
    public string Album { get; set; } 
    [DisplayName("Release Date")]
    public int ReleaseYear { get; set; }
    
}