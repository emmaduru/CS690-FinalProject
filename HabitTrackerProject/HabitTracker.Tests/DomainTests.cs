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
        Assert.Equal(newHabit.getGoal(), 0);
    }

    [Fact]
    public void Test_Habit_UpdateGoal()
    {
        newHabit.updateGoal(1000);
        Assert.Equal(newHabit.getGoal(), 1000);
    }

    [Fact]
    public void Test_Habit_AddHabitDone()
    {
        newHabit.addHabitDone(10);
        Assert.Equal(newHabit.getDone(), 10);
    }

    [Fact]
    public void Test_Habit_SubtractHabitDone()
    {
        newHabit.addHabitDone(10);
        newHabit.subtractHabitDone(5);
        Assert.Equal(newHabit.getDone(), 5);
    }

    [Fact]
    public void Test_Habit_IsCompleted()
    {
        newHabit.updateGoal(10);
        newHabit.addHabitDone(20);
        Assert.Equal(newHabit.isCompleted(), true);
        newHabit.subtractHabitDone(20);
        Assert.Equal(newHabit.isCompleted(), false);
    }
}