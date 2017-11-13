using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.File; // Namespace for File storage types
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using System;

public static class Table_Storage
{
    public static void iterate_table(CloudStorageAccount storageAccount)
    {

        // Create the table client.
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

        foreach (CloudTable table in tableClient.ListTables())
        {

            // Retrieve reference to a previously created tables.
            CloudTable tbl = tableClient.GetTableReference(table.Name);
            Console.WriteLine(tbl);
            }
        }
    }