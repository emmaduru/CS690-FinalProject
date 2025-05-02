
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

    public int GetGoal() {
        return this.Goal;
    }

    public void UpdateGoal(int goal) {
        this.Goal = goal;
    }

    public int GetDone() {
        return this.Done;
    }

    public void AddHabitDone(int amount) {
        this.Done += amount;
    }

    public void SubtractHabitDone(int amount) {
        if (this.Done > amount) {
            this.Done -= amount;
        } else {
            this.Done = 0;
        }
    }

    public void SetDoneZero() {
        this.Done = 0;
    }

    public bool IsCompleted() {
        if (this.Done >= this.GetGoal()) {
            return true;
        } else {
            return false;
        }
    }

    public override string ToString () {
        return this.Name;
    }
}

