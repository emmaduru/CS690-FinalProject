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
        newHabit.addHabitDone();
        Assert.Equal(newHabit.getDone(), 1);
    }

    [Fact]
    public void Test_Habit_SubtractHabitDone()
    {
        newHabit.subtractHabitDone();
        Assert.Equal(newHabit.getDone(), 0);
    }

    [Fact]
    public void Test_Habit_IsCompleted()
    {
        newHabit.updateGoal(10);
        for (int i = 0; i < 10; i++) {
            newHabit.addHabitDone();
        }
        Assert.Equal(newHabit.isCompleted(), true);
    }
}