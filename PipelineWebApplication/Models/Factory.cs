using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class Factory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PipelinePassport> PipelinePassportFactoryMpts { get; } = new List<PipelinePassport>();

    public virtual ICollection<PipelinePassport> PipelinePassportFactoryPipes { get; } = new List<PipelinePassport>();
}
