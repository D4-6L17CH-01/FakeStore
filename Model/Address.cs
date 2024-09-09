namespace Model;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
    public Geolocation Geolocation { get; set; }
}