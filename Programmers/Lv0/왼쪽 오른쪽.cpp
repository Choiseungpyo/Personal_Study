#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// str_list_len�� �迭 str_list�� �����Դϴ�.
// �Ķ���ͷ� �־����� ���ڿ��� const�� �־����ϴ�. �����Ϸ��� ���ڿ��� �����ؼ� ����ϼ���.
char** solution(const char* str_list[], size_t str_list_len) {
    // return ���� malloc �� ���� �Ҵ��� ������ּ���. �Ҵ� ���̴� ��Ȳ�� �°� �������ּ���.
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