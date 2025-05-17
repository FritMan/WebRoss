using System;
using System.Collections.Generic;

namespace BlazorApp3.Data;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public string Login { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public byte[] Photo { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
