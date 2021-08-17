using System;
using System.IO;

namespace ЧастотныйАнализТекста
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadText();
        }

        static void ReadText()
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Convert.ToString(Console.ReadLine());
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] s1 = line.Split();
                        string ss;
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
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
