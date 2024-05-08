#include <stdlib.h>
#include <stdio.h>
#include <time.h>

typedef struct Eleman
{
	char* atis;
	int toplam;
	struct Eleman* ileri;
}Eleman;
Eleman* newEleman(char atis, int toplam) 
{
	Eleman* new = malloc(sizeof(Eleman));
	new->atis = atis;
	new->toplam = toplam;
	new->ileri = NULL;
	return new;
}

typedef struct Kuyruk
{
	Eleman* bas;
	Eleman* son;
}Kuyruk;

Kuyruk* newKuyruk(void) 
{
	Kuyruk* new = malloc(sizeof(Eleman));
	new->bas = NULL;
	new->son = NULL;
	return new;
}

int kuyrukBos(Kuyruk* kuyruk)
{
	if (kuyruk->bas == NULL)
		return 1;
	else
		return 0;
}
void kuyrugaEkle(Kuyruk* kuyruk, Eleman* eleman)
{
	if (!kuyrukBos(kuyruk))
		kuyruk->son->ileri = eleman;
	else
		kuyruk->bas = eleman;
	kuyruk->son = eleman;
}
Eleman* kuyrukSil(Kuyruk* kuyruk) 
{
	if (kuyrukBos(kuyruk))
		return NULL;
	Eleman* sonuc;
	sonuc = kuyruk->bas;
	kuyruk->bas = kuyruk->bas->ileri;
	if (kuyruk->bas == NULL)
		kuyruk->son == NULL;
	return sonuc;
}

char* hedefTahtasi(int tahta[], int atisSayisi)
{
	int i, j;

	char* atis;
	Eleman* eleman;
	Kuyruk* kuyruk;

	eleman = newEleman("", 0);
	kuyruk = newKuyruk();

	kuyrugaEkle(kuyruk, eleman);

	while(!kuyrukBos(kuyruk))
	{
		eleman = kuyrukSil(kuyruk);
		if (eleman->toplam == 99)
		{
			printf("Kazandiniz..\nAtislar: %s\n", eleman->atis);
			free(eleman->atis);
			free(eleman);
			break;
		}
		if (eleman->toplam >= 100)
		{
			printf("Kaybettiniz..\nAtislar: %s\n", eleman->atis);
			free(eleman->atis);
			free(eleman);
			break;
		}
		for (int i = 0; i < atisSayisi; i++) {
			int yeniToplam = eleman->toplam + tahta[i];
			char yeniAtis[200];
			printf("%s, %s_ %d", yeniToplam, eleman->atis, tahta[i]);

			Eleman* yeniEleman = newEleman(yeniAtis, yeniToplam);
			kuyrugaEkle(kuyruk, yeniEleman);
		}
		free(eleman->atis);
		free(eleman);

	}
}
int* tahtaAtisi() 
{
	int degerler[5] = { 11, 21, 27, 33, 36 };
	int sonuclar[1] = {0};
	int toplam = 0, index = 0;

	srand(time(NULL));
	while (toplam<=100)
	{
		if (toplam == 99)
			break;
		int r = rand() % 5;
		sonuclar[index] = degerler[r];
		toplam += degerler[r];

		index++;
	}
	return sonuclar;
}

int main(void) 
{
	Kuyruk* kuyruk = newKuyruk();
	int atislar[100] = { 11, 21, 27, 33, 36 };
	int atisSayisi = 5;

	hedefTahtasi(atislar, atisSayisi);

	free(kuyruk);
	return 0;
}