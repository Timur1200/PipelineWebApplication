using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class Region
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Owner? Owner { get; set; }

    public virtual ICollection<PipelineDatum> PipelineDatumRegionControls { get; } = new List<PipelineDatum>();

    public virtual ICollection<PipelineDatum> PipelineDatumRegionEnds { get; } = new List<PipelineDatum>();

    public virtual ICollection<PipelineDatum> PipelineDatumRegionStarts { get; } = new List<PipelineDatum>();
}
