using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portable
{
    public class myclass {

        public List<string> urls = new List<string>();

        public myclass()
        {
        }

        public void createContainer()
        {
            //BlobContinuationToken continuationToken = null;

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=asharry;AccountKey=xmdgq8iMMnyz87//VZIBWYu832Dy7HV5lZIWU8OB+sM1jln3r5dIqOhY+Xtjalk/Jq9TG0yGcORcoOas1LV5rw==");

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("telugu-comedyandpunch");

            // Create the container if it doesn't already exist.
            //await container.CreateIfNotExistsAsync();

            container.ListBlobsSegmentedAsync(new BlobContinuationToken()).Wait();
            BlobResultSegment blobResultSegment = container.ListBlobsSegmentedAsync(new BlobContinuationToken()).Result;
            do
            {
                // process blobs - blobResultSegment.Results
                //Console.WriteLine(blobResultSegment.Results.Count());
                foreach (var blobItem in blobResultSegment.Results)
                {
                    urls.Add(blobItem.Uri.ToString());

                    // Get the continuation token, if there are additional segments of results.


                }
               // container.ListBlobsSegmentedAsync(blobResultSegment.ContinuationToken).Wait();
               // blobResultSegment = container.ListBlobsSegmentedAsync(new BlobContinuationToken()).Result;

            } while (blobResultSegment.ContinuationToken != null);

        }


    }
}
