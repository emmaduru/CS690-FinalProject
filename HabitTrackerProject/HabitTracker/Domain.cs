
namespace HabitTracker;

using System;

public class Habit {
    public string Name { get; }
    private int Goal { get; set; }
    private int Done { get; set; }

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

    public int getDone() {
        return this.Done;
    }

    public void addHabitDone(int amount) {
        this.Done += amount;
    }

    public void subtractHabitDone(int amount) {
        if (this.Done > amount) {
            this.Done -= amount;
        } else {
            this.Done = 0;
        }
    }

    public bool isCompleted() {
        if (this.Done >= this.getGoal()) {
            return true;
        } else {
            return false;
        }
    }

    public override string ToString () {
        return this.Name;
    }
}

