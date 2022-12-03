using System;
using System.Collections.Generic;

namespace PipelineWebApplication.Models;

public partial class PipelinePassport
{
    public int Id { get; set; }

    public int? FactoryMptid { get; set; }

    public int? FactoryPipeId { get; set; }

    public int? BuildingCompanyId { get; set; }

    public int? MaterialId { get; set; }

    public int? InternalCoatingId { get; set; }

    public int? PipeTypeId { get; set; }

    public int? PipelineDataId { get; set; }

    public string? PlotStart { get; set; }

    public string? PlotEnd { get; set; }

    public double? Lenght { get; set; }

    public DateOnly? Date { get; set; }

    public string? Status { get; set; }

    public double? Diameter { get; set; }

    public double? ТолщинаСтенки { get; set; }

    public double? ГлубинаУкладки { get; set; }

    public DateOnly? DateInternalCoating { get; set; }

    public string? НаружноеПокрытие { get; set; }

    public string? ВидСтроительства { get; set; }

    public bool? НаличиеОтклоненияОтПроекта { get; set; }

    public decimal? СтоимостьСтроительства { get; set; }

    public string? Note { get; set; }

    public int? ЗаменаСтыков1 { get; set; }

    public int? ЗаменаСтыков2 { get; set; }

    public int? Количество { get; set; }

    public DateOnly? ДатаЗаменыСтыков { get; set; }

    public virtual BuildingСompany? BuildingCompany { get; set; }

    public virtual Factory? FactoryMpt { get; set; }

    public virtual Factory? FactoryPipe { get; set; }

    public virtual InternalСoating? InternalCoating { get; set; }

    public virtual Material? Material { get; set; }

    public virtual PipeType? PipeType { get; set; }

    public virtual PipelineDatum? PipelineData { get; set; }
}
