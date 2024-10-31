using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace DrinksInfo;

public class TableVisualizationEngine
{
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        Console.Clear();

        if (tableName == null)
            tableName = "";

        Console.WriteLine($"\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWriteLine();
        Console.WriteLine($"\n\n");
    }
}