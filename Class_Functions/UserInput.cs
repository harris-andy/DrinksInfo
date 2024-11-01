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

    public void WaitToContinue()
    {
        Console.WriteLine($"Press enter to continue...");
        Console.Read();
    }
}

