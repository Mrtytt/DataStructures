using System;
using System.Collections.Generic;

namespace Lab4
{
    internal class Program
    {
        class Eleman
        {
            public int katsayi;
            public int us;
            public Eleman ileri;
        }
        class Liste
        {
            public int size;
            public Eleman bas;
            public Eleman son;
        }

        static Eleman yeniEleman(int katsayi, int us)
        {
            Eleman yeni = new Eleman();
            yeni.katsayi = katsayi;
            yeni.us = us;
            yeni.ileri = null;
            return yeni;
        }

        static Liste yeniListe()
        {
            Liste liste = new Liste();
            liste.bas = null;
            liste.son = null;
            liste.size = 0;
            return liste;
        }

        static void listeyeEkle(Liste liste, Eleman eleman)
        {
            eleman.ileri = liste.bas;
            liste.bas = eleman;

            if (liste.bas == null)
                liste.son = eleman;

            liste.size++;
        }

        static Liste PolinomCarp(Liste polinom1, Liste polinom2)
        {
            Liste sonuc = yeniListe();

            for (Eleman i = polinom1.bas; i != null; i = i.ileri)
            {
                for (Eleman j = polinom2.bas; j != null; j = j.ileri)
                {
                    int yeniKatsayi = i.katsayi * j.katsayi;
                    int yeniUs = i.us + j.us;

                    Eleman yeni = sonuc.bas;
                    Eleman onceki = null;
                    while (yeni != null && yeni.us != yeniUs)
                    {
                        onceki = yeni;
                        yeni = yeni.ileri;
                    }

                    if (yeni == null)
                    {
                        Eleman yeniElemanSonuc = yeniEleman(yeniKatsayi, yeniUs);
                        listeyeEkle(sonuc, yeniElemanSonuc);
                    }
                    else
                    {
                        yeni.katsayi += yeniKatsayi;
                        if (yeni.katsayi == 0)
                        {
                            if (onceki == null)
                                sonuc.bas = yeni.ileri;
                            else
                                onceki.ileri = yeni.ileri;

                            if (yeni == sonuc.son)
                                sonuc.son = onceki;
                            sonuc.size--;
                        }
                    }
                }
            }

            return sonuc;
        }
        static void PolinomYaz(Liste polinom)
        {
            for (Eleman i = polinom.bas;  i != null; i = i.ileri)
                Console.Write("{0}x^{1} ",i.katsayi,i.us);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Liste polinom1 = yeniListe();
            Liste polinom2 = yeniListe();

            listeyeEkle(polinom1, yeniEleman(3, 2));
            listeyeEkle(polinom1, yeniEleman(4, 1));
            listeyeEkle(polinom1, yeniEleman(2, 0));

            listeyeEkle(polinom2, yeniEleman(1, 1));
            listeyeEkle(polinom2, yeniEleman(2, 0));

            Console.Write("Polinom 1 : ");
            PolinomYaz(polinom1);
            Console.Write("Polinom 2 : ");
            PolinomYaz(polinom2);
            Liste carpimSonucu = PolinomCarp(polinom1, polinom2);

            Console.Write("Çarpım Sonucu: ");
            PolinomYaz(carpimSonucu);

            Console.ReadKey();
        }
    }
}
