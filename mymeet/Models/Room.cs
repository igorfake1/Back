using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mymeet.Models
{
  public class Room
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(300, ErrorMessage = "Defina um nome de até 300 caracteres para a sala")]
    public string NameRoom { get; set; }

    public List<Meeting> Meetings { get; set; }
  }
}
