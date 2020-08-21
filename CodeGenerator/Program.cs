using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CodeGenerator
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Starting indexes for arrays
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            int i5 = 0;

            string output = "";
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            

            // Letter and number combinations
            int[] n1 = new int[numbers.Length];
            int[] n2 = new int[numbers.Length];
            int[] n3 = new int[numbers.Length];

            string[] s4 = new string[letters.Length];
            string[] s5 = new string[letters.Length];
            List<Code> results = new List<Code>();

            Array.Copy(numbers, n1, numbers.Length);
            Array.Copy(numbers, n2, numbers.Length);
            Array.Copy(numbers, n3, numbers.Length);

            Array.Copy(letters, s4, letters.Length);
            Array.Copy(letters, s5, letters.Length);

            int upperLimit = n1.Length * n2.Length * n3.Length * s4.Length * s5.Length;
            for (int i = 0; i < upperLimit; i++) 
            {
                output = s5[i5] + s4[i4] + n3[i3].ToString() + n2[i2].ToString() + n1[i1].ToString();
                results.Add(new Code { code = output });
                Console.WriteLine(i);
                i1 += 1;

                if (i1 > numbers.Length - 1) 
                {
                    i1 = 0;
                    i2 += 1;
                }

                if (i2 > numbers.Length - 1) 
                {
                    i1 = 0;
                    i2 = 0;
                    i3 += 1;
                }

                if (i3 > numbers.Length - 1) 
                {
                    i1 = 0;
                    i2 = 0;
                    i3 = 0;
                    i4 += 1;
                }

                if (i4 > letters.Length - 1) 
                {
                    i1 = 0;
                    i2 = 0;
                    i3 = 0;
                    i4 = 0;
                    i5 += 1;
                }
            }

            results.Shuffle();
            WriteCSVFile(results);
        }

      
        private static void WriteCSVFile(List<Code> dataSource)
        {

            try
            {
                //filehelper object
                FileHelperEngine engine = new FileHelperEngine(typeof(Code));
                //csv object
                List<Code> csv = new List<Code>();
                //convert any datasource to csv based object
                foreach (var item in dataSource)
                {

                    Code temp = new Code();
                    temp.code = item.code;
                    csv.Add(temp);

                }
                //give file a name and header text
                string filename = "Codes.csv";
                engine.HeaderText = "Codes";

                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

                //To get the location the assembly normally resides on disk or the install directory
                //string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

                //once you have the path you get the directory with:
                var directory = System.IO.Path.GetDirectoryName(path);
                string file = System.IO.Path.Combine(directory, filename);
                //save file locally
                engine.WriteFile(file, csv);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
                int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
