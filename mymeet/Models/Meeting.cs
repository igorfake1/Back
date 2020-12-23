using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mymeet.Models
{
  public class Meeting
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Defina o título da reunião")]
    [MaxLength(100, ErrorMessage = "Este campo deve conter de 1 a 100 caracteres")]
    [MinLength(1, ErrorMessage = "Este campo deve conter de 1 a 100 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Id da sala é obrigatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Sala não existe")]
    public int RoomId { get; set; }

    [Required(ErrorMessage = "Defina uma data de inicio da reunião")]
    public DateTime Start { get; set; }

    [Required(ErrorMessage = "Defina uma data de término da reunião")]
    public DateTime End { get; set; }
    //public Room Room { get; set; }

    public Room Room { get; set; }

  }


}