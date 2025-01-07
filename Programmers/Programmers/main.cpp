#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int* solution(int n) {
    int size = n % 2 == 0 ? n/2 : n/2 + 1;
    int* answer = (int*)malloc(sizeof(int) * size);

    for (int i = 0; i < size; i++)
        answer[i] = 2 * i + 1;

    return answer;
}
int main()
{
    const char* str_list[] = { "problemsolving", "practiceguitar", "swim", "studygraph" };
    bool fubusged[] = { true, false, true, false };
    int* a = solution(10);
    return 0;
}