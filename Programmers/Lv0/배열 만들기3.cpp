#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// arr_len�� �迭 arr�� �����Դϴ�.
// intervals_rows�� 2���� �迭 intervals�� �� ����, intervals_cols�� 2���� �迭 intervals�� �� �����Դϴ�.
int* solution(int arr[], size_t arr_len, int** intervals, size_t intervals_rows, size_t intervals_cols) {
    int* answer = (int*)malloc(sizeof(int) * ((intervals[0][1] - intervals[0][0] + 1) + (intervals[1][1] - intervals[1][0] + 1)));
    int answerIndex = 0;

    for (int row = 0; row < intervals_rows; row++)
    {
        for (int col = intervals[row][0]; col <= intervals[row][1]; col++)
            answer[answerIndex++] = arr[col];
    }

    return answer;
}