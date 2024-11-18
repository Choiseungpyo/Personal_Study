#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// 파라미터로 주어지는 문자열은 const로 주어집니다. 변경하려면 문자열을 복사해서 사용하세요.
char* solution(const char* my_string, int m, int c) {
    int size = strlen(my_string) / m;
    char* answer = (char*)malloc(size + 1);

    for (int i = 0; i < size; i++)
        answer[i] = my_string[m * i + c - 1];

    answer[size] = 0;
    return answer;
}