#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// arr_len은 배열 arr의 길이입니다.
// intervals_rows는 2차원 배열 intervals의 행 길이, intervals_cols는 2차원 배열 intervals의 열 길이입니다.
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