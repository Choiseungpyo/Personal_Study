#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// arr_len은 배열 arr의 길이입니다.
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