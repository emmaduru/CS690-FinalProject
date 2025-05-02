namespace HabitTracker.Tests;
using HabitTracker;

public class DataManagerTests
{
    DataManager dataManager;
    List<string> testEntries;
    public DataManagerTests () {
        testEntries = new List<string>();
        testEntries.Add("Goal1,1,1");
        testEntries.Add("Goal2,2,3");
        testEntries.Add("Goal3,4,5");
        File.WriteAllLines("habits.txt", testEntries);
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_DataManager_Initialization()
    {
        Assert.Equal(3, dataManager.Habits.Count);
    }

    [Fact]
    public void Test_DataManager_AddHabit()
    {
        dataManager.AddHabit(new Habit("New Habit"));
        Assert.Equal(4, dataManager.Habits.Count);
    }

    [Fact]
    public void Test_DataManager_UpdateHabit()
    {
        Habit newHabit = new Habit("Goal3");
        newHabit.updateGoal(1000);
        dataManager.updateHabit(newHabit);
        int habitIndex = dataManager.Habits.FindIndex(t => t == newHabit);
        Assert.Equal(true, habitIndex != -1);
    }

    [Fact]
    public void Test_DataManager_GetHabit()
    {
        Habit newHabit = new Habit("Goal4");
        dataManager.AddHabit(newHabit);
        Habit gotHabit = dataManager.getHabit("Goal4");
        Assert.Equal(true, newHabit == gotHabit);
    }

    [Fact]
    public void Test_DataManager_DeleteHabit()
    {
        Habit newHabit = new Habit("Goal4");
        dataManager.deleteHabit(newHabit);
        int habitIndex = dataManager.Habits.FindIndex(t => t == newHabit);
        Assert.Equal(true, habitIndex == -1);
    }

    [Fact]
    public void Test_DataManager_DeleteAllHabits()
    {
        dataManager.DeleteAllHabits();
        Assert.Equal(0, dataManager.Habits.Count);
    }
}