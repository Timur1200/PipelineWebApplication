using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;
/// <summary>
/// Владелец
/// </summary>
public partial class Owner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Region> Regions { get; } = new List<Region>();

    public virtual ICollection<Unit> Units { get; } = new List<Unit>();
}
