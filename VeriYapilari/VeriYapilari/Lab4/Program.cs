using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
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
            public dugum bas;
            public dugum son;
            public int size;
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

            public void bastanYaz()
            {
                dugum temp = bas;
                while (temp != null)
                {
                    Console.Write("{0}->", temp.veri);
                    temp = temp.ileri;
                }
                Console.WriteLine();
            }
            public void sondanYaz()
            {
                dugum temp = son;
                while (temp != null)
                {
                    Console.Write("{0}->", temp.veri);
                    temp = temp.geri;
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
            public void elemanArama(int aranan)
            {
                int sayac = 0, arananSayisi = 0;
                dugum temp = bas;
                while (temp!= null)
                {
                    if (temp.veri==aranan){
                        Console.WriteLine("{0} degeri [{1}] indisinde.",aranan,sayac);
                        sayac++;
                        arananSayisi++;
                    }
                    else
                        sayac++;
                    temp = temp.ileri;
                }
                if (arananSayisi == 0)
                    Console.WriteLine("{0} degeri listede bulunmuyor.", aranan);
            }
        }

        public static int listBoyutu(list liste)
        {
            int boyut = 0;
            dugum start = liste.bas;
            while (start != null)
            {
                boyut++;
                start = start.ileri;
            }
            return boyut;
        }
        public static list listeBirleştirme(list listef, list listel)
        {
            list birlesikList = new list();
            dugum dgm1 = listef.bas;
            while (dgm1 != null)
            {
                birlesikList.basaEkle(new dugum(dgm1.veri));
                dgm1 = dgm1.ileri;
            }
            dugum dgm2 = listel.bas;
            while (dgm2 != null)
            {
                birlesikList.basaEkle(new dugum(dgm2.veri));
                dgm2 = dgm2.ileri;
            }

            return birlesikList;
        }
        static void Main(string[] args)
        {
            list liste = new list();
            list liste2 = new list();

            string numara = "032290008";
            

            foreach (char x in numara)
            {
                dugum dx = new dugum(x-'0');
                liste.sonaEkle(dx);
            }
            foreach (char x in numara.Reverse())
            {
                dugum dy = new dugum(x - '0');
                liste2.sonaEkle(dy);
            }

            liste.bastanYaz();
            Console.WriteLine();
            liste2.bastanYaz();

            int listeBoyutu = listBoyutu(liste);
            Console.WriteLine("Liste Boyutu : {0}", listeBoyutu);
            Console.WriteLine("---------------------\n");

            list birlesikListe = listeBirleştirme(liste, liste2);
            birlesikListe.bastanYaz();
            Console.WriteLine();
            birlesikListe.elemanArama(0);
            
            Console.ReadKey();
        }
    }
}