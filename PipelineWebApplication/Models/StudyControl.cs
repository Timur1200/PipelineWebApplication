using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class StudyControl
{
    public int Id { get; set; }

    public int? TypeControlsId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual TypeControl? TypeControls { get; set; }
}
