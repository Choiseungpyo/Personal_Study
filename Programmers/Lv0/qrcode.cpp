#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// 파라미터로 주어지는 문자열은 const로 주어집니다. 변경하려면 문자열을 복사해서 사용하세요.
char* solution(int q, int r, const char* code) {
    int size = strlen(code) / q + (strlen(code) % q >= r ? 1 : 0);
    char* answer = (char*)malloc(size + 1);

    for (int i = 0; i < size; i++)
        answer[i] = code[i * q + r];

    answer[size] = 0;
    return answer;
}