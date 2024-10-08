﻿namespace Model;

public class Geolocation
{
    public string? Lat { get; set; }
    public string? Long { get; set; }

    public override string ToString()
        => $"{Lat} - {Long}";
}
