﻿namespace Model;

public class Rating
{
    public decimal Rate { get; set; }
    public int Count { get; set; }

    public override string ToString()
        => $"Rate: {Rate}";
}