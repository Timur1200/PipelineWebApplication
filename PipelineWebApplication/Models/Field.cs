using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class Field
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PipelineDatum> PipelineData { get; } = new List<PipelineDatum>();
}
