#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// �Ķ���ͷ� �־����� ���ڿ��� const�� �־����ϴ�. �����Ϸ��� ���ڿ��� �����ؼ� ����ϼ���.
int solution(const char* num_str) {
    int answer = 0;
    for (int i = 0; num_str[i] != 0; i++)
        answer += num_str[i] - '0';
    return answer;
}