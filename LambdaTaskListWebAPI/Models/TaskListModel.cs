﻿namespace LambdaTaskListWebAPI.Models
{
    public class TaskListModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool isComplete { get; set; }
    }
}
