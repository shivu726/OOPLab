using System;
using System.Collections.Generic;

namespace ContactManagementApp.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? City { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Country { get; set; }
}
