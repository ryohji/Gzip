using System.IO.Compression;

namespace Gzip
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.Stream ins;
            System.IO.Stream outs;
            if (args.Length != 0 && args[0] == "-d")
            { // decompress
                ins = new GZipStream(System.Console.OpenStandardInput(), CompressionMode.Decompress);
                outs = System.Console.OpenStandardOutput();
            }
            else
            { // compress
                ins = System.Console.OpenStandardInput();
                outs = new GZipStream(System.Console.OpenStandardOutput(), CompressionLevel.Optimal);
            }
            System.Span<byte> bytes = stackalloc byte[4096];
            while (true)
            {
                var nrRead = ins.Read(bytes);
                if (nrRead == 0)
                {
                    ins.Close();
                    outs.Close();
                    break;
                }
                outs.Write(bytes.Slice(0, nrRead));
            }
        }
    }
}
