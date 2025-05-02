namespace HabitTracker;
using System;
using Spectre.Console;

public class ConsoleUIViews
{

    DataManager dataManager;
    public ConsoleUIViews () {
        dataManager = new DataManager();
    }
    public string ShowMainMenu() {
        string command = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What do you want to do?")
                .AddChoices(new[] {
                    "Add habit",
                    "Update habit goals",
                    "Input habit",
                    "Delete habit",
                    "Delete all habits",
                    "Reset all inputs",
                    "View report",
                    "Exit program"
                }));

        return command;
    }

    public List<string> GetHabitChoices() {
        List<string> habitChoices = new List<string>();
        foreach (Habit item in dataManager.Habits) {
            habitChoices.Add(item.Name);
        }
        habitChoices.Add("Go back");

        return habitChoices;     
    }

    public void AddHabitView () {
        string habitName = AnsiConsole.Prompt(new TextPrompt<string>("Name of habit: "));
        int habitGoal = AnsiConsole.Prompt(new TextPrompt<int>("Habit Goal: "));
        Habit newHabit = new Habit(habitName);
        newHabit.UpdateGoal(habitGoal);
        dataManager.AddHabit(newHabit);
        AnsiConsole.WriteLine($"Habit '{newHabit}' successfully created.");
    }

    public void UpdateHabitGoalsView () {
        string choice;
        while (true) {
            if (dataManager.Habits.Count == 0) {
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("There are no stored habits.")
                        .AddChoices(GetHabitChoices()));
            } else {
                choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose habit")
                    .AddChoices(GetHabitChoices()));
            }

            if (choice == "Go back") {
                break;
            }
        
            int habitGoal = AnsiConsole.Prompt(new TextPrompt<int>($"New goal for {choice}: "));
            Habit habitChoice = new Habit(choice);
            habitChoice.UpdateGoal(habitGoal);
            dataManager.UpdateHabit(habitChoice);

            AnsiConsole.WriteLine($"{habitChoice} successfully updated. New goal is {habitGoal}.");
        }
    }

    public void InputHabitView() {

        string choice;
        string operation;
        do {
            if (dataManager.Habits.Count == 0) {
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("There are no stored habits.")
                        .AddChoices(GetHabitChoices()));
            } else {
                choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose habit")
                    .AddChoices(GetHabitChoices()));
            }
            if (choice == "Go back") {
                break;
            }

            operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Do you want to add or subtract from {choice}")
                    .AddChoices(new[] {
                        "Add",
                        "Subtract",
                        "Go back"
                    }));

            Habit habit = dataManager.GetHabit(choice);
            
            if (operation == "Add") {
                int habitGoal = AnsiConsole.Prompt(new TextPrompt<int>("How much do you want to add: "));
            
                habit.AddHabitDone(habitGoal);
                dataManager.UpdateHabit(habit);
                AnsiConsole.WriteLine($"{habit} successfully updated. {habit.GetDone()} {habit} completed.");
            }

            if (operation == "Subtract") {
                int habitGoal = AnsiConsole.Prompt(new TextPrompt<int>("How much do you want to subtract: "));
                habit.SubtractHabitDone(habitGoal);
                dataManager.UpdateHabit(habit);
                AnsiConsole.WriteLine($"{habit} successfully updated. {habit.GetDone()} {habit} completed.");
            }

            

        } while (operation != "Go back");
    }

    public void DeleteHabitView() {
        string choice;
        while (true) {
            if (dataManager.Habits.Count == 0) {
                choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("There are no stored habits.")
                        .AddChoices(GetHabitChoices()));
            } else {
                choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose habit")
                    .AddChoices(GetHabitChoices()));
            }

            if (choice == "Go back") {
                break;
            }

            string deleteChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[red]Are you sure you want to delete {choice}?[/]")
                    .AddChoices(new[] {
                        "Yes",
                        "No"
                    }));
            if (deleteChoice == "Yes") {
                Habit habitChoice = new Habit(choice);
                dataManager.DeleteHabit(habitChoice);

                AnsiConsole.WriteLine($"{habitChoice} successfully deleted.");
            }
        }
    }

    public void ViewReportView() {
        string choice;
        if (dataManager.Habits.Count == 0) {
            choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("There are no stored habits.")
                    .AddChoices(GetHabitChoices()));
        } else {
            Table table = new Table();
            table.AddColumn("Habit");
            table.AddColumn("Goal");
            table.AddColumn("Done");
            table.AddColumn("Status");

            foreach (Habit habit in dataManager.Habits) {
                string status;
                
                if (habit.GetDone() == 0) {
                    status = "[red]Not Started[/]";
                } else {
                    status = habit.IsCompleted() ? "[green]Complete[/]" : "[red]Incomplete[/]";
                }
                table.AddRow(habit.Name, Convert.ToString(habit.GetGoal()), Convert.ToString(habit.GetDone()), status);
            }
            AnsiConsole.Write(table);
        }
    }

    public void DeleteAllHabitsView() {
        string choice;
        if (dataManager.Habits.Count == 0) {
            choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("There are no stored habits.")
                    .AddChoices(GetHabitChoices()));
        } else {
            string deleteChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[red]Are you sure you want to delete all habits?[/]")
                .AddChoices(new[] {
                    "Yes",
                    "No"
                }));
            if (deleteChoice == "Yes") {
                dataManager.DeleteAllHabits();
                AnsiConsole.WriteLine("All habits have been deleted.");
            }
            
        }
    }

    public void ResetAllInputsView() {
        string choice;
        if (dataManager.Habits.Count == 0) {
            choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("There are no stored habits.")
                    .AddChoices(GetHabitChoices()));
        } else {
            string resetChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[red]Are you sure you want to reset all inputs?[/]")
                .AddChoices(new[] {
                    "Yes",
                    "No"
                }));
            if (resetChoice == "Yes") {
                dataManager.ResetAllInputs();
                AnsiConsole.WriteLine("All habit inputs have ben reset.");
            }
            
        }
    }

}