## Distributed Caching

**What is Distributed Caching?**

Unlike in-memory caching where the cache is local to a single instance of your application, a distributed cache is shared across multiple instances of your application, and often even across multiple servers.

Think of it as having a separate, shared storage space that all your application instances can access for caching data.

In some scenarios, a distributed cache is required—such is the case with multiple app servers. A distributed cache supports higher scale-out than the in-memory caching approach. Using a distributed cache offloads the cache memory to an external process, but does require extra network I/O and introduces a bit more latency (even if nominal).

In some scenarios, a distributed cache is required—such is the case with multiple app servers. A distributed cache supports higher scale-out than the in-memory caching approach. Using a distributed cache offloads the cache memory to an external process, but does require extra network I/O and introduces a bit more latency (even if nominal).

The distributed caching abstractions are part of the Microsoft.Extensions.Caching.Memory NuGet package, and there is even an AddDistributedMemoryCache extension method.

**Distributed caching API**
The distributed caching APIs are a bit more primitive than their in-memory caching API counterparts. The key-value pairs are a bit more basic. In-memory caching keys are based on an object, whereas the distributed keys are a string. With in-memory caching, the value can be any strongly-typed generic, whereas values in distributed caching are persisted as byte[]. That's not to say that various implementations don't expose strongly-typed generic values but that would be an implementation detail

**Why use Distributed Caching?**

Distributed caching becomes particularly important in scenarios like:

* **Web Applications with Multiple Servers:** If your web application is running on multiple servers (a common setup for scalability and reliability), each server would have its own in-memory cache. This can lead to inconsistencies if one server's cache has a piece of data while another doesn't. A distributed cache ensures all servers see the same cached data.
* **Session Management:** In web applications, you might want to store user session data in a cache that persists even if a particular server goes down or the user's request is routed to a different server. Distributed caching is often used for this.
* **Scalability:** As your application grows and you add more servers, a distributed cache can scale with you, providing a consistent caching layer.

**Common Implementations in .NET:**

.NET provides an `IDistributedCache` interface that abstracts away the underlying implementation of the distributed cache. Some popular implementations include:

* **Redis:** An open-source, in-memory data structure store often used as a distributed cache. It's very fast and offers features like persistence and various data structures.
* **Memcached:** Another popular, high-performance, distributed memory object caching system.
* **SQL Server Distributed Cache:** You can also use a SQL Server database to store cached data for distributed caching scenarios, although it's generally not as fast as in-memory stores like Redis or Memcached.

### Which Type Takes Longer?

Based on these factors, in our example:

* **Simple Strings:** These are generally the fastest to cache as they require minimal processing (just encoding to bytes).
* **Byte Arrays:** If you're already working with data as a byte array (e.g., from a file or another source), you can cache it directly with minimal overhead.
* **Objects:** These are likely to take the longest to cache (among the three we tested) because of the serialization step. The more complex the object, the longer this process will take.

### Downfalls to Consider:

* **Choosing the Right Serialization Format:** The choice of serialization format (e.g., JSON, binary) can impact performance and size. JSON is human-readable but can be less efficient in terms of size and speed compared to binary serialization.
* **Cache Invalidation:** Regardless of the data type, one of the biggest challenges with caching is ensuring that you're not serving stale data when the underlying source data changes. You'll need to think about strategies for invalidating or updating cached data.
* **Complexity of Cached Objects:** Caching very large and deeply nested object graphs can sometimes lead to performance issues during serialization and deserialization. It's often better to cache smaller, more focused pieces of data.

  ![image](https://github.com/user-attachments/assets/de264ca4-e644-4758-833c-fca2f18090d3)

