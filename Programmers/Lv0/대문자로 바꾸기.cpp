#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// 파라미터로 주어지는 문자열은 const로 주어집니다. 변경하려면 문자열을 복사해서 사용하세요.
char* solution(const char* myString) {
    int size = strlen(myString) + 1;
    char* answer = (char*)malloc(size);

    for (int i = 0; i < size - 1; i++)
    {
        if (myString[i] >= 'a' && myString[i] <= 'z')
            answer[i] = 'A' + myString[i] - 'a';
        else
            answer[i] = myString[i];
    }

    answer[size - 1] = 0;
    return answer;
}