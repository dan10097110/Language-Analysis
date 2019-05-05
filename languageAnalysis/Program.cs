using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace languageAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string s = Console.ReadLine();
                Console.WriteLine("AverageWordLength: " + AverageWordLength(s));
                Console.WriteLine("AverageSentenceLength: " + AverageSentenceLength(s));
                var v = CharShare(s);
                foreach (var w in v)
                    Console.WriteLine(w.c + ":\t" + w.share * 100 + "%");
                var y = WordShare(s);
                foreach (var w in y)
                    Console.WriteLine(w.word + ":\t" + w.share * 100 + "%");
            }
            Console.ReadKey();
        }

        static double AverageWordLength(string s)
        {
            var v = s.Split(' ');
            double d = 0;
            for (int i = 0; i < v.Length; i++)
                d += v[i].Length;
            return d / v.Length;
        }

        static double AverageSentenceLength(string s)
        {
            var v = s.Split('.');
            double d = 0;
            for (int i = 0; i < v.Length; i++)
                d += v[i].Length;
            return d / v.Length;
        }

        static (char c, double share)[] CharShare(string s)
        {
            var c = s.ToCharArray();
            var d = new List<char>();
            var e = new List<int>();
            for(int i = 0; i < c.Length; i++)
            {
                int j = d.IndexOf(c[i]);
                if(j == -1)
                {
                    d.Add(c[i]);
                    e.Add(1);
                }
                else
                    e[j]++;
            }
            var f = new List<(char c, double shar)>();
            for (int i = 0; i < d.Count; i++)
                f.Add((d[i], e[i] / (double)c.Length));
            return f.OrderByDescending(g => g.Item2).ToArray();
        }

        static (string word, double share)[] WordShare(string s)
        {
            var c = s.Split(' ');
            var d = new List<string>();
            var e = new List<int>();
            for (int i = 0; i < c.Length; i++)
            {
                int j = d.IndexOf(c[i]);
                if (j == -1)
                {
                    d.Add(c[i]);
                    e.Add(1);
                }
                else
                    e[j]++;
            }
            var f = new List<(string c, double shar)>();
            for (int i = 0; i < d.Count; i++)
                f.Add((d[i], e[i] / (double)c.Length));
            return f.OrderByDescending(g => g.Item2).ToArray();
        }
    }
}
