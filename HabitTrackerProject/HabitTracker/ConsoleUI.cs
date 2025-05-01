namespace HabitTracker;
using System;
using Spectre.Console;

public class ConsoleUI
{
    List<Habit> Habits;
    public ConsoleUI () {
        Habits = new List<Habit>();
    }

    public void Show() {

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


        Habit habit;
        string operation;
        string command;
        
        // Main menu
        command = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What do you want to do?")
                .AddChoices(new[] {
                    "Set habit goals",
                    "Input habit",
                    "View report",
                    "Exit program"
                }));

        while (command != "Exit program") {
            if (command == "Set habit goals") {
                Console.WriteLine("Set goals for: ");
                for (int index = 0; index < Habits.Count(); index++) {
                    Habit habitItem = Habits[index];
                    int goal = AnsiConsole.Prompt(new TextPrompt<int>(habitItem.Name));

                    Habit newHabit = habitItem;
                    habitItem.updateGoal(goal);

                    // update habits.txt
                    int habitIndex = Habits.FindIndex(t => t == newHabit);
                    Habits[habitIndex] = newHabit;
                    List<string> habitData = new List<string>();

                    foreach (Habit item in Habits) {
                        string habitLine = item + "," + item.getGoal() + "," + item.getDone();
                        habitData.Add(habitLine);
                    }
                    File.WriteAllLines("habits.txt", habitData);
                }

            } else if (command == "Input habit"){

                do {
                    habit = AnsiConsole.Prompt(
                        new SelectionPrompt<Habit>()
                            .Title("Choose habit")
                            .AddChoices(Habits));

                    operation = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title($"Do you want to add or subtract from {habit}")
                            .AddChoices(new[] {
                                "Add",
                                "Subtract",
                                "Go back"
                            }));
                    
                    if (operation == "Add") {
                        habit.addHabitDone();

                        // update habits.txt
                        int habitIndex = Habits.FindIndex(t => t == habit);
                        Habits[habitIndex] = habit;
                        List<string> habitData = new List<string>();

                        foreach (Habit item in Habits) {
                            string habitLine = item + "," + item.getGoal() + "," + item.getDone();
                            habitData.Add(habitLine);
                        }
                        File.WriteAllLines("habits.txt", habitData);
                    }

                    if (operation == "Subtract") {
                        habit.subtractHabitDone();

                        // update habits.txt
                        int habitIndex = Habits.FindIndex(t => t == habit);
                        Habits[habitIndex] = habit;
                        List<string> habitData = new List<string>();

                        foreach (Habit item in Habits) {
                            string habitLine = item + "," + item.getGoal() + "," + item.getDone();
                            habitData.Add(habitLine);
                        }
                        File.WriteAllLines("habits.txt", habitData);
                    }

                    AnsiConsole.WriteLine($"{habit} successfully updated. {habit.getDone()} {habit} completed.");

                } while (operation == "Go back");


            } else if (command == "View report") {
                var table = new Table();
                table.AddColumn("Habit");
                table.AddColumn("Goal");
                table.AddColumn("Done");
                table.AddColumn("Status");

                foreach (Habit habitItem in Habits) {
                    string status = habitItem.isCompleted() ? "[green]Completed[/]" : "[red]Not Completed[/]";
                    table.AddRow(habitItem.Name, Convert.ToString(habitItem.getGoal()), Convert.ToString(habitItem.getDone()), status);
                }
                AnsiConsole.Write(table);
            }
            command = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[] {
                    "Set habit goals",
                    "Input habit",
                    "View report",
                    "Exit program"
                    }));
        }

    }
}