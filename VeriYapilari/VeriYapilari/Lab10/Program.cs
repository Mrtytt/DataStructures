using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7
{
    public class Program
    {
        public class Eleman
        {
            public String atis;
            public int toplam;
            public Eleman ileri;
            public Eleman(String atis, int toplam)
            {
                this.atis = atis;
                this.toplam = toplam;
                ileri = null;
            }
        }
        public class Kuyruk
        {
            public Eleman bas;
            public Eleman son;

            public Kuyruk()
            {
                bas = null;
                son = null;
            }
            public bool kuyrukBos()
            {
                if (bas == null)
                    return true;
                else
                    return false;
            }
            public void kuyrugaEkle(Eleman eleman)
            {
                if (!kuyrukBos())
                    son.ileri = eleman;
                else
                    bas = eleman;
                son = eleman;
            }
            public Eleman kuyrukSil()
            {
                Eleman sonuc;
                sonuc = bas;
                if (!kuyrukBos())
                {
                    bas = bas.ileri;
                    if (bas == null)
                        son = null;
                }
                return sonuc;
            }
            public String hedefTahtasi(int[] tahta)
            {
                int i, j;

                String newAtis;
                Eleman newEleman;
                Kuyruk newKuyruk;

                newEleman = new Eleman("", 0);
                newKuyruk = new Kuyruk();

                newKuyruk.kuyrugaEkle(newEleman);

                while (!newKuyruk.kuyrukBos())
                {
                    if (newEleman.toplam == 99)
                    {
                        Console.WriteLine("Kazandınız..");
                        return newEleman.atis;
                    }

                    if (newEleman.toplam >= 100)
                    {
                        Console.WriteLine("Kaybettiniz..");
                        return newEleman.atis;
                    }
                    newEleman = newKuyruk.kuyrukSil();
                    for (i = 0; i < tahta.Length; i++)
                    {
                        j = newEleman.toplam + tahta[i];
                        if (i == 0)
                            newAtis = newEleman.atis + tahta[i];
                        else
                            newAtis = newEleman.atis + "_" + tahta[i];
                        newEleman = new Eleman(newAtis, j);
                        newKuyruk.kuyrugaEkle(newEleman);
                    }
                }
                return null;
            }
            public int[] tahtaAtisi()
            {
                int[] degerler = new int[5] { 11, 21, 27, 33, 36 };
                List<int> sonuclar = new List<int>();
                int toplam = 0;

                while (toplam <= 100)
                {
                    if (toplam == 99)
                        break;
                    Random random = new Random();
                    int sonuc = random.Next(0, 5);

                    Thread.Sleep(100);

                    sonuclar.Add(degerler[sonuc]);
                    toplam += degerler[sonuc];
                }

                return sonuclar.ToArray();

            }
        }
        static void Main(string[] args)
        {
            Kuyruk kuyruk = new Kuyruk();

            int[] atislarDizisi = kuyruk.tahtaAtisi();
            String atislar = kuyruk.hedefTahtasi(atislarDizisi);

            Console.WriteLine("Sonuclar : {0}", atislar);
            Console.ReadLine();

        }
    }
}