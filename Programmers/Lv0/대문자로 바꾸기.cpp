#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// �Ķ���ͷ� �־����� ���ڿ��� const�� �־����ϴ�. �����Ϸ��� ���ڿ��� �����ؼ� ����ϼ���.
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