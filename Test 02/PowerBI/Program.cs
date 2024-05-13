using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using ExcelDataReader;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        string filePath = @"files\stage_MultiStore.xlsx";
        string processedPath = @"processed\";

        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                });
                DataTable dt = result.Tables[0];
                foreach (DataColumn column in dt.Columns)
                {
                    column.ColumnName = column.ColumnName.Replace(" ", "");
                }
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MultiStoreDW;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM stage.MultiStore", connection);
                    deleteCommand.ExecuteNonQuery();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = "stage.MultiStore";
                        var columnMappings = new List<(string SourceColumn, string DestinationColumn)>
                        {
                            ("OrderID", "OrderID"),
                            ("OrderDate", "OrderDate"),
                            ("ShipDate", "ShipDate"),
                            ("ShipMode", "ShipMode"),
                            ("CustomerID", "CustomerID"),
                            ("CustomerName", "CustomerName"),
                            ("CustomerAge", "CustomerAge"),
                            ("CustomerBirthday", "CustomerBirthday"),
                            ("CustomerState", "CustomerState"),
                            ("Segment", "Segment"),
                            ("Country", "Country"),
                            ("City", "City"),
                            ("State", "State"),
                            ("RegionalManagerID", "RegionalManagerID"),
                            ("RegionalManager", "RegionalManager"),
                            ("PostalCode", "PostalCode"),
                            ("Region", "Region"),
                            ("ProductID", "ProductID"),
                            ("Category", "Category"),
                            ("Sub-Category", "SubCategory"),
                            ("ProductName", "ProductName"),
                            ("Sales", "Sales"),
                            ("Quantity", "Quantity"),
                            ("Discount", "Discount"),
                            ("Profit", "Profit")
                        };
                        foreach (var mapping in columnMappings)
                        {
                            bulkCopy.ColumnMappings.Add(mapping.SourceColumn, mapping.DestinationColumn);
                        }
                        try
                        {
                            bulkCopy.WriteToServer(dt);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao escrever para o servidor.");
                            Console.WriteLine(ex.Message);
                            throw;
                        }
                    }
                }
            }
        }
        try
        {
            string uniqueFilePath = GetUniqueFilePath(filePath, processedPath);
            File.Move(filePath, uniqueFilePath);
        }
        catch (IOException ex)
        {
            throw new IOException($"O arquivo {filePath} não pode ser acessado porque está sendo usado por outro processo.", ex);
        }

        Console.WriteLine("Processo concluído.");
    }

    public static string GetUniqueFilePath(string filePath, string destinationDirectory)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string fileExtension = Path.GetExtension(filePath);
        int count = 1;

        while (File.Exists(Path.Combine(destinationDirectory, fileName + fileExtension)))
        {
            fileName = Path.GetFileNameWithoutExtension(filePath) + "_" + count;
            count++;
        }

        return Path.Combine(destinationDirectory, fileName + fileExtension);
    }
}