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

// 13_1��

void Problem_1() // f(x) = x+4
{
	printf("f(4) = %d", fx(4));
}

int fx(int x)
{
	return x + 4;
}

//----------------------------------------------------------------------------

void Problem_2() // ���� ��� + ���� = ���� ��� ����ϱ�
{
	int property = 10000;
	
	printf("���� ��� : %d\n", property);

	Slave(&property, 500);

	printf("���� ��� : %d\n", property);
}

void Slave(int* property, int income)
{
	*property += income;
}

//----------------------------------------------------------------------------

void Problem_3() // 1���� n������ �� ���ϱ�
{
	printf("1���� %d������ �� : %d", 10, CalculateSum(10));
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

void Problem_4() // n������ �Ҽ� ���ϱ�
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

void Problem_5() // n�� ���μ����� �� ���
{
	PrintPrimeFactorization(180);
}

void PrintPrimeFactorization(int n)
{
	printf("%d�� ���μ����� �� : ", n);
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

// ���� 6 : int function(int* arg)�� ������ �ǹ��ϴ°�?
// ������ ��ȯ�ϰ� arg�� ���� �������� ������ �־������� Ǯ���ϰڴµ� ������ ���� ���ϱ� ���� ��ƴ�
// arg��� ������ ������ � ������ �ּҰ��� �޾Ƽ� ����ϰ�, int���� ��ȯ�ϴٶ�� ����ۿ� �߸��� �� ����. 
