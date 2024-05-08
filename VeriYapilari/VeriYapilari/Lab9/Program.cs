using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
    class Node
    {
        public string kelime;
        public string binaryDeger;
        public int frekans;
        public Node sol;
        public Node sag;

        public Node(int frekans, string kelime)
        {
            this.frekans = frekans;
            this.sol = null;
            this.sag = null;
            this.kelime = kelime;
        }
    }

    class Tree
    {
        public Node root;

        public Tree()
        {
            this.root = null;
        }
        public List<char> harfleriListeyeEkle(string ifade)
        {
            List<char> harfler = new List<char>();
            foreach (char harf in ifade)
                if (!harfler.Contains(harf))
                    harfler.Add(harf);
            return harfler;
        }
        public List<int> harflerinFrekansınıBul(string ifade, List<char> harfler)
        {
            List<int> frekanslar = new List<int>();
            int sayac = 0;
            foreach (char harf in harfler)
            {
                for (int i = 0; i < ifade.Length; i++)
                    if (harf == ifade[i])
                        sayac++;
                frekanslar.Add(sayac);
                sayac = 0;
            }
            return frekanslar;
        }
        public List<DictionaryEntry> frekanslarıEslestir(List<int> frekanslar, List<char> harfler)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < harfler.Count; i++)
                ht.Add(harfler[i], frekanslar[i]);

            var list = new List<DictionaryEntry>();
            foreach (DictionaryEntry entry in ht)
                list.Add(entry);
            list.Sort((x, y) => Comparer<int>.Default.Compare((int)x.Value, (int)y.Value));

            return list;
        }
        public List<Node> kelimeleriNodeCevir(List<DictionaryEntry> harfListesi)
        {
            List<Node> dugumListesi = new List<Node>();
            foreach (DictionaryEntry entry in harfListesi)
            {
                Node node = new Node(Convert.ToInt32(entry.Value), entry.Key.ToString());
                dugumListesi.Add(node);
            }
            return dugumListesi;
        }
        public List<Node> agacOlusturma(List<Node> dugumler)
        {
            List<Node> temp = dugumler;
            while (temp.Count != 1)
            {
                Node node = new Node(0, " ");
                node.frekans = temp[0].frekans + temp[1].frekans;
                node.kelime = temp[0].kelime + temp[1].kelime;

                node.sol = temp[0];
                node.sag = temp[1];

                temp.RemoveAt(0);
                temp.RemoveAt(0);

                temp.Add(node);
                temp.Sort((x, y) => Comparer<int>.Default.Compare((int)x.frekans, (int)y.frekans));
            }
            return temp;
        }
        public void agacYazdir(List<Node> dugumler, int seviye, int derinlik)
        {
            if (dugumler.Count == 0 || dugumlerBos(dugumler))
                return;

            int kat = derinlik - seviye;
            int kenarCizgileri = (int)Math.Pow(2, Math.Max(kat - 1, 0));
            int ilkBosluk = (int)Math.Pow(2, kat) - 1;
            int aradakiBosluk = (int)Math.Pow(2, kat + 1) - 1;

            bosluklariYazdir(ilkBosluk);

            List<Node> yeniDugumler = new List<Node>();
            foreach (var dugum in dugumler)
            {
                if (dugum != null)
                {
                    Console.Write(dugum.kelime);
                    yeniDugumler.Add(dugum.sol);
                    yeniDugumler.Add(dugum.sag);
                }
                else
                {
                    yeniDugumler.Add(null);
                    yeniDugumler.Add(null);
                    Console.Write(" ");
                }

                bosluklariYazdir(aradakiBosluk);
            }
            Console.WriteLine();

            for (int i = 1; i <= kenarCizgileri; i++)
            {
                for (int j = 0; j < dugumler.Count; j++)
                {
                    bosluklariYazdir(ilkBosluk - i);
                    if (dugumler[j] == null)
                    {
                        bosluklariYazdir(kenarCizgileri + kenarCizgileri + i + 1);
                        continue;
                    }

                    if (dugumler[j].sol != null)
                        Console.Write("/");
                    else
                        bosluklariYazdir(1);

                    bosluklariYazdir(i + i - 1);

                    if (dugumler[j].sag != null)
                        Console.Write("\\");
                    else
                        bosluklariYazdir(1);

                    bosluklariYazdir(kenarCizgileri + kenarCizgileri - i);
                }
                Console.WriteLine();
            }
            agacYazdir(yeniDugumler, seviye + 1, derinlik);
            
        }
        public bool dugumlerBos(List<Node> list)
        {
            return list.All(item => item == null);
        }
        public int maxSeviye(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(maxSeviye(node.sol), maxSeviye(node.sag)) + 1;
        }
        public void bosluklariYazdir(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write(" ");
        }
        public void binaryDegerleriBul(Node node,string code)
        {
            if (node.sol != null)
                binaryDegerleriBul(node.sol, code + "0");
            if (node.sag != null)
                binaryDegerleriBul(node.sag, code + "1");
            
            if (node.sol == null && node.sag == null)
                node.binaryDeger = code;
        }
        public void binaryDegerleriGoster(Node node)
        {
            if (node == null)
                return;

            if (node.sol == null && node.sag == null)
                Console.WriteLine("Harf : {0}, Frekans : {1}, BinaryCode: {2}", node.kelime, node.frekans, node.binaryDeger);
            binaryDegerleriGoster(node.sol);
            binaryDegerleriGoster(node.sag);
        }
        public Hashtable binaryCodeHashtable(Node node)
        {
            Hashtable ht = new Hashtable();

            void degistir(Node current, string code = "")
            {
                if (current == null) return;

                if (current.sol == null && current.sag == null && current.kelime.Length == 1)
                    ht[current.kelime[0]] = code;

                degistir(current.sol, code + "0");
                degistir(current.sag, code + "1");
            }

            degistir(node);
            return ht;
        }
        public string binaryCodeReplace(string kelime, Hashtable ht)
        {
            var result = new StringBuilder();
            foreach (char c in kelime)
            {
                if (ht.ContainsKey(c))
                    result.Append(ht[c] as string);
                else
                    result.Append(c);
            }
            return result.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bir kelime giriniz : ");
            string kelime = Console.ReadLine().ToLower();

            Tree tree = new Tree();

            List<char> harfListesi = tree.harfleriListeyeEkle(kelime);
            List<int> freakans = tree.harflerinFrekansınıBul(kelime, harfListesi);
             

            List<DictionaryEntry> list = tree.frekanslarıEslestir(freakans, harfListesi);

            List<Node> yeniKelimeListesi = tree.kelimeleriNodeCevir(list);

            foreach (Node node in yeniKelimeListesi)
                Console.WriteLine("Key : {0},Value : {1}", node.kelime, node.frekans);
            Console.WriteLine("---------------------------------");

            List<Node> dugumler = tree.agacOlusturma(yeniKelimeListesi);

            Console.WriteLine("Ağaç Şeklinde Gösterim:");
            tree.agacYazdir(dugumler,0,harfListesi.Count-1);
            Console.WriteLine("---------------------------------\n");

            if (dugumler.Count > 0)
                tree.binaryDegerleriBul(dugumler[0], " ");

            tree.binaryDegerleriGoster(dugumler[0]);

            Hashtable ht = tree.binaryCodeHashtable(dugumler[0]);
            string replacedString = tree.binaryCodeReplace(kelime, ht);

            Console.WriteLine("Binary gösterim: " + replacedString);

            Console.ReadLine();
        }
    }
}


