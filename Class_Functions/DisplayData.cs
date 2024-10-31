using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksInfo.Class_Objects;
using Spectre.Console;

namespace DrinksInfo;

public class DisplayData
{
    public void ShowTable<T>(List<T> items, string title, Func<T, string> getID, Func<T, string> getName)
    {
        var table = new Table();
        bool isAlternateRow = false;
        table.Title(title);
        table.BorderColor(Color.DarkSlateGray1);
        table.Border(TableBorder.Rounded);
        table.AddColumn(new TableColumn("[cyan1]ID[/]").LeftAligned());
        table.AddColumn(new TableColumn("[green1]Category[/]").RightAligned());

        foreach (T item in items)
        {
            var color = isAlternateRow ? "grey" : "blue";
            table.AddRow(
                $"[{color}]{getID(item)}[/]",
                $"[{color}]{getName(item)}[/]"
            );
            isAlternateRow = !isAlternateRow;
        }
        Console.Clear();
        AnsiConsole.Write(table);
    }

    public void NothingFound(string item)
    {
        Console.Clear();
        Console.WriteLine($"No {item} found!");
        Thread.Sleep(2000);
    }

    public void ShowDrinkDetails(Drink drinkInfo)
    {
        var table = new Table();
        bool isAlternateRow = false;
        table.Title($"{drinkInfo.StrDrink} Details");
        table.BorderColor(Color.DarkSlateGray1);
        table.Border(TableBorder.Rounded);
        table.AddColumn(new TableColumn("[cyan1]Name[/]").LeftAligned());
        table.AddColumn(new TableColumn("[green1]Glass[/]").RightAligned());
        table.AddColumn(new TableColumn("[blue1]Ingredients[/]").RightAligned());
        table.AddColumn(new TableColumn("[yellow1]Instructions[/]").RightAligned());
        // table.AddColumn(new TableColumn("[red1]% Correct[/]").LeftAligned());

        // foreach (List<Drink> drink in drinkInfo)
        // {
        // string grade = (record.Score / (float)record.Questions).ToString("P1");
        var color = isAlternateRow ? "grey" : "blue";
        table.AddRow(
        // $"[{color}]{record.Date.ToShortDateString()}[/]",
        $"[{color}]{drinkInfo.StrDrink}[/]",
        $"[{color}]{drinkInfo.Glass}[/]",
        $"[{color}]{drinkInfo.Ingredient}[/]",
        $"[{color}]{drinkInfo.Instructions}[/]"
        );
        isAlternateRow = !isAlternateRow;

        Console.Clear();
        AnsiConsole.Write(table);
    }

}
