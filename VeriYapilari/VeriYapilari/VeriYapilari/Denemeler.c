#include <stdlib.h>
#include <stdio.h>

typedef struct dugum {
	int veri;
	struct dugum* ileri;
	struct dugum* geri;
} dugum;


typedef struct liste {
	int size;
	dugum* bas;
	dugum* son;
} liste;

dugum* yeni_dugum(int veri) 
{
	dugum* ydugum = malloc(sizeof(dugum));
	ydugum->veri = veri;
	ydugum->geri = NULL;
	ydugum->ileri = NULL;
	return ydugum;
}

liste* yeni_liste(void) {
	liste* yliste = malloc(sizeof(dugum));
	yliste->bas = NULL;
	yliste->son = NULL;
	yliste->size = 0;
	return yliste;
}

void basaEkle(liste* liste,dugum* yeni)
{
	yeni->ileri = liste->bas;
	liste->bas = yeni;

	if (liste->bas == NULL)
		liste->son = yeni;
	liste->size++;
}
void bastanYaz(liste* liste)
{
	dugum* temp = liste->bas;
	while (temp != NULL)
	{
		printf("%d ",temp->veri);
		temp = temp->ileri;
	}
	printf("\n");
}
int main(void) {

	liste* liste = yeni_liste();

	basaEkle(liste, yeni_dugum(10));
	basaEkle(liste, yeni_dugum(20));
	basaEkle(liste, yeni_dugum(30));

	bastanYaz(liste);

	return 0;
}