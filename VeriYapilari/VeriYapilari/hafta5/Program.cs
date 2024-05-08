using System;

namespace hafta5
{
    public class dugum
    {
        public int veri;
        public dugum ileri;
        public dugum geri;
        public dugum(int veri)
        {
            this.veri = veri;
            ileri = null;
            geri = null;
        }
    }

    public class list
    {
        dugum bas;
        dugum son;

        public list()
        {
            bas = null;
            son = null;
        }

        public void basaEkle(dugum yeni)
        {
            if (bas == null)
            {
                bas = yeni;
                son = yeni;
            }
            else
            {
                yeni.ileri = bas;
                bas.geri = yeni;
                bas = yeni;
            }
        }

        public void sonaEkle(dugum yeni)
        {
            if (son == null)
            {
                bas = yeni;
                son = yeni;
            }
            else
            {
                son.ileri = yeni;
                yeni.geri = son;
                son = yeni;
            }
        }

        public void yaz()
        {
            dugum temp = bas;
            while (temp != null)
            {
                Console.Write("{0}->", temp.veri);
                temp = temp.ileri;
            }
            Console.WriteLine();
        }

        public void arayaEkle(dugum anchor, dugum newNode)
        {
            if (anchor == null || anchor == son)
            {
                sonaEkle(newNode);
                return;
            }

            dugum anchor2 = anchor.ileri;
            newNode.ileri = anchor2;
            newNode.geri = anchor;

            anchor.ileri = newNode;
            anchor2.geri = newNode;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            dugum d1 = new dugum(10);
            dugum d2 = new dugum(20);
            dugum d3 = new dugum(30);

            list liste = new list();

            liste.basaEkle(d1);
            liste.basaEkle(d2);
            liste.basaEkle(d3);
            liste.yaz();
            Console.ReadKey();
        }
    }
}
