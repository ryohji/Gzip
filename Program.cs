using System.Text;
using Microsoft.AspNetCore.ResponseCompression;

namespace Gzip
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new GzipCompressionProvider(new GzipCompressionProviderOptions());
            var stream = provider.CreateStream(System.Console.OpenStandardOutput());
            stream.Write(Encoding.UTF8.GetBytes("hello world."));
            stream.Close();
        }
    }
}
