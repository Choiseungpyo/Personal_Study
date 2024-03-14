#include <stdio.h>

void Problem_1(int n);
void Problem_2(int n);
void Problem_3();
void Problem_4();
void Problem_5(int n);
void Problem_6();
void Problem_7();
void Problem_8();
void Problem_9();
void Problem_10();





int main()
{
	Problem_5(5);

	return 0;
}

void Problem_1(int n) //n줄인 삼각형 출력
{
	for (int i = 0; i < n; i++)
	{
		for (int a = 0; a < n - 1 -i; a++)
			printf(" ");

		for (int b = 0; b < 2 * i + 1; b++)
			printf("*");

		for (int a = 0; a < n - 1-i; a++)
			printf(" ");
		printf("\n");
	}
}

void Problem_2(int n) // 역삼각형
{
	for (int i = 0; i <= n; i++)
	{
		for (int a = 0; a < i; a++)
			printf(" ");

		for (int b = 0; b < 2 * (n-i) - 1; b++)
			printf("*");

		for (int a = 0; a <= i; a++)
			printf(" ");
		printf("\n");
	}
}

void Problem_3() // 1000이하의 3또는 5의 배수인 자연수들의 합 구하기
{
	int sum = 0;

	for (int i = 1; i <= 1000; i++)
	{
		if ((i % 3 == 0 || i % 5 == 0) && i >= 3)
		{
			sum += i;
			printf("%d\n", i);
		}
			
	}
}

void Problem_4() //10000이하의 피보나치 수열의 짝수항들의 합을 구한다. 
{
	// f0 : 0
	// f1 : 1
	// f2 : 1
	// f3 : 2
	int fBefore = 0;
	int fAfter = 1;
	int tmp = 0;
	int sumEven = 0;

	for (int i = 2; fAfter <= 20; i++)
	{
		tmp = fAfter;
		fAfter += fBefore; // 현재 구한 f
		fBefore = tmp; 

		printf("%d : %d\n", i,fAfter);
		if (i % 2 == 0)
			sumEven += fAfter;
	}

	printf("10000이하의 피보나치 수열의 짝수항들의 합 : %d\n", sumEven);
}

void Problem_5(int n) // 1부터 N까지의 곱을 출력한다. 
{
	int result = 1;

	for (int i = 1; i <= n; i++)
	{
		result *= i;
	}

	printf("%d \n", result);
}

void Problem_6() // a+b+c = 2000 && a>b>c a,b,c는 모두 자연수 : 만족하는 모든 abc의 개수는 ?
{
	int cnt = 0;

	for (int a = 1; a <= 2000; a++)
	{
		for (int b = 1; b <= 2000; b++)
		{
			for (int c = 1; c <= 2000; c++)
			{
				if (a + b + c == 2000)
					if (a > b && b > c)
						++cnt;
					
			}
		}
	}

	printf("조건을 만족하는 abc의 개수 : %d\n", cnt);
}

void Problem_7(int input) // 임의의 자연수를 소인수분해
{
	printf("%d = ", input);

	for (int i = 2; i <= input; i++)
	{
		if (input % i == 0) 
		{
			input /= i;
			printf("%d", i);
			i = 2; //처음부터 다시 약수 찾기

			if (input == 1)
				break;
			else
				printf(" * ");
		}
	}
}

void Problem_8()
{
	// 잘 모르겠음
}