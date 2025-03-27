using System;
using System.Collections.Generic;

namespace GymAPI.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;
}
