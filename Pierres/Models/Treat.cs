using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Pierres.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "No treats have been added!")]
    public string TreatType { get; set; }
    public Flavor Flavor { get; set; }
    public List<TreatFlavor> JoinTreat { get; }
    public ApplicationUser User { get; set; } 
  }
}