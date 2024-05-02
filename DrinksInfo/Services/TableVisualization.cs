using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace DrinksInfo.Services;

public class TableVisualization
{
    public void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T :
    class
    {
        Console.Clear();

        tableName ??= "";

        Utilities.PrintNewLines(2);

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWriteLine();

        Utilities.PrintNewLines(2);
    }
}
