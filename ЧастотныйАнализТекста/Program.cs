using System;
using System.IO;
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

        // static void ReadText()
        public void ReadText(string path)
        {
            
            try
            {
              
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    var startTime = System.Diagnostics.Stopwatch.StartNew();
                    string line;
                    string ss ="";
                    while ((line = sr.ReadLine()) != null)
                    {
                       
                        Console.WriteLine(line);
                        string[] s1 = line.Split();
                        
                        for (int j = 0; j < s1.Length; j++)
                        {
                            line = s1[j];
                            for (int i = 0; i < line.Length - 2; i++)
                            {
                                ss = line.Substring(i, 3);
                                Console.WriteLine(ss);
                                
                            }
                        }
                    }
                   
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

