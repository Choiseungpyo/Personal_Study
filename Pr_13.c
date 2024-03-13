#include <stdio.h>

void Problem_1();
int fx(int x);

void Problem_2();
void Slave(int* property, int income);

void Problem_3();
int CalculateSum(int n);

void Problem_4();
void PrintPrime(int n);

void Problem_5();
void PrintPrimeFactorization(int n);

int main()
{
	//Problem_5();
	return 0;
}

// 13_1장

void Problem_1() // f(x) = x+4
{
	printf("f(4) = %d", fx(4));
}

int fx(int x)
{
	return x + 4;
}

//----------------------------------------------------------------------------

void Problem_2() // 기존 재산 + 수입 = 현재 재산 계산하기
{
	int property = 10000;
	
	printf("현재 재산 : %d\n", property);

	Slave(&property, 500);

	printf("현재 재산 : %d\n", property);
}

void Slave(int* property, int income)
{
	*property += income;
}

//----------------------------------------------------------------------------

void Problem_3() // 1부터 n까지의 합 구하기
{
	printf("1부터 %d까지의 합 : %d", 10, CalculateSum(10));
}

int CalculateSum(int n)
{
	int sum = 0;
	for (int i = 1; i <= n; i++)
	{
		sum += i;
	}

	return sum;
}

//----------------------------------------------------------------------------

void Problem_4() // n까지의 소수 구하기
{
	PrintPrime(50);
}

void PrintPrime(int n)
{
	int cnt = 0;
	int i;

	for (i = 1; i <= n; i++)
	{
		for (int a = 1; a <= i; a++)
		{
			if(i%a ==0)
				++cnt;
			if (cnt > 2)
				break;
		}
			
		if (cnt ==2)
			printf("%d\n", i);
		cnt = 0;
	}
}

//----------------------------------------------------------------------------

void Problem_5() // n의 소인수분해 값 출력
{
	PrintPrimeFactorization(180);
}

void PrintPrimeFactorization(int n)
{
	printf("%d의 소인수분해 값 : ", n);
	for (int i = 2; i <= n; i++)
	{
		if (n % i == 0)
		{
			if (i == n)
			{
				printf("%d", i);
				break;
			}
			else
			{
				printf("%d * ", i);
				n /= i;
				i = 1;
			}
			
		}
			
	}
}

//----------------------------------------------------------------------------

// 문제 6 : int function(int* arg)가 무엇을 의미하는가?
// 무엇을 반환하고 arg가 무슨 역할인지 문제에 주어졌으면 풀이하겠는데 정보가 없어 답하기 조금 어렵다
// arg라는 포인터 변수로 어떤 변수의 주소값을 받아서 사용하고, int형을 반환하다라는 내용밖에 추리할 수 없다. 
