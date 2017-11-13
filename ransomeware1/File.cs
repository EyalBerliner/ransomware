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
            CloudFileDirectory rootDir = share.GetRootDirectoryReference();
            recruisveSearch(rootDir);
        }
        Console.ReadKey();
    }

    private static void recruisveSearch(CloudFileDirectory dir)
    {
        foreach (var fileOrDir in dir.ListFilesAndDirectories())
        {
            if (fileOrDir.GetType() == typeof(CloudFile))
            {
                CloudFile file = fileOrDir as CloudFile;
                Console.WriteLine("Found file: " + file.Name);
            }
            if (fileOrDir.GetType() == typeof(CloudFileDirectory))
            {
                recruisveSearch((CloudFileDirectory)fileOrDir);
            }
        }
    }
}