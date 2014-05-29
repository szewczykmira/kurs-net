﻿using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        // Open a compressed file on disk.
        // ... Then decompress it with the method below.
        // ... Then write the length of each array.
        byte[] file = File.ReadAllBytes("plik.gz");
        byte[] decompressed = Decompress(file);
        Console.WriteLine(file.Length);
        Console.WriteLine(decompressed.Length);
    }

    static byte[] Decompress(byte[] gzip)
    {
        // Create a GZIP stream with decompression mode.
        // ... Then create a buffer and write into while reading from the GZIP stream.
        using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
        {
            const int size = 4096;
            byte[] buffer = new byte[size];
            using (MemoryStream memory = new MemoryStream())
            {
                int count = 0;
                do
                {
                    count = stream.Read(buffer, 0, size);
                    if (count > 0)
                    {
                        memory.Write(buffer, 0, count);
                    }
                }
                while (count > 0);
                return memory.ToArray();
            }
        }
    }
}