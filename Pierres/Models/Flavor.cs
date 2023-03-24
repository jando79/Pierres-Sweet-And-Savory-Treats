using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Pierres.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "The flavors field can't be empty!")]
    public string FlavorType { get; set; }
    public List<Treat> Treat { get; set; }
    public List<TreatFlavor> JoinTreat { get; }
    public ApplicationUser User { get; set; }
  }
}