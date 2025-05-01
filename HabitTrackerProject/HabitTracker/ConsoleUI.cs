namespace HabitTracker;
using System;
using Spectre.Console;

public class ConsoleUI
{
    // List<Tracker> Trackers;
    // public ConsoleUI () {
    //     Trackers = new List<Tracker>();
    // }

    public void Show() {

        // // Get habits from habits.txt file
        // string[] contentFromFile = File.ReadAllLines("habits.txt");
        // foreach(string line in contentFromFile) {
        //     string[] splitted = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
        //     string name = splitted[0];
        //     int goal = int.Parse(splitted[1]);
        //     int done = int.Parse(splitted[2]);

        //     Habit newHabit = new Habit(name);
        //     newHabit.updateGoal(goal);
        //     Tracker newTracker = new Tracker(newHabit);
        //     Trackers.Add(newTracker);
        // }


        // Tracker tracker;
        // string operation;
        // string command;
        
        // // Main menu
        // command = AnsiConsole.Prompt(
        //     new SelectionPrompt<string>()
        //         .Title("What do you want to do?")
        //         .AddChoices(new[] {
        //             "Set habit goals",
        //             "Input habit",
        //             "Exit program"
        //         }));

        // while (command != "Exit program") {
        //     if (command == "Set habit goals") {
        //         // foreach (Tracker trackerItem in Trackers) {
                
        //         //     Tracker newTracker = trackerItem;
        //         //     newTracker.Habit.updateGoal(goal);

        //         //     // update habits.txt
        //         //     int trackerIndex = Trackers.FindIndex(t => t == newTracker);
        //         //     Trackers[trackerIndex] = newTracker;
        //         //     List<string> trackerData = new List<string>();
        //         //     foreach (Tracker item in Trackers) {
        //         //         string trackerLine = item + "," + item.Habit.getGoal() + "," + item.getDone();
        //         //         trackerData.Add(trackerLine);
        //         //     }
        //         //     File.WriteAllLines("habits.txt", trackerData);
        //         // }

        //         Console.WriteLine("Set goals for: ");
        //         int goal = AnsiConsole.Prompt(new TextPrompt<int>(trackerItem.Habit.Name));
                
        //     }
        //     if (command == "Input habit"){

        //         do {
        //             tracker = AnsiConsole.Prompt(
        //                 new SelectionPrompt<Tracker>()
        //                     .Title("Choose habit")
        //                     .AddChoices(Trackers));

        //             operation = AnsiConsole.Prompt(
        //                 new SelectionPrompt<string>()
        //                     .Title($"Do you want to add or subtract from {tracker}")
        //                     .AddChoices(new[] {
        //                         "Add",
        //                         "Subtract",
        //                         "Go back"
        //                     }));
                    
        //             if (operation == "Add") {
        //                 tracker.addHabitDone();

        //                 // update habits.txt
        //                 int trackerIndex = Trackers.FindIndex(t => t == tracker);
        //                 Trackers[trackerIndex] = tracker;
        //                 List<string> trackerData = new List<string>();
        //                 foreach (Tracker item in Trackers) {
        //                     string trackerLine = item + "," + item.Habit.getGoal() + "," + item.getDone();
        //                     trackerData.Add(trackerLine);
        //                 }
        //                 File.WriteAllLines("habits.txt", trackerData);
        //             }

        //             if (operation == "Subtract") {
        //                 tracker.subtractHabitDone();

        //                 // update habits.txt
        //                 int trackerIndex = Trackers.FindIndex(t => t == tracker);
        //                 Trackers[trackerIndex] = tracker;
        //                 List<string> trackerData = new List<string>();
        //                 foreach (Tracker item in Trackers) {
        //                     string trackerLine = item + "," + item.Habit.getGoal() + "," + item.getDone();
        //                     trackerData.Add(trackerLine);
        //                 }
        //                 File.WriteAllLines("habits.txt", trackerData);
        //             }

        //             AnsiConsole.WriteLine($"{tracker} successfully updated. {tracker.getDone()} {tracker} completed.");

        //         } while (operation == "Go back");


        //     } else if (command == "View report") {
        //         Table table = new Table();
        //         table.AddColumn("Habit");
        //         table.AddColumn("Done");

        //         // foreach (KeyValuePair<string, int>item in goalStore) {
        //         //     table.AddRow(item.Key, Convert.ToString(item.Value));
        //         // }
        //         AnsiConsole.Write(table);
        //     }
        //     command = AnsiConsole.Prompt(
        //         new SelectionPrompt<string>()
        //             .Title("What do you want to do?")
        //             .AddChoices(new[] {
        //                 "Input habit",
        //                 "View report",
        //                 "Exit program"
        //             }));
        // }

    }
}