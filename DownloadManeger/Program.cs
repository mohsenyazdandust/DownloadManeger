using System;

namespace DownloadManeger
{
    internal class Program
    {
        static string[] queue = {
            "https://hiboo.ir/hub/sources/%D8%AA%D8%AD%D9%84%DB%8C%D9%84-%D9%88-%D8%B7%D8%B1%D8%A7%D8%AD%DB%8C-%D8%B3%DB%8C%D8%B3%D8%AA%D9%85-%D9%87%D8%A7-%D8%AF%DA%A9%D8%AA%D8%B1-%D8%B1%D8%B6%D8%A7%DB%8C%DB%8C/download/",
            "https://hiboo.ir/hub/sources/%D8%AA%D8%AC%D8%A7%D8%B1%D8%AA-%D8%A7%D9%84%DA%A9%D8%AA%D8%B1%D9%88%D9%86%DB%8C%DA%A9-%D8%AF%DA%A9%D8%AA%D8%B1-%D8%B1%D8%B6%D8%A7%DB%8C%DB%8C/download/",
            "https://hiboo.ir/hub/sources/%D8%AA%D8%AC%D8%A7%D8%B1%D8%AA-%D8%A7%D9%84%DA%A9%D8%AA%D8%B1%D9%88%D9%86%DB%8C%DA%A9-%D8%AF%DA%A9%D8%AA%D8%B1-%D8%B1%D8%B6%D8%A7%DB%8C%DB%8CYg/download/",
            "https://hiboo.ir/hub/sources/%D9%87%D9%88%D8%B4-%D9%85%D8%B5%D9%86%D9%88%D8%B9%DB%8C-%D8%AF%DA%A9%D8%AA%D8%B1-%D8%B5%D8%A7%D8%AF%D9%82%DB%8C8A/download/",
        };

        static void DownloadFile()
        {
            for (int i = 0; i < queue.Length; i++)
            {
                Task.Run(async () =>
                {
                    using var client = new HttpClient();
                    using var s = await client.GetStreamAsync(queue[i]);
                    using var fs = new FileStream($"file_{i + 1}.pdf", FileMode.OpenOrCreate);
                    await s.CopyToAsync(fs);

                    Console.WriteLine($"Downloaded! File {i + 1}");
                });
            }
        }

        static void StartDownload()
        {
                new Thread(DownloadFile).Start();
        }


        static void Main(string[] args)
        {
            StartDownload();
            Console.ReadKey();
        }
    }
}