namespace HabitTracker;

using System;

public class DataManager {

    public List<Habit> Habits { get; set; }

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
                newHabit.UpdateGoal(goal);
                Habits.Add(newHabit);
            }
        }   
    }

    public void SynchronizeHabits() {
        File.Delete("habits.txt");
        List<string> habitData = new List<string>();

        foreach (Habit item in Habits) {
            string habitLine = item + "," + item.GetGoal() + "," + item.GetDone();
            File.AppendAllText("habits.txt", habitLine + Environment.NewLine);
        }
    }

    public void AddHabit(Habit habit) {
        Habits.Add(habit);
        SynchronizeHabits();
    }

    public void UpdateHabit(Habit habit) {
        int habitIndex = Habits.FindIndex(t => t.Name == habit.Name);
        if (habitIndex != -1) {
            Habits[habitIndex] = habit;
            SynchronizeHabits();
        }
    }

    public Habit GetHabit(string habitName) {
        int index = Habits.FindIndex(t => t.Name == habitName);
        return Habits[index];
    }

    public void DeleteHabit(Habit habit) {
        int habitIndex = Habits.FindIndex(t => t.Name == habit.Name);
        if (habitIndex != -1) {
            Habits.Remove(Habits[habitIndex]);
            SynchronizeHabits();
        }
    }

    public void DeleteAllHabits() {
        Habits = new List<Habit>();
        SynchronizeHabits();
    }

    public void ResetAllInputs() {
        for (int index = 0; index < Habits.Count; index++) {
            Habits[index].SetDoneZero();
        }
        SynchronizeHabits();
    }

}