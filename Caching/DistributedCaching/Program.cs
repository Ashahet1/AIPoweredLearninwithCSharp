using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace InDistrubutedCaching
{
    public class MyData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    class Program
    {
        private static IDistributedCache? _cache;

        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddDistributedSqlServerCache(options =>
                    {
                        options.ConnectionString = "Server=RISHAH1-LTW10;Database=master;Integrated Security=True;TrustServerCertificate=True;";// This is what we need to check
                        options.TableName = "DistributedCache";
                        options.SchemaName = "dbo";
                    });
                })
                .Build();

            _cache = host.Services.GetRequiredService<IDistributedCache>();

            Console.WriteLine($"Distributed Cache Example using SQL Server at {DateTime.Now}\n");

            // 1. Setting and Getting a String
            // Create Value: SetAsync
            // Read Value: GetAsync
            // Remove Value: RemoveAsync
            // Refresh Value: RefreshAsync
            string stringKey = "myStringItem";
            string stringValueToCache = "Hello from distributed cache!";
            var sw = Stopwatch.StartNew();
            await _cache.SetStringAsync(stringKey, stringValueToCache, new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(15)
            });
            sw.Stop();
            Console.WriteLine($"Set '{stringKey}': {stringValueToCache} at {DateTime.Now}");
            string retrievedStringValue = await _cache.GetStringAsync(stringKey);
            Console.WriteLine($"Get '{stringKey}': {retrievedStringValue} at {DateTime.Now}\n");

            // Create another string key to demonstrate the update or refresh
            //1.2
            string stringKey1 = "myStringItem1";
            string stringValueToCache1 = "Hello from distributed cache! 1";
            sw.Restart();
            await _cache.SetStringAsync(stringKey1, stringValueToCache1, new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(15)
            });
            sw.Stop();
            Console.WriteLine($"Set '{stringKey1}': {stringValueToCache1} at {DateTime.Now}");
            string retrievedStringValue1 = await _cache.GetStringAsync(stringKey1);
            Console.WriteLine($"Get '{stringKey1}': {retrievedStringValue1} at {DateTime.Now}\n");


            // 2. Setting and Getting a String as Byte Array
            string bytesKey = "myBytesItem";
            string bytesValueToCache = "This string is stored as bytes.";
            byte[] valueBytes = Encoding.UTF8.GetBytes(bytesValueToCache);
            sw.Restart();
            await _cache.SetAsync(bytesKey, valueBytes, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
            });
            sw.Stop();
            Console.WriteLine($"Set '{bytesKey}' as bytes: {bytesValueToCache} at {DateTime.Now}");
            byte[] retrievedValueBytes = await _cache.GetAsync(bytesKey);
            if (retrievedValueBytes != null)
            {
                string retrievedBytesAsString = Encoding.UTF8.GetString(retrievedValueBytes);
                Console.WriteLine($"Get '{bytesKey}' as bytes: {retrievedBytesAsString} at {DateTime.Now}\n");
            }

            // 3. Setting and Getting a Serialized Object
            string objectKey = "myObjectItem";
            MyData objectToCache = new MyData { Id = 1, Name = "Sample Data" };
            string serializedObject = JsonSerializer.Serialize(objectToCache);
            byte[] objectValueBytes = Encoding.UTF8.GetBytes(serializedObject);
            sw.Restart();
            await _cache.SetAsync(objectKey, objectValueBytes, new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(1)
            });
            sw.Stop();
            Console.WriteLine($"Set '{objectKey}' as object: Id={objectToCache.Id}, Name={objectToCache.Name} at {DateTime.Now}");
            byte[] retrievedObjectBytes = await _cache.GetAsync(objectKey);
            sw.Restart();
            if (retrievedObjectBytes != null)
            {
                string retrievedSerializedObject = Encoding.UTF8.GetString(retrievedObjectBytes);
                MyData retrievedObject = JsonSerializer.Deserialize<MyData>(retrievedSerializedObject);
                Console.WriteLine($"Get '{objectKey}' as object: Id={retrievedObject.Id}, Name={retrievedObject.Name} at {DateTime.Now}\n");
            }
            sw.Stop();
            // Let's try to get the items again to see if they are still in the cache
            Console.WriteLine("Trying to get items again after a short delay...\n");
            string retrievedStringValueAgain = await _cache.GetStringAsync(stringKey);
            Console.WriteLine($"Get '{stringKey}' again: {retrievedStringValueAgain} at {DateTime.Now}");
            byte[] retrievedValueBytesAgain = await _cache.GetAsync(bytesKey);
            sw.Restart();
            if (retrievedValueBytesAgain != null)
            {
                string retrievedBytesAsStringAgain = Encoding.UTF8.GetString(retrievedValueBytesAgain);
                Console.WriteLine($"Get '{bytesKey}' again as bytes: {retrievedBytesAsStringAgain} at {DateTime.Now}");
            }
            byte[] retrievedObjectBytesAgain = await _cache.GetAsync(objectKey);
            if (retrievedObjectBytesAgain != null)
            {
                string retrievedSerializedObjectAgain = Encoding.UTF8.GetString(retrievedObjectBytesAgain);
                MyData retrievedObjectAgain = JsonSerializer.Deserialize<MyData>(retrievedSerializedObjectAgain);
                Console.WriteLine($"Get '{objectKey}' again as object: Id={retrievedObjectAgain.Id}, Name={retrievedObjectAgain.Name} at {DateTime.Now}");
            }

            Console.ReadKey();
        }
    }
}