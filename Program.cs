using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace csharp8_net4x
{
    public class Program
    {
        public string A { get; set; } = "";
        public string? B { get; set; }

        interface IBlah
        {
            // // This gives us a compiler error when targetting an unsupported TFM
            // public string Blah()
            // {
            //     return "This won't work";
            // }
        }
        
        static async Task Main(string[] args)
        {
            using var ms = new MemoryStream();

            var myValue = "Hello world!"[6..^1];
            
            async IAsyncEnumerable<int> InfiniteStream()
            {
                int i = 0;
                while (true)
                {
                    yield return i++;
                    await Task.Delay(1_000); 
                }
            }

            await InfiniteStream().Take(3).ForEachAsync(Console.WriteLine);

            Console.WriteLine(myValue);
        }
    }
}
