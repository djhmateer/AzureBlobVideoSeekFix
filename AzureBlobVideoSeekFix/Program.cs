using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace AzureBlobVideoSeekFix
{
    class Program
    {
        static void Main()
        {
            // to fix seek issue
            //  https://blog.thoughtstuff.co.uk/2014/01/streaming-mp4-video-files-in-azure-storage-containers-blob-storage/
            var credentials = new StorageCredentials("davemtestvideostorage", "INSERT KEY FROM AZURE WEB STORAGE KEYS HERE");
            var account = new CloudStorageAccount(credentials, true);
            var client = account.CreateCloudBlobClient();
            var properties = client.GetServiceProperties();
            properties.DefaultServiceVersion = "2013-08-15";
            client.SetServiceProperties(properties);
            Console.WriteLine(properties.DefaultServiceVersion);
        }
    }
}
