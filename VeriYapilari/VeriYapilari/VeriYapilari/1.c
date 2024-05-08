#include <stdio.h>
#include <stdlib.h>

struct dugum {
    int veri;
    struct dugum* ileri;
};

typedef struct dugum Dugum;
typedef Dugum* Dugump;

int main(void) {
    Dugump dugump;
    dugump = (Dugump)malloc(sizeof(Dugum));

    if (dugump == NULL) {
        printf("ERROR : Malloc returned NULL\n");
        return 1;
    };

    dugump->veri = 10;
    dugump->ileri= NULL;

    printf("dugump->veri = %d\n", dugump->veri);
}