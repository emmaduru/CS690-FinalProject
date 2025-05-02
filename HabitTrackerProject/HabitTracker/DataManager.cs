namespace HabitTracker;

using System;

public class DataManager {

    public List<Habit> Habits { get; }

    public DataManager() {
        Habits = new List<Habit>();

        // Create habits.txt file if it does not exist
        if (!File.Exists("habits.txt")) {
            File.Create("habits.txt");
        } else {
            // Get habits from habits.txt file
            string[] contentFromFile = File.ReadAllLines("habits.txt");
            foreach(string line in contentFromFile) {
                string[] splitted = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                string name = splitted[0];
                int goal = int.Parse(splitted[1]);
                int done = int.Parse(splitted[2]);

                Habit newHabit = new Habit(name);
                newHabit.updateGoal(goal);
                Habits.Add(newHabit);
            }
        }   
    }

    public void SynchronizeHabits() {
        List<string> habitData = new List<string>();

        foreach (Habit item in Habits) {
            string habitLine = item + "," + item.getGoal() + "," + item.getDone();
            habitData.Add(habitLine);
        }
        File.WriteAllLines("habits.txt", habitData);
    }

    public void AddHabit(Habit habit) {
        Habits.Add(habit);
        SynchronizeHabits();
    }

    public void updateHabit(Habit habit) {
        int habitIndex = Habits.FindIndex(t => t.Name == habit.Name);
        if (habitIndex != -1) {
            Habits[habitIndex] = habit;
            SynchronizeHabits();
        }
    }

    public Habit getHabit(string habitName) {
        int index = Habits.FindIndex(t => t.Name == habitName);
        return Habits[index];
    }

    public void deleteHabit(Habit habit) {
        int habitIndex = Habits.FindIndex(t => t.Name == habit.Name);
        if (habitIndex != -1) {
            Habits.Remove(Habits[habitIndex]);
            SynchronizeHabits();
        }
    }

}