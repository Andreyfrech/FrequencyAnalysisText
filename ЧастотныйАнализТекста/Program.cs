using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ЧастотныйАнализТекста
{
    class Program
    {
       static string path;
        static void Main(string[] args)
        {
            new Program().ReadPath();
           new Program().ReadText(path);
        }

        public string ReadPath()
        {
            Console.WriteLine("Введите путь к файлу");
            path = Convert.ToString(Console.ReadLine());
            return path;
        }

        public static IEnumerable<string> SwimParts(string source, int length)
        {
            for (int i = length; i <= source.Length; i++)
                yield return source.Substring(i - length, length);
        }

        // static void ReadText()
        public void ReadText(string path)
        {
            string text = "";
            int time = 0;
            try
            {

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                         text = sr.ReadToEnd();
                    Console.WriteLine();
             
                    new Thread(() => Serch(text, time)).Start();      
                }
                    } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Serch(string text, int time)
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            var groups = SwimParts(text, 3).Where(str => str.All(ch => char.IsLetter(ch)))
                     .GroupBy(str => str);


            Console.WriteLine(string.Join
                (
                    ",",
                    groups.OrderByDescending(gr => gr.Count()).Take(10).Select(gr => $"\"{gr.Key}\"")
                ));
            startTime.Stop();
            var resultTime = startTime.Elapsed;
            time = resultTime.Milliseconds;
            Console.WriteLine();
            Console.WriteLine("Время выполнения программы: " + time + " мс");
        }
    }
}

