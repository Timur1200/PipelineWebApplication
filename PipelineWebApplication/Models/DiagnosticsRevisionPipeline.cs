using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class DiagnosticsRevisionPipeline
{
    public int Id { get; set; }

    public int? ExpertOrganizationId { get; set; }

    public int? PipelineDataId { get; set; }

    public int? ReasonsDiagnosticsId { get; set; }

    public int? StudyId { get; set; }

    public DateOnly? DateStudy { get; set; }

    public DateOnly? NextDateStudy { get; set; }

    public int? NumberOfPits { get; set; }

    public string? RegNumberOfRostekhnadzor { get; set; }

    public decimal? Salary { get; set; }

    public string? LetterNumber { get; set; }

    public DateOnly? LetterDate { get; set; }

    public string? PathFile { get; set; }

    public virtual ExpertOrganization? ExpertOrganization { get; set; }

    public virtual PipelineDatum? PipelineData { get; set; }

    public virtual Study? Study { get; set; }
}
