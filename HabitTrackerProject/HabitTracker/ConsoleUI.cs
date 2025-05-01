namespace HabitTracker;
using Spectre.Console;

public class ConsoleUI
{
    public void Show() {
        string habit;
        string operation;
        string command;
        Dictionary<string, int> goalStore = new Dictionary<string, int> {
            {"Glasses of water", 0},
            {"Hours of sleep", 0},
            {"Number of steps", 0},
        };

        command = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What do you want to do?")
                .AddChoices(new[] {
                    "Input habit",
                    "View report",
                    "Exit program"
                }));

        while (command != "Exit program") {
            if (command == "Input habit"){

                do {
                    habit = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Choose habit")
                            .AddChoices(new[] {
                                "Glasses of water",
                                "Hours of sleep",
                                "Number of steps",
                                "Go back"
                            }));

                    if (habit == "Go back") {
                        break;
                    }

                    operation = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title($"Do you want to add or subtract from {habit}")
                            .AddChoices(new[] {
                                "Add",
                                "Subtract",
                                "Go back"
                            }));
                    
                    if (operation == "Add") {
                        goalStore[habit] += 1;
                    }

                    if (operation == "Subtract") {
                        if (goalStore[habit] > 0) {
                            goalStore[habit] -= 1;
                        }
                    }

                } while (operation == "Go back");


            } else if (command == "View report") {
                Table table = new Table();
                table.AddColumn("Habit");
                table.AddColumn("Done");

                foreach (KeyValuePair<string, int>item in goalStore) {
                    table.AddRow(item.Key, Convert.ToString(item.Value));
                }
                AnsiConsole.Write(table);
            }
            command = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .AddChoices(new[] {
                        "Input habit",
                        "View report",
                        "Exit program"
                    }));
        }

    }
}