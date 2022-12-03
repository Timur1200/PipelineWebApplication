using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class Unit
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Brigade> Brigades { get; } = new List<Brigade>();

    public virtual Owner? Owner { get; set; }
}
