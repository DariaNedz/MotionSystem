namespace MotionSystem.Models;

public class ExerciseItem
{
    public string Name { get; set; }
    public int Xp { get; set; }
    public bool IsCompleted { get; set; }

    // מעהûץ
    public bool RequiresRest { get; set; }
    public int RestSeconds { get; set; }
}