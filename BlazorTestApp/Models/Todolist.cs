using System;
using System.Collections.Generic;

namespace BlazorTestApp.Models;

public partial class Todolist
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Item { get; set; } = null!;

    public virtual Cpr User { get; set; } = null!;
}
