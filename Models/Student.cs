using System;
using System.Collections.Generic;

namespace API_with_DB.Models;

public partial class Student
{
    public int RollNo { get; set; }

    public string Name { get; set; } = null!;

    public string Branch { get; set; } = null!;

    public long MobileNo { get; set; }

    public string Email { get; set; } = null!;

    public string State { get; set; } = null!;
}
