namespace HabitTracker;

using System;

public class Habit {
    public string Name { get; }
    private int Goal { get; set; }

    public Habit (string name) {
        this.Name = name;
        this.Goal = 0;
    }

    public int getGoal() {
        return this.Goal;
    }

    public void updateGoal(int goal) {
        this.Goal = goal;
    }

    public override string ToString () {
        return this.Name;
    }
}

public class Tracker {
    public Habit Habit { get; }
    private int Done { get; set; }

    public Tracker (Habit habit) {
        this.Habit = habit;
        this.Done = 0;
    }

    public int getDone() {
        return this.Done;
    }

    public void addHabitDone() {
        this.Done += 1;
    }

    public void subtractHabitDone() {
        if (this.Done > 0) {
            this.Done -= 1;
        }
    }

    public bool IsCompleted() {
        if (this.Done >= this.Habit.getGoal()) {
            return true;
        } else {
            return false;
        }
    }
}

public class Report {
    public DateTime Day { get; }
    public List<Tracker> Trackers { get; }
    
    public Report () {
        this.Day = DateTime.Today;
    }

    public string getTodaysReport() {
        throw new NotImplementedException();
    }

    public string getAllReports() {
        throw new NotImplementedException();
    }
}