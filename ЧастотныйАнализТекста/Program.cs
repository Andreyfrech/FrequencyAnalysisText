using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            try
            {

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {

                    //    string line;
                    //    string ss ="";
                   // while (sr.ReadToEnd() != null)
                    //    while ((line = sr.ReadLine()) != null)
                    {
                         text = sr.ReadToEnd();
                        //        Console.WriteLine(line);
                        //        string[] s1 = line.Split();

                        //        for (int j = 0; j < s1.Length; j++)
                        //        {
                        //            line = s1[j];
                        //            for (int i = 0; i < line.Length - 2; i++)
                        //            {
                        //                ss = line.Substring(i, 3);
                        //                Console.WriteLine(ss);

                        //            }
                        //        }
                        //    }
                    }
                        var startTime = System.Diagnostics.Stopwatch.StartNew();

                        var groups = SwimParts(text, 3).Where(str => str.All(ch => char.IsLetter(ch)))
                       .GroupBy(str => str);


                        Console.WriteLine(string.Join
                            (
                                Environment.NewLine,
                                groups.OrderByDescending(gr => gr.Count()).Take(10).Select(gr => $"\"{gr.Key}\" встретилось {gr.Count()} раз")
                            ));

                        startTime.Stop();
                        var resultTime = startTime.Elapsed;
                        }
                    } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

