using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCacheExample
{
    class Program
    {
        private static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());


        //Simulate a computationally expensive operation
        static string GetDataFromSource(string key)
        {
            Console.WriteLine($"Fetching data for {key}...");
            //Simulate some work
            Thread.Sleep(2000);
            return $"Data for {key} at {System.DateTime.Now}";
        }

        static string GetDataWithCaching(string key)
        {
            // Try to get the data from the cache
            if (_cache.TryGetValue(key, out string? cachedValue))
            {
                Console.WriteLine($"Returning cached data for key: {key}.");
                return cachedValue;
            }
            else
            {
                // If the key is not in the cache, fetch it from the source
                string data = GetDataFromSource(key);

                // Set cache options (optional, but good practice)
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5)); // Keep in cache for 5 seconds if accessed

                // Save the data in the cache
                _cache.Set(key, data, cacheEntryOptions);

                return data;
            }
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine($"In-Memory Cache Example at this time {System.DateTime.Now}\n");

            //// Simple cache test
            //_cache.Set("testKey", "testValue", TimeSpan.FromSeconds(10));
            //if (_cache.TryGetValue("testKey", out string? testValue))
            //{
            //    Console.WriteLine($"Simple cache test: Retrieved value: {testValue}");
            //}
            //else
            //{
            //    Console.WriteLine("Simple cache test: Could not retrieve value.");
            //}
            //Console.WriteLine(); // Add an empty line for separation

            Console.WriteLine("First request for 'item1':");
            string data1 = GetDataWithCaching("item1");
            Console.WriteLine($"Result: {data1}\n");

            Console.WriteLine("Second request for 'item1' (should be from cache):");
            string data2 = GetDataWithCaching("item1");
            Console.WriteLine($"Result: {data2}\n");

            Console.WriteLine("Waiting for 6 seconds to let the cache expire...");
            await Task.Delay(6000);

            Console.WriteLine("\nThird request for 'item1' (should fetch from source again):");
            string data3 = GetDataWithCaching("item1");
            Console.WriteLine($"Result: {data3}\n");

            // Let's try another item
            Console.WriteLine("\nFirst request for 'item2':");
            string data4 = GetDataWithCaching("item2");
            Console.WriteLine($"Result: {data4}\n");

            Console.WriteLine("Second request for 'item2' (should be from cache):");
            string data5 = GetDataWithCaching("item2");
            Console.WriteLine($"Result: {data5}\n");
        }

    }
}
