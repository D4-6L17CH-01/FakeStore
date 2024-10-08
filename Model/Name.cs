﻿namespace Model;

public class Name
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public override string ToString()
        => $"{FirstName} {LastName}";
}
