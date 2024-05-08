#include <stdio.h>
#include <stdlib.h>

struct Ogrenci {
	char ad[50];
	int numara;
	float zaman;
};
typedef struct Ogrenci ogr;
typedef ogr* ogrp;

struct Ogrenci2 {
	char *ad;
	int numara;
	float zaman;
};
typedef struct Ogrenci2 ogr2;
typedef ogr2* ogr2p;

int *pointer;
void firstQuestion();
void secondQuestion();
void thirdQuestion();

int main(void) {
	firstQuestion();
	secondQuestion();
	//thirdQuestion();
}

void firstQuestion() {
	ogrp ogr1p;
	ogr1p = (ogrp)malloc(sizeof(ogr));

	if (ogr1p == NULL) {
		printf("ERROR : Malloc returned NULL\n");
		return 1;
	};

	ogr ogr1;
	snprintf(ogr1.ad, sizeof(ogr1.ad), "Murat");
	ogr1.numara = 32290008;
	ogr1.zaman = 18.25;

	printf("OGR POINTER : %p\n", ogr1p);
	printf("OGR AD:     %s\n", ogr1.ad);
	printf("OGR NUMARA: %d\n", ogr1.numara);
	printf("OGR ZAMAN:  %f\n", ogr1.zaman);
	printf("OGR AD Boyutu:     %d bytes\n", sizeof(ogr));
	printf("OGR AD Boyutu:     %d bytes\n", sizeof(ogr1.ad));
	printf("OGR NUMARA Boyutu: %d bytes\n", sizeof(ogr1.numara));
	printf("OGR ZAMAN Boyutu:  %d bytes\n", sizeof(ogr1.zaman));
}
void secondQuestion() {
	ogr2p ogr1p2;
	ogr1p2 = (ogr2p)malloc(sizeof(ogr2));

	if (ogr1p2 == NULL) {
		printf("ERROR : Malloc returned NULL\n");
		return 1;
	};

	ogr2 ogr12;
	ogr1p2->ad = "Baris";
	ogr1p2->numara = 32290004;
	ogr1p2->zaman = 18.75;

	printf("\n");
	printf("OGR2 POINTER : %p\n", ogr1p2);
	printf("OGR2 AD:     %s\n", ogr1p2->ad);
	printf("OGR2 NUMARA: %d\n", ogr1p2->numara);
	printf("OGR2 ZAMAN:  %f\n", ogr1p2->zaman);
	printf("OGR2 AD Boyutu:     %d bytes\n", sizeof(ogr2));
	printf("OGR2 AD Boyutu:     %d bytes\n", sizeof(ogr1p2->ad));
	printf("OGR2 NUMARA Boyutu: %d bytes\n", sizeof(ogr1p2->numara));
	printf("OGR2 ZAMAN Boyutu:  %d bytes\n", sizeof(ogr1p2->zaman));
}
void thirdQuestion() {

	int n;
	printf("Dizinin boyurunu giriniz :");
	scanf_s("%d\n", &n);

	pointer = (int*)malloc(n * sizeof(int));
	for (int i = 0; i < n; i++)
	{
		scanf_s("%d", pointer + i);
	}
	printf("Girilen elemanin:\n");
	for (int i = 0; i < n; i++)
	{
		printf("Pointer adresi :%p\n", pointer + i);
		printf("Pointer degeri :%d\n", *(pointer + i));
		printf("\n");
	}
	free(pointer);
}