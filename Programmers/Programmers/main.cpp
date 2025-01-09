#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int solution(int n, int k) {
    return 12000 * n + 2000 * (k-n/10);
}
int main()
{
    const char* str_list[] = { "problemsolving", "practiceguitar", "swim", "studygraph" };
    bool fubusged[] = { true, false, true, false };
    int a = solution(64, 6);
    return 0;
}