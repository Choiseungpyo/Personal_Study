#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

char* solution(const char* myString) {
    int size = strlen(myString);
    char* answer = (char*)malloc(size + 1);

    for (int i = 0; i < size; i++)
    {
        if (myString[i] < 'l')
            answer[i] = 'l';
        else
            answer[i] = myString[i];
    }
    answer[size] = 0;

    return answer;
}

int main()
{
    int arr[] = { 2021, 12, 28 };
    int arr1[] = { 2021, 12, 29 };
    char* a = solution("abcdevwxyz");
    return 0;
}