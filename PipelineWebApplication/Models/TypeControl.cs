using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class TypeControl
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StudyControl> StudyControls { get; } = new List<StudyControl>();
}
