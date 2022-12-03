using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class Study
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DiagnosticsRevisionPipeline> DiagnosticsRevisionPipelines { get; } = new List<DiagnosticsRevisionPipeline>();
}
