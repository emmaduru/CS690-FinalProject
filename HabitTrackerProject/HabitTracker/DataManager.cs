namespace HabitTracker;

public class DataManager {

    public List<Habit> Habits { get; }

    public DataManager() {
        Habits = new List<Habit>();

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

    public void updateHabit(Habit habit) {
        int habitIndex = Habits.FindIndex(t => t == habit);
        Habits[habitIndex] = habit;
        List<string> habitData = new List<string>();

        foreach (Habit item in Habits) {
            string habitLine = item + "," + item.getGoal() + "," + item.getDone();
            habitData.Add(habitLine);
        }
        File.WriteAllLines("habits.txt", habitData);
    }

}