namespace HabitTracker.Tests;
using HabitTracker;

public class DomainTests
{
    string name;
    int goal;
    Habit newHabit;

    public DomainTests () {
        name = "First Habit";
        newHabit = new Habit(name);
    }

    [Fact]
    public void Test_Habit_Initialization()
    {
        Assert.Equal(newHabit.Name, "First Habit");
        Assert.Equal(newHabit.GetGoal(), 0);
    }

    [Fact]
    public void Test_Habit_UpdateGoal()
    {
        newHabit.UpdateGoal(1000);
        Assert.Equal(newHabit.GetGoal(), 1000);
    }

    [Fact]
    public void Test_Habit_AddHabitDone()
    {
        newHabit.AddHabitDone(10);
        Assert.Equal(newHabit.GetDone(), 10);
    }

    [Fact]
    public void Test_Habit_SubtractHabitDone()
    {
        newHabit.AddHabitDone(10);
        newHabit.SubtractHabitDone(5);
        Assert.Equal(newHabit.GetDone(), 5);
    }

    [Fact]
    public void Test_Habit_IsCompleted()
    {
        newHabit.UpdateGoal(10);
        newHabit.AddHabitDone(20);
        Assert.Equal(newHabit.IsCompleted(), true);
        newHabit.SubtractHabitDone(20);
        Assert.Equal(newHabit.IsCompleted(), false);
    }
}