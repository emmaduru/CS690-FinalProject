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

        Habit habit;
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

                
                List<string> habitChoices = new List<string>();
                foreach (Habit item in dataManager.Habits) {
                    habitChoices.Add(item.Name);
                }
                habitChoices.Add("Go back");

                while (true) {
                    string choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title($"Choose habit")
                            .AddChoices(habitChoices));

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
                    habit = AnsiConsole.Prompt(
                        new SelectionPrompt<Habit>()
                            .Title("Choose habit")
                            .AddChoices(dataManager.Habits));

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
                        dataManager.updateHabit(habit);
                    }

                    if (operation == "Subtract") {
                        habit.subtractHabitDone();
                        dataManager.updateHabit(habit);
                    }

                    AnsiConsole.WriteLine($"{habit} successfully updated. {habit.getDone()} {habit} completed.");

                } while (operation == "Go back");


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
                    "Exit program"
                }));

        return command;
    }
}