using System;
using System.Collections.Generic;

namespace PipelineWebApplication;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
