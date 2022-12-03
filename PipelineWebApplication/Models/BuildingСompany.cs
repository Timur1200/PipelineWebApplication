using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class BuildingСompany
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PipelinePassport> PipelinePassports { get; } = new List<PipelinePassport>();
}
