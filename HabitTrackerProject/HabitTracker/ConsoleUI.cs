namespace HabitTracker;
using System;
using Spectre.Console;

public class ConsoleUI
{
    DataManager dataManager;
    public ConsoleUI () {
        dataManager = new DataManager();
    }

    public void Show() {

        string choice;
        string operation;
        string command;
        
        // Main menu
        command = ShowMainMenu();

        while (command != "Exit program") {

            if (command == "Add habit") {

                string habitName = AnsiConsole.Prompt(new TextPrompt<string>("Name of habit: "));
                int habitGoal = AnsiConsole.Prompt(new TextPrompt<int>("Habit Goal: "));
                Habit newHabit = new Habit(habitName);
                newHabit.updateGoal(habitGoal);
                dataManager.AddHabit(newHabit);
                AnsiConsole.WriteLine($"Habit '{newHabit}' successfully created.");

            } else if (command == "Update habit goals") {

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
                    habitChoice.updateGoal(habitGoal);
                    dataManager.updateHabit(habitChoice);

                    AnsiConsole.WriteLine($"{habitChoice} successfully updated. New goal is {habitGoal}.");
                }

            } else if (command == "Input habit"){
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

                    Habit habit = dataManager.getHabit(choice);
                    
                    if (operation == "Add") {
                        int habitGoal = AnsiConsole.Prompt(new TextPrompt<int>("How much do you want to add: "));
                    
                        habit.addHabitDone(habitGoal);
                        dataManager.updateHabit(habit);
                        AnsiConsole.WriteLine($"{habit} successfully updated. {habit.getDone()} {habit} completed.");
                    }

                    if (operation == "Subtract") {
                        int habitGoal = AnsiConsole.Prompt(new TextPrompt<int>("How much do you want to subtract: "));
                        habit.subtractHabitDone(habitGoal);
                        dataManager.updateHabit(habit);
                        AnsiConsole.WriteLine($"{habit} successfully updated. {habit.getDone()} {habit} completed.");
                    }

                    

                } while (operation != "Go back");
            } else if (command == "Delete habit") {
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
                    Habit habitChoice = new Habit(choice);
                    dataManager.deleteHabit(habitChoice);

                    AnsiConsole.WriteLine($"{habitChoice} successfully deleted.");
                }
            } else if (command == "View report") {
                
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
                        
                        if (habit.getDone() == 0) {
                            status = "[red]Not Started[/]";
                        } else {
                            status = habit.isCompleted() ? "[green]Complete[/]" : "[red]Incomplete[/]";
                        }
                        table.AddRow(habit.Name, Convert.ToString(habit.getGoal()), Convert.ToString(habit.getDone()), status);
                    }
                    AnsiConsole.Write(table);
                }
                
            } else if (command == "Delete all habits") {
                dataManager.DeleteAllHabits();
                AnsiConsole.WriteLine("All habits have been deleted.");
            }
            
            command = ShowMainMenu();
        }

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
}