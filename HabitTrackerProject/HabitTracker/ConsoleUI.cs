namespace HabitTracker;
using System;
using Spectre.Console;

public class ConsoleUI
{
    ConsoleUIViews consoleUIViews;
    public ConsoleUI () {
        consoleUIViews = new ConsoleUIViews();
    }

    public void Show() {
        string command;
        
        // Main menu
        command = consoleUIViews.ShowMainMenu();

        while (command != "Exit program") {

            if (command == "Add habit") {

                consoleUIViews.AddHabitView();

            } else if (command == "Update habit goals") {

                consoleUIViews.UpdateHabitGoalsView();

            } else if (command == "Input habit"){

                consoleUIViews.InputHabitView();

            } else if (command == "Delete habit") {

                consoleUIViews.DeleteHabitView();

            } else if (command == "View report") {
                
                consoleUIViews.ViewReportView();
                
            } else if (command == "Delete all habits") {

                consoleUIViews.DeleteAllHabitsView();
                
            } else if (command == "Reset all inputs") {
                
                consoleUIViews.ResetAllInputsView();

            }
            
            command = consoleUIViews.ShowMainMenu();
        }

    }
}