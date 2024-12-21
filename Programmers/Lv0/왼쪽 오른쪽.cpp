#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// str_list_len은 배열 str_list의 길이입니다.
// 파라미터로 주어지는 문자열은 const로 주어집니다. 변경하려면 문자열을 복사해서 사용하세요.
char** solution(const char* str_list[], size_t str_list_len) {
    // return 값은 malloc 등 동적 할당을 사용해주세요. 할당 길이는 상황에 맞게 변경해주세요.
    char** answer = (char**)malloc(sizeof(char*) * str_list_len);
    int startIndex = -1;
    int endIndex = str_list_len;
    int i = 0;
    for (; i < str_list_len; i++)
    {
        if (!strcmp(str_list[i], "l"))
        {
            startIndex = 0;
            endIndex = i;
            break;
        }
        else if (!strcmp(str_list[i], "r"))
        {
            startIndex = i + 1;
            if (startIndex >= str_list_len - 1)
                startIndex = -1;
            break;
        }
    }

    if (startIndex == -1)
    {
        realloc(answer, 0);
        return answer;
    }

    realloc(answer, sizeof(char*) * (endIndex - startIndex + 1));

    int answerIndex = 0;
    for (i = startIndex; i < endIndex; i++)
    {
        answer[answerIndex] = (char*)malloc(strlen(str_list[i]) + 1);
        strcpy(answer[answerIndex++], str_list[i]);
    }


    return answer;
}