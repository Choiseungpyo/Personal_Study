#include <stdio.h>

int main(void) {
    int a;
    int b;
    scanf("%d %d", &a, &b);
    for (int row = 0; row < b; row++)
    {
        for (int col = 0; col < a; col++)
            printf("*");
        printf("\n");
    }

    return 0;
}