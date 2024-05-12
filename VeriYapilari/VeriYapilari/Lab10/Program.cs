using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] atisDegerleri = new int[] { 11, 21, 27, 33, 36 };

            HashSet<int> gezilenDurumlar = new HashSet<int>();

            Queue<Tuple<int, List<int>>> kuyruk = new Queue<Tuple<int, List<int>>>();
            kuyruk.Enqueue(new Tuple<int, List<int>>(0, new List<int>()));

            while (kuyruk.Count > 0)
            {
                var current = kuyruk.Dequeue();
                int currentScore = current.Item1;
                List<int> atislar = current.Item2;

                foreach (var atis in atisDegerleri)
                {
                    int yeniSkor = currentScore + atis;
                    List<int> yeniAtislar = new List<int>(atislar);
                    yeniAtislar.Add(atis);

                    if (yeniSkor >= 100)
                    {
                        Console.WriteLine($"Atışlar: {string.Join(", ", yeniAtislar)} - Toplam Skor: {yeniSkor} - Oyunu kaybettiniz!");
                        continue;
                    }

                    if (yeniSkor == 99)
                    {
                        Console.WriteLine($"Atışlar: {string.Join(", ", yeniAtislar)} - Toplam Skor: {yeniSkor} - Oyunu kazandınız!");
                        break;
                    }

                    if (!gezilenDurumlar.Contains(yeniSkor))
                    {
                        gezilenDurumlar.Add(yeniSkor);
                        kuyruk.Enqueue(new Tuple<int, List<int>>(yeniSkor, yeniAtislar));
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
