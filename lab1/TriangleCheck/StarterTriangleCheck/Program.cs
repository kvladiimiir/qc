using System;
using System.Diagnostics;
using System.IO;

namespace StarterTriangleCheck
{
    class Program
    {
        private static bool FileCompare(string outputPath, string resultPath)
        {
            string[] outputStringData = File.ReadAllLines(outputPath, System.Text.Encoding.Default);
            string[] resultStringData = File.ReadAllLines(resultPath, System.Text.Encoding.Default);
            if (outputStringData.Length != resultStringData.Length)
            {
                return false;
            }

            for (int i = 0; i < outputStringData.Length; i++)
            {
                if (outputStringData[i] != resultStringData[i])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string readPath = @"E:\QualityControl\lab1\TriangleCheck\StarterTriangleCheck\input.txt";
            //System.path. - абсолютный путь посмотреть
            string writePath = @"E:\QualityControl\lab1\TriangleCheck\StarterTriangleCheck\output.txt";
            string resultPath = @"E:\QualityControl\lab1\TriangleCheck\StarterTriangleCheck\result.txt";
            string[] inputStringData = File.ReadAllLines(readPath, System.Text.Encoding.Default);
            foreach (string str in inputStringData)
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "E:\\QualityControl\\lab1\\TriangleCheck\\bin\\Debug\\TriangleCheck.exe",
                        Arguments = str,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string line = process.StandardOutput.ReadLine();
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(line);
                }
            }

            if (!FileCompare(writePath, resultPath))
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine("success");
            }
        }
    }
}
