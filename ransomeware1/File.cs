using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.File; // Namespace for File storage types
using System;

public static class File_Storage
{
    public static void iterate_files(CloudStorageAccount storageAccount)
    {

        // Create the file client.
        CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

        foreach (CloudFileShare share in fileClient.ListShares())
        {

            // Retrieve reference to a previously created container.
            CloudFileShare shr = fileClient.GetShareReference(share.Name);

            // Loop over items within the container and output the length and URI.
            /*
             like the, iterate containers, and encrypt them reversibly*/
            foreach (CloudFileDirectory item in shr.###(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);

                    Console.ReadKey(); //keep the console open (to see the output)

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;

                    Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;

                    Console.WriteLine("Directory: {0}", directory.Uri);
                }
            }
        }
    }
}