using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksInfo.Class_Objects;
using Spectre.Console;

namespace DrinksInfo
{
    public class DisplayData
    {
        public static void ShowCategories(List<Category> categories)
        {
            var table = new Table();
            bool isAlternateRow = false;
            table.Title("Drink Categories");
            table.BorderColor(Color.DarkSlateGray1);
            table.Border(TableBorder.Rounded);
            table.AddColumn(new TableColumn("[cyan1]ID[/]").LeftAligned());
            table.AddColumn(new TableColumn("[green1]Category[/]").RightAligned());

            foreach (Category category in categories)
            {
                var color = isAlternateRow ? "grey" : "blue";
                table.AddRow(
                    $"[{color}]{category.ID}[/]",
                    $"[{color}]{category.StrCategory}[/]"
                );
                isAlternateRow = !isAlternateRow;
            }
            Console.Clear();
            AnsiConsole.Write(table);
        }

        public static void ShowDrinks(List<Drink> drinks)
        {
            var table = new Table();
            bool isAlternateRow = false;
            table.Title("Drinks");
            table.BorderColor(Color.DarkSlateGray1);
            table.Border(TableBorder.Rounded);
            table.AddColumn(new TableColumn("[cyan1]ID[/]").LeftAligned());
            table.AddColumn(new TableColumn("[green1]Drink[/]").Centered());

            foreach (Drink drink in drinks)
            {
                var color = isAlternateRow ? "grey" : "blue";
                table.AddRow(
                    $"[{color}]{drink.ID}[/]",
                    $"[{color}]{drink.StrDrink}[/]"
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

        //         public static void ShowCategories(List<Category> categories)
        // {
        //     var table = new Table();
        //     bool isAlternateRow = false;
        //     table.Title("Drink Categories");
        //     table.BorderColor(Color.DarkSlateGray1);
        //     table.Border(TableBorder.Rounded);
        //     table.AddColumn(new TableColumn("[cyan1]ID[/]").LeftAligned());
        //     table.AddColumn(new TableColumn("[green1]Category[/]").RightAligned());
        //     // table.AddColumn(new TableColumn("[blue1]Score[/]").RightAligned());
        //     // table.AddColumn(new TableColumn("[yellow1]Questions[/]").RightAligned());
        //     // table.AddColumn(new TableColumn("[red1]% Correct[/]").LeftAligned());

        //     foreach (Category category in categories)
        //     {
        //         // string grade = (record.Score / (float)record.Questions).ToString("P1");
        //         var color = isAlternateRow ? "grey" : "blue";
        //         table.AddRow(
        //             // $"[{color}]{record.Date.ToShortDateString()}[/]",
        //             $"[{color}]{category.ID}[/]",
        //             $"[{color}]{category.StrCategory}[/]"
        //         // $"[{color}]{record.Questions}[/]",
        //         // $"[{color}]{grade}[/]"
        //         );
        //         isAlternateRow = !isAlternateRow;
        //     }
        //     Console.Clear();
        //     AnsiConsole.Write(table);
        // }

    }
}
