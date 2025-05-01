namespace HabitTracker.Tests;
using HabitTracker;

public class DomainTests
{
    string name;
    int goal;
    Habit newHabit;
    Tracker newTracker;

    public DomainTests () {
        name = "First Habit";
        newHabit = new Habit(name);
        newTracker = new Tracker(newHabit);
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
    public void Test_Tracker_Initialization()
    {
        newHabit.updateGoal(1000);
        Assert.Equal(newTracker.Habit, newHabit);
        Assert.Equal(newTracker.getDone(), 0);
        Assert.Equal(newTracker.IsCompleted(), false);
    }

    [Fact]
    public void Test_Tracker_AddHabitDone()
    {
        newTracker.addHabitDone();
        Assert.Equal(newTracker.getDone(), 1);
    }

    [Fact]
    public void Test_Tracker_SubtractHabitDone()
    {
        newTracker.subtractHabitDone();
        Assert.Equal(newTracker.getDone(), 0);
    }
}