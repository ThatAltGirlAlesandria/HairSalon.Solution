using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int stylist_id { get; set; }
    public string stylist_name { get; set; }
    public string stylist_details { get; set; }
    public List<Client> Client { get; set; }
  }
}