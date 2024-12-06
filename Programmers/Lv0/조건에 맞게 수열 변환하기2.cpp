#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// arr_len�� �迭 arr�� �����Դϴ�.
int solution(int arr[], size_t arr_len) {
    int answer = 0;
    int* prvArr = (int*)malloc(sizeof(int) * arr_len);

    while (true)
    {
        for (int i = 0; i < arr_len; i++)
        {
            prvArr[i] = arr[i];
            if (arr[i] >= 50 && arr[i] % 2 == 0)
                arr[i] /= 3;
            else if (arr[i] < 50 && arr[i] % 2 != 0)
                arr[i] = arr[i] * 2 + 1;
        }

        for (int i = 0; i < arr_len; i++)
        {
            if (prvArr[i] != arr[i])
                break;

            if (i == arr_len - 1)
                return answer;
        }

        answer++;
    }

    return -1;
}