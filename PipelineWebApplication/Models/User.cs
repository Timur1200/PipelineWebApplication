using System;
using System.Collections.Generic;

namespace PipelineWebApplication;

/// <summary>
/// Пользователь
/// </summary>
public partial class User
{
    public int Id { get; set; }

    public int? RoleId { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public string? SurName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }
    /// <summary>
    /// Логин
    /// </summary>
    public string? Login { get; set; }
    /// <summary>
    /// Пароль
    /// </summary>
    public string? Pass { get; set; }
    /// <summary>
    /// Роль
    /// </summary>
    public virtual Role? Role { get; set; }
}
