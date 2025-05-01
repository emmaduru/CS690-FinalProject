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
            if (command == "Set habit goals") {
                Console.WriteLine("Set goals for: ");
                for (int index = 0; index < dataManager.Habits.Count(); index++) {
                    Habit habitItem = dataManager.Habits[index];
                    int goal = AnsiConsole.Prompt(new TextPrompt<int>(habitItem.Name + ": "));
                    habitItem.updateGoal(goal);

                    // update habits.txt
                    dataManager.updateHabit(habitItem);
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

                        // update habits.txt
                        dataManager.updateHabit(habit);
                    }

                    if (operation == "Subtract") {
                        habit.subtractHabitDone();

                        // update habits.txt
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
                "Set habit goals",
                "Input habit",
                "Exit program"
                }));

        return command;
    }
}