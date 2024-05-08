#include <stdio.h>
#include <stdlib.h>


typedef struct dugum {
	int veri;
	struct dugum* ileri;
} dugum;


typedef struct list {
	int size;
	dugum* bas;
	dugum* son;
} list;

dugum* yeni_dugum(int);

list* yeni_list(void) {
	list* liste = malloc(sizeof(dugum));
	liste->bas = NULL;
	liste->son = NULL;
	liste->size = 0;
	return liste;
}

void list_add_item_first(list* liste, dugum* dugumum)
{
	dugumum->ileri = liste->bas;
	liste->bas = dugumum;

	if (liste->bas == NULL)
	{
		liste->son = dugumum;
	}

	liste->size++;
}
void list_add_item_last(list* liste, dugum* dugumum)
{
	if (liste->son == NULL)
	{
		liste->bas = dugumum;
	}
	else
	{
		liste->son->ileri = dugumum;
	}
	liste->son = dugumum;

	liste->size++;
}


void list_add_item_between(list* liste, dugum* location, dugum* dugumum)
{
	dugumum->ileri = location->ileri;
	location->ileri = dugumum;

	liste->size++;
}

int list_size(list* liste)
{
	int ctr = 0;
	dugum* start = liste->bas;
	while (start != NULL)
	{
		ctr++;
		start = start->ileri;
	}
	if (liste->size != ctr)
	{
		liste->size = ctr;
		printf("not possible");
	}
	return ctr;
}

void list_add_item_middle(list* liste, dugum* dugumum)
{
	int middle = list_size(liste) / 2;
	dugum* start = liste->bas;
	for (int i = 1; i < middle; i++)
	{
		start = start->ileri;
	}
	printf("BURADAYIM: %d\n", start->veri);
	list_add_item_between(liste, start, dugumum);
}

void list_write(list* liste)
{
	dugum* start = liste->bas;
	while (start != NULL)
	{
		printf("%d->", start->veri);
		start = start->ileri;
	}
	printf("NULL\n");
}
void list_remove_first_item(list* liste) {
	if (liste->bas == NULL) {
		// Liste zaten boþ
		return;
	}
	dugum* gecici = liste->bas;
	liste->bas = liste->bas->ileri;
	free(gecici);
	liste->size--;

	if (liste->bas == NULL) {
		// Liste boþsa, son düðümü de güncelle
		liste->son = NULL;
	}
}
void list_remove_last_item(list* liste) {
	if (liste->bas == NULL) {
		// Liste zaten boþ
		return;
	}
	if (liste->bas->ileri == NULL) {
		// Tek eleman varsa
		free(liste->bas);
		liste->bas = NULL;
		liste->son = NULL;
	}
	else {
		dugum* gecici = liste->bas;
		while (gecici->ileri->ileri != NULL) {
			gecici = gecici->ileri;
		}
		free(gecici->ileri);
		gecici->ileri = NULL;
		liste->son = gecici;
	}
	liste->size--;
}


int main(void)
{
	list* liste = yeni_list();

	list_add_item_last(liste, yeni_dugum(15));
	list_add_item_last(liste, yeni_dugum(20));
	list_add_item_last(liste, yeni_dugum(30));
	list_add_item_first(liste, yeni_dugum(5));

	list_add_item_middle(liste, yeni_dugum(15));

	list_write(liste);

	list_remove_last_item(liste);

	list_write(liste);

	list_remove_first_item(liste);

	list_write(liste);
	return 0;
}

dugum* yeni_dugum(int value) {
	dugum* duguma = malloc(sizeof(dugum));
	duguma->veri = value;
	duguma->ileri = NULL;

	return duguma;
}