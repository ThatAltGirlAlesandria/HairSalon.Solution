namespace HairSalon.Models
{
  public class Client
  {
    public int client_id { get; set; }
    public string client_details { get; set; }
    public string client_name { get; set; }
    public int stylist_id { get; set; }
    public Stylist Stylist { get; set; }
  }
}