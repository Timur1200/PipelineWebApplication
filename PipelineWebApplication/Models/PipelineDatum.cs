using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PipelineWebApplication.Models;

public partial class PipelineDatum
{
    public int Id { get; set; }

    [Display(Name= "Бригада")]
    public int? BrigadeId { get; set; }

    [Display(Name = "Месторождение")]
    public int? FieldId { get; set; }

    public int? RegionStartId { get; set; }

    public int? RegionEndId { get; set; }

    public int? RegionControlId { get; set; }

    public string Name { get; set; } = null!;

    public int? SignDouble { get; set; }

    public string? TieInPlace { get; set; }

    public double? Length { get; set; }

    public double? OptimizedLength { get; set; }

    public DateOnly? Date { get; set; }

    public string? Purpose { get; set; }

    public string? TransportedMedium { get; set; }

    public char? Category { get; set; }

    public string? FlowsheetNumber { get; set; }

    public string? Note { get; set; }

    public double? DebitWater { get; set; }

    public double? DebitOil { get; set; }

    public string? State { get; set; }

    public double? Temperature { get; set; }

    public double? PFact { get; set; }

    public double? PCalculated { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Brigade? Brigade { get; set; }

    public virtual ICollection<DiagnosticsRevisionPipeline> DiagnosticsRevisionPipelines { get; } = new List<DiagnosticsRevisionPipeline>();

    public virtual Field? Field { get; set; }

    public virtual ICollection<PipelinePassport> PipelinePassports { get; } = new List<PipelinePassport>();

    public virtual Region? RegionControl { get; set; }

    public virtual Region? RegionEnd { get; set; }

    public virtual Region? RegionStart { get; set; }
}
