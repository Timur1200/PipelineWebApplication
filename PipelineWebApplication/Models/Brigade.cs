using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PipelineWebApplication.Models;

public partial class Brigade
{
    
    public int Id { get; set; }

    public int? UnitId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PipelineDatum> PipelineData { get; } = new List<PipelineDatum>();

    public virtual Unit? Unit { get; set; }

    /// <summary>
    /// Возвращает полное имя Бригады(Владелец)[NotMapped]
    /// </summary>
    [NotMapped]
    public string FullName
    {
        get
        {
            return $"{Unit.Owner.Name} {Unit.Name} {Name}";
        }
    }
}
