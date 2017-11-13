using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.File; // Namespace for File storage types
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using System;

public static class Blob_Storage
{
    public static void iterate_blobs(CloudStorageAccount storageAccount)
    {

        // Create the blob client.
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

        foreach (CloudBlobContainer containter in blobClient.ListContainers())
        {

            // Retrieve reference to a previously created container.
            CloudBlobContainer cont = blobClient.GetContainerReference(containter.Name);

            // Loop over items within the container and output the length and URI.
            /*
             like the, iterate containers, and encrypt them reversibly*/
            foreach (IListBlobItem item in cont.ListBlobs(null, false))
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