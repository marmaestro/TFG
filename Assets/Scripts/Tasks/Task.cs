using System;

[Serializable]
public abstract class Task
{
    public enum TaskStatus
    {
        undiscovered,
        asked,
        ongoing,
        finished
    }
    
    public TaskStatus Status;
    public DateTime startDate;
    public DateTime endDate;
}