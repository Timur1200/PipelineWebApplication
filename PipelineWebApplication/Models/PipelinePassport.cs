using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    /// 
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
    public double? ТолщинаСтенки { get; set; }

    /// <summary>
    /// глубина укладки
    /// </summary>
    [Display(Name = "Глубина укладки")]
    public double? ГлубинаУкладки { get; set; }

    /// <summary>
    /// Дата нанесения внешнего покрытия
    /// </summary>
    [Display(Name = "Дата нанесения внешн. покр.")]
    public DateOnly? DateInternalCoating { get; set; }

    /// <summary>
    /// наруж покрытие
    /// </summary>
    [Display(Name = "Наружнее покрытие")]
    public string? НаружноеПокрытие { get; set; }

    /// <summary>
    /// вид строит
    /// </summary>
    [Display(Name = "Вид строительства")]
    public string? ВидСтроительства { get; set; }

    /// <summary>
    /// налич откл от проекта
    /// </summary>
    [Display(Name = "Наличие отклонения от проекта")]
    public bool? НаличиеОтклоненияОтПроекта { get; set; }

    /// <summary>
    /// стоимость строительства
    /// </summary>
    [Display(Name = "Стоимость строительства")]
    public decimal? СтоимостьСтроительства { get; set; }

    /// <summary>
    /// примечание
    /// </summary>
    [Display(Name = "Примечание")]
    public string? Note { get; set; }

    /// <summary>
    /// замена
    /// </summary>
    [Display(Name = "Замена стыков с")]
    public int? ЗаменаСтыков1 { get; set; }

    /// <summary>
    /// с какого по какое
    /// </summary>
    [Display(Name = "по")]
    public int? ЗаменаСтыков2 { get; set; }

    /// <summary>
    /// количество стыков
    /// </summary>
    [Display(Name = "в количестве, шт.")]
    public int? Количество { get; set; }

    /// <summary>
    /// дата замены стыков
    /// </summary>
    [Display(Name = "Дата замены стыков")]
    public DateOnly? ДатаЗаменыСтыков { get; set; }

    public virtual BuildingСompany? BuildingCompany { get; set; }

    public virtual Factory? FactoryMpt { get; set; }

    public virtual Factory? FactoryPipe { get; set; }

    public virtual InternalСoating? InternalCoating { get; set; }

    public virtual Material? Material { get; set; }

    public virtual PipeType? PipeType { get; set; }

    public virtual PipelineDatum? PipelineData { get; set; }
}
