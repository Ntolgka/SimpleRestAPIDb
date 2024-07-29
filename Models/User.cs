using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week2_Assesment.Models;

public class User
{
    [DisplayName("User ID")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]           //Auto increment Id.
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }    
}