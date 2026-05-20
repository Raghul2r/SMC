using System;
using System.Collections.Generic;

namespace TaskManagementApp.Models;

public partial class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string AssignedPerson { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public string Status { get; set; } = null!;
}
