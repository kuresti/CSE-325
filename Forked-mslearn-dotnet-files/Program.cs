// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var summaryDir = Path.Combine(currentDirectory, "summaryDir");
Directory.CreateDirectory(summaryDir);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);
File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

var salesSummaryGenerated = SalesSummaryReport(salesTotal, salesFiles);
File.AppendAllText(Path.Combine(summaryDir, "summary.txt"), $"{salesSummaryGenerated}");

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        // The file name will contain the full path, so only check the end of it
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }
    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents of the file
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

string SalesSummaryReport(double salesTotal, IEnumerable<string> salesFiles)
{
    var summaryReportBuilder = new StringBuilder();
    summaryReportBuilder.AppendLine("Sales Summary Report");
    summaryReportBuilder.AppendLine("______________________");
    summaryReportBuilder.AppendLine($"Total Sales: {salesTotal:C}");
    summaryReportBuilder.AppendLine();
    summaryReportBuilder.AppendLine("Details:");

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
        summaryReportBuilder.AppendLine($"{Path.GetFileName(file)}: {data?.Total:C}");
    }

    return summaryReportBuilder.ToString();
}
record SalesData(Double Total);

