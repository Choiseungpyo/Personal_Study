#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <math.h>

void Problem_1();

int main()
{
	Problem_1();
}

void Problem_1() // 소수점 이하 두자리수만 추출하여 정수형 변수에 대입
{
	float f;
	int i;

	printf("실수를 입력하시오 : ");
	scanf("%f", &f);
	i = abs(((f - (int)f) * 100));
	printf("i : %d", i);
}