#include <stdio.h>
#include <time.h>

int algorithmB(int);
void algorithmN(int);
void algorithmN2(int);
void studentNumber(void);

int main() {
	clock_t baslangic, bitis;
	baslangic = clock();
	algorithmB(3);
	bitis = clock();
	double calisma_zamani;
	calisma_zamani = (double)(bitis - baslangic) / CLOCKS_PER_SEC;
	printf("AlgorithmaB calisma suresi = %lf\n", calisma_zamani);

	clock_t baslangic2, bitis2;
	baslangic2 = clock();
	algorithmN2(100000);
	bitis2 = clock();
	double calisma_zamani2;
	calisma_zamani2 = (double)(bitis2 - baslangic2) / CLOCKS_PER_SEC;
	printf("algorithmN2 calisma suresi = %lf\n", calisma_zamani2);

	clock_t baslangic3, bitis3;
	baslangic3 = clock();
	algorithmN(100000);
	bitis3 = clock();
	double calisma_zamani3;
	calisma_zamani3 = (double)(bitis3 - baslangic3) / CLOCKS_PER_SEC;
	printf("algorithmN calisma suresi = %lf\n", calisma_zamani3);

	studentNumber();
	return 0;
}
int algorithmB(int n) {
	int s1, s2, s3;
	printf("Alt problem algrithmB(%d) hesaplaniyor...\n",n);
	if (n > 0) {
		s1 = algorithmB(n - 1);
		s2 = algorithmB(n - 1);
		s3 = algorithmB(n - 1);

		return s1 + s2 + s3;
	}
	else {
		return 0;
	}
}
void algorithmN(int n) {
	for (int i = 0; i < n; i++){}
}
void algorithmN2(int n) {
	for (int i = 0; i < n; i++) 
	{
		for (int j = 0; j < n; j++)
		{

		}
	}
}
void studentNumber() {
	int value = 9;
	int number[] = {0,3,2,2,9,0,0,0,8};
	int enBuyukEleman = number[0];
	for (int i = 0; i < value; i++)
	{
		if (number[i]>=enBuyukEleman)
		{
			enBuyukEleman = number[i];
		}
	}
	printf("En buyuk eleman : %d", enBuyukEleman);
}