#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

// 파라미터로 주어지는 문자열은 const로 주어집니다. 변경하려면 문자열을 복사해서 사용하세요.
char* solution(const char* my_string) {
    int size = strlen(my_string);
    char* answer = (char*)malloc(size+1);

    for (int i = 0; i < size; i++)
        answer[i] = my_string[size - i - 1];
    answer[size] = 0;

    return answer;
}

int main()
{
    const char* str_list[] = { "problemsolving", "practiceguitar", "swim", "studygraph" };
    bool fubusged[] = { true, false, true, false };
    char* a = solution("jaron");
    return 0;
}