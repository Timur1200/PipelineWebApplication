using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PipelineWebApplication.Models;

/// <summary>
/// Пспорт трубопровода
/// </summary>
public partial class PipelinePassport
{
    /// <summary>
    /// код
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// завод изготовитель мпт мпт-к
    /// </summary>
    [Display(Name = "Завод-изготовитель МПТ(МПТ-К)")]
    public int? FactoryMptid { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Display(Name = "Завод-изготовитель трубной продукции")]
    public int? FactoryPipeId { get; set; }

    /// <summary>
    /// Код строит компании
    /// </summary>
    [Display(Name = "Строительная Организация")]
    public int? BuildingCompanyId { get; set; }

    /// <summary>
    /// код материала
    /// </summary>
    [Display(Name = "Материал")]
    public int? MaterialId { get; set; }

    /// <summary>
    /// код внутрен.покрытия
    /// </summary>
    [Display(Name = "Внутреннее покрытие")]
    public int? InternalCoatingId { get; set; }

    /// <summary>
    /// код типа трубы
    /// </summary>
    [Display(Name = "Тип трубы")]
    public int? PipeTypeId { get; set; }

    /// <summary>
    /// Данные трубопровода
    /// </summary>
    [Display(Name = "Данные трубопровода")]
    public int? PipelineDataId { get; set; }

    /// <summary>
    /// начало уч
    /// </summary>
    [Display(Name = "Начало участка (м)")]
    public string? PlotStart { get; set; }

    /// <summary>
    /// кон уч
    /// </summary>
    [Display(Name = "Конец участка (м)")]
    public string? PlotEnd { get; set; }

    /// <summary>
    /// длина уч
    /// </summary>
    [Display(Name = "Длина участка")]
    public double? Lenght { get; set; }

    /// <summary>
    /// дата ввода в экспл
    /// </summary>
    [Display(Name = "Дата ввода в эксплуатацию")]
    public DateOnly? Date { get; set; }

    /// <summary>
    /// текущ Состояние 
    /// </summary>
    [Display(Name = "Текущее состояние")]
    public string? Status { get; set; }

    /// <summary>
    /// Диаметр
    /// </summary>
    [Display(Name = "Диаметр (мм)")]
    public double? Diameter { get; set; }

    /// <summary>
    /// толщ стенки
    /// </summary>
    [Display(Name = "Толщина стенки")]
    public double? WallThickness { get; set; }

    /// <summary>
    /// глубина укладки
    /// </summary>
    [Display(Name = "Глубина укладки")]
    public double? PavingDepth { get; set; }

    /// <summary>
    /// Дата нанесения внешнего покрытия
    /// </summary>
    [Display(Name = "Дата нанесения внешн. покр.")]
    public DateOnly? DateInternalCoating { get; set; }

    /// <summary>
    /// наруж покрытие
    /// </summary>
    [Display(Name = "Наружнее покрытие")]
    public string? OutdoorCoating { get; set; }

    /// <summary>
    /// вид строит
    /// </summary>
    [Display(Name = "Вид строительства")]
    public string? TypeOfConstruction { get; set; }

    /// <summary>
    /// налич откл от проекта
    /// </summary>
    [Display(Name = "Наличие отклонения от проекта")]
    public bool? Deviation { get; set; }
    [NotMapped]
    [Display(Name = "Наличие отклонения от проекта")]
    public string DeviationToString
    {
        get
        {
            string text;
            if (Deviation.Value)
            {
                text = "Да";
            }
            else
            {
                text = "Нет";
            }
            return text;
        }
    }

    /// <summary>
    /// стоимость строительства
    /// </summary>
    [Display(Name = "Стоимость строительства (руб)")]
    public decimal? ConstructionCost { get; set; }

    /// <summary>
    /// примечание
    /// </summary>
    [Display(Name = "Примечание")]
    public string? Note { get; set; }

    /// <summary>
    /// замена
    /// </summary>
    [Display(Name = "Замена стыков с")]
    public int? JointReplacement1 { get; set; }

    /// <summary>
    /// с какого по какое
    /// </summary>
    [Display(Name = "по")]
    public int? JointReplacement2 { get; set; }

    /// <summary>
    /// количество стыков
    /// </summary>
    [Display(Name = "в количестве, шт.")]
    public int? Amount { get; set; }

    /// <summary>
    /// дата замены стыков
    /// </summary>
    [Display(Name = "Дата замены стыков")]
    public DateOnly? JointReplacementDate { get; set; }

    [Display (Name ="Строительная организация")]
    public virtual BuildingСompany? BuildingCompany { get; set; }

    [Display (Name = "Завод-изготовитель МПТ(МПТ-К)")]
    public virtual Factory? FactoryMpt { get; set; }
    [Display(Name = "Завод-изготовитель трубной продукции")]
    public virtual Factory? FactoryPipe { get; set; }

    public virtual InternalСoating? InternalCoating { get; set; }
    [Display(Name = "Материал")]
    public virtual Material? Material { get; set; }
    [Display(Name = "Тип трубы")]
    public virtual PipeType? PipeType { get; set; }
    [Display(Name = "Трубопровод")]
    public virtual PipelineDatum? PipelineData { get; set; }
}
