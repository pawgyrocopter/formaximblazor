﻿using System.Security.Cryptography.X509Certificates;

namespace BlazorApp1.Data;

public class ResponseLogin
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Token { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Adress { get; set; }

}