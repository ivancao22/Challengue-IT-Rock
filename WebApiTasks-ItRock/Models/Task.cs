﻿using Microsoft.VisualBasic;

namespace WebApiTasks_ItRock.Models
{
    public class Task
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? DueDate { get; set; }
    }
}
