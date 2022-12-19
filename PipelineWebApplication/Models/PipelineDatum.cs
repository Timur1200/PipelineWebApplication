using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PipelineWebApplication.Models;

/// <summary>
/// Данные трубопровода
/// </summary>
public partial class PipelineDatum
{
    public int Id { get; set; }

    /// <summary>
    /// Код бригады
    /// </summary>
    [Display(Name= "Владелец")]
    public int? BrigadeId { get; set; }

    /// <summary>
    /// код месторождения
    /// </summary>
    [Display(Name = "Месторождение")]
    public int? FieldId { get; set; }

    /// <summary>
    /// код обекта начала и конца
    /// </summary>
    [Display(Name = "Объект начала")]
    public int? RegionStartId { get; set; }

    [Display(Name = "Объект конца")]
    public int? RegionEndId { get; set; }

    /// <summary>
    /// код контрольного объекта
    /// </summary>
    [Display(Name = "Контрольный объект")]
    public int? RegionControlId { get; set; }

    /// <summary>
    /// наименование
    /// </summary>
    [Display(Name = "Наименование")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// признак дубля
    /// </summary>
    [Display(Name = "Признак дубля")]
    public int? SignDouble { get; set; }

    /// <summary>
    /// место врезки
    /// </summary>
    [Display(Name = "Место врезки")]
    public string? TieInPlace { get; set; }

    /// <summary>
    /// длина
    /// </summary>
    [Display(Name = "Длина (м)")]
    public double? Length { get; set; }
   

    /// <summary>
    /// оптимизир. длина
    /// </summary>
    [Display(Name = "Оптимизированная длина")]
    public double? OptimizedLength { get; set; }

    /// <summary>
    /// дата ввода в эксплуатацию
    /// </summary>
    [Display(Name = "Дата ввода в эксплуатацию")]
    public DateOnly? Date { get; set; }

    /// <summary>
    /// назначение
    /// </summary>
    [Display(Name = "Назначение")]
    public string? Purpose { get; set; }

    /// <summary>
    /// Транспортир.среда
    /// </summary>
    [Display(Name = "Транспортируемая среда")]
    public string? TransportedMedium { get; set; }

    /// <summary>
    /// категория
    /// </summary>
    [Display(Name = "Категория")]
    public char? Category { get; set; }

    /// <summary>
    /// номер по тех. схеме
    /// </summary>
    [Display(Name = "№ по технологической схеме")]
    public string? FlowsheetNumber { get; set; }

    /// <summary>
    /// Примечание
    /// </summary>
    [Display(Name = "Примечание")]
    public string? Note { get; set; }

    /// <summary>
    /// дебит жидкости
    /// </summary>
    [Display(Name = "Дебит жидкости")]
    public double? DebitWater { get; set; }

    /// <summary>
    /// дебит нефти
    /// </summary>
    [Display(Name = "Дебит нефти")]
    public double? DebitOil { get; set; }

    /// <summary>
    /// Обводненность
    /// </summary>
    [Display(Name = "Обводненность")]
    public string? State { get; set; }

    /// <summary>
    /// температура
    /// </summary>
    [Display(Name = "Температура (°C)")]
    public double? Temperature { get; set; }

    /// <summary>
    /// Р факт
    /// </summary>
    [Display(Name = "Р фактическое")]
    public double? PFact { get; set; }

    /// <summary>
    /// Р расчетн
    /// </summary>
    [Display(Name = "Р расчетное")]
    public double? PCalculated { get; set; }

    /// <summary>
    /// Пометка удалено
    /// </summary>
    public bool IsDeleted { get; set; }

    [Display (Name="Бригада")]
    public virtual Brigade? Brigade { get; set; }

    public virtual ICollection<DiagnosticsRevisionPipeline> DiagnosticsRevisionPipelines { get; } = new List<DiagnosticsRevisionPipeline>();
    [Display(Name ="Месторождение")]
    public virtual Field? Field { get; set; }

    public virtual ICollection<PipelinePassport> PipelinePassports { get; } = new List<PipelinePassport>();

    [Display (Name="Контрольный объект")]
    public virtual Region? RegionControl { get; set; }

    [Display (Name ="Объект конца")]
    public virtual Region? RegionEnd { get; set; }
    [Display (Name="Объект начала")]
    public virtual Region? RegionStart { get; set; }
}
