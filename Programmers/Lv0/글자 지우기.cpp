#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// indices_len은 배열 indices의 길이입니다.
// 파라미터로 주어지는 문자열은 const로 주어집니다. 변경하려면 문자열을 복사해서 사용하세요.
char* solution(const char* my_string, int indices[], size_t indices_len) {
    char* answer = (char*)malloc(strlen(my_string) + 1 - indices_len);
    bool flag = false;
    int answerIndex = 0;

    for (int i = 0; i < strlen(my_string) + 1; i++)
    {
        flag = true;
        for (int indicesIndex = 0; indicesIndex < indices_len; indicesIndex++)
        {
            if (i == indices[indicesIndex])
            {
                flag = false;
                break;
            }
        }

        if (flag)
            answer[answerIndex++] = my_string[i];
    }
    return answer;
}