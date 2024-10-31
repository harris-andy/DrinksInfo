using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace DrinksInfo;

public class UserInput
{
    public int GetMenuChoice(int start, int end, string text)
    {
        int menuChoice = AnsiConsole.Prompt(
        new TextPrompt<int>(text)
        .Validate((n) =>
        {
            if (start <= n && n <= end)
                return ValidationResult.Success();
            else
                return ValidationResult.Error($"[red]Pick a valid option[/]");
        }));
        return menuChoice;
    }

    public bool ConfirmDelete()
    {
        bool confirmation = false;
        string prompt = "Are you SURE you want to delete this stack? y/n";
        confirmation = AnsiConsole.Prompt(
        new TextPrompt<bool>(prompt)
            .AddChoice(true)
            .AddChoice(false)
            .WithConverter(choice => choice ? "y" : "n"));

        return confirmation;
    }


    public string GetText(string message)
    {
        string flashCardText = AnsiConsole.Prompt(
            new TextPrompt<string>(message)
        );
        return flashCardText;
    }

    public string ChooseNewOrOldStack()
    {
        string answer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Add to an [green]existing stack[/] or [yellow]create a new stack[/]?")
                .PageSize(3)
                .AddChoices(new[] {
                    "Choose existing", "Create new", "Main Menu"
                }));
        return answer.ToLower();
    }

    public int GetQuestionPoints()
    {
        string answer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Was your answer [green]correct[/] or [red]wrong[/]?")
                .PageSize(3)
                .AddChoices(new[] {
                    "Correct", "Wrong"
                }));
        if (answer == "Correct")
            return 1;
        else
            return 0;
    }


    // var verifiedStackID = AnsiConsole.Prompt(
    // new TextPrompt<int>($"Enter stack ID to continue:")
    // .Validate((n) =>
    // {
    //     if (validIDs.Contains(n))
    //         return ValidationResult.Success();
    //     else
    //         return ValidationResult.Error($"[red]Must be a valid ID[/]");
    // }));
    // return verifiedStackID;


    public void WaitToContinue()
    {
        Console.WriteLine($"Press enter to continue...");
        Console.Read();
    }

    public int ChooseYear(List<string> choices)
    {
        string answer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose [green]year[/] for summary:")
                .PageSize(3)
                .AddChoices(choices));
        return int.Parse(answer);
    }
}

