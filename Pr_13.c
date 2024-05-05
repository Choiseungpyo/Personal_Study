#include <stdio.h>

void Problem1_1();
int fx(int x);

void Problem1_2();
void Slave(int* property, int income);

void Problem1_3();
int CalculateSum(int n);

void Problem1_4();
void PrintPrime(int n);

void Problem1_5();
void PrintPrimeFactorization(int n);

void Problem2_1();
void SaveDesiredValue(int* arr, int n, int desiredNum, int desiredIndex);
void ChangeBigOrderArr(const int* originalArr, int* bigOrderArr, int n);
void PrintMaxNums(const int* arr, int n);

void Problem3_1();
void CalculateAvg(const int studentGrade[][3], int rowScale, float studentAvg[]);
void SetStudentGradeOrder(float studentAvg[], int studentAvgScale);
void PutDesiredPos(int studentAvg[], int studentAvgScale, int desiredIndex, int desiredValue);

int main()
{
	Problem3_1();
	return 0;
}

// 13_1��

void Problem1_1() // f(x) = x+4
{
	printf("f(4) = %d", fx(4));
}

int fx(int x)
{
	return x + 4;
}

//----------------------------------------------------------------------------

void Problem1_2() // ���� ��� + ���� = ���� ��� ����ϱ�
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

void Problem1_3() // 1���� n������ �� ���ϱ�
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

void Problem1_4() // n������ �Ҽ� ���ϱ�
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

void Problem1_5() // n�� ���μ����� �� ���
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


// 13_2��

// ���� 1 : 10���� ���ҵ� �� �ִ밪 ���ϴ� �Լ��̿�, 10���� ���� �Է¹ް� ū ������ ����ϴ� �Լ� �����

void Problem2_1()
{
	int arr[10] = { 5,6,7,3,2,4,9,10,11,14 };

	//for (int i = 0; i < 10; i++)
	//{
	//	printf("arr[%d] : ", i);
	//	scanf("%d", &arr[i]);
	//}

	PrintMaxNums(arr, 10);
}

void PrintMaxNums(const int* arr, int n)
{
	int bigOrderArr[10] = {-1};

	ChangeBigOrderArr(arr, bigOrderArr, n);

	for (int i = 0; i < n; i++)
		printf("%d\n", bigOrderArr[i]);
}

void ChangeBigOrderArr(const int* originalArr, int* bigOrderArr, int n) // �迭, ũ��
{
	int tmpArr[10] = { -1 };
	for (int i = 0; i < n; i++)
	{
		for (int a = 0; a <= i; a++)
		{
			if (originalArr[i] > bigOrderArr[a])
			{
				SaveDesiredValue(bigOrderArr, 10, originalArr[i], a);
				break;
			}
		}
	}
}

void SaveDesiredValue(int* arr, int n, int desiredNum, int desiredIndex) // �迭, �迭 ũ��, ���ϴ� ��, ���ϴ� �ε��� ��ġ
{
	int tmp[10] = { 0 }; // �����Ҵ����� �迭�� ���� ���ϸ� ���� �� ����. 

	for (int i = 0; i< desiredIndex; i++)
	{
		tmp[i] = arr[i];
	}

	for (int i = desiredIndex+1; i < n; i++)
	{
		if (arr[i - 1] == 0) // 0�� ��� �ڿ� �迭�鵵 0�̹Ƿ� �ѱ� �ʿ䰡 �����Ƿ� ����
			break;
		tmp[i] = arr[i - 1];
	}

	tmp[desiredIndex] = desiredNum;

	for (int i = 0; i < 10; i++)
	{
		arr[i] = tmp[i];
	}
}

//----------------------------------------------------------------------------

// ���� 2 : 2���� �迭�� �� ���ҿ� 1�� ���ϴ� �Լ��� ���� �����?
// int AddArrPlusOne(int arr[][���]) or int (*arr)[���]



//----------------------------------------------------------------------------

// 13-2��
void Problem3_1() // �л� 5�� : 1����, ����, ���� -> ��� ������ ���� �� ��� / ��� �̻� = �հ� 
{
	int studentGrade[5][3] = { {0,0,0}, {1,2,3}, {1,1,1}, {3,4,5}, {0,0,1} };
	float studentAvg[5] = {0};

	//for (int row = 0; row < 5; row++)
	//{
	//	for (int col = 0; col < 3; col++)
	//	{
	//		switch (col)
	//		{
	//		case 0:
	//			printf("���� ���� �Է� : ");
	//			break;
	//		case 1:
	//			printf("���� ���� �Է� : ");
	//			break;
	//		case 2:
	//			printf("���� ���� �Է� : ");
	//			break;
	//		}
	//		scanf("%d", &studentGrade[row][col]);
	//	}
	//}

	CalculateAvg(studentGrade, 5, studentAvg);
	SetStudentGradeOrder(studentAvg, 5);

	for (int i = 0; i < 5; i++)
	{
		printf("%d��° �л��� ��� : %f\n", i, studentAvg[i]);
	}
}

void CalculateAvg(const int studentGrade[][3], int rowScale, float studentAvg[])
{
	for (int row = 0; row < rowScale; row++)
	{
		for (int col = 0; col < 3; col++)
		{
			studentAvg[row] += studentGrade[row][col];
		}
		studentAvg[row] /= 3.0f;
	}
}

void SetStudentGradeOrder(float studentAvg[], int studentAvgScale)
{
	int tmpArr[5] = { 0 };

	for (int i = 0; i < studentAvgScale; i++)
	{
		for (int a = 0; a <= i; a++)
		{
			if (studentAvg[i] > tmpArr[a])
			{
				PutDesiredPos(studentAvg, 5, a, studentAvg[i]);
				tmpArr[a] = studentAvg[i];
				break;
			}
		}
	}
}

void PutDesiredPos(int studentAvg[], int studentAvgScale, int desiredIndex, int desiredValue) // ���ϴ� �ڸ��� ���´�.
{
	int tmpArr[5] = { 0 };

	for (int i = desiredIndex+1; i < studentAvgScale; i++)
	{
		if (i == studentAvgScale)
			break;
		tmpArr[i] = studentAvg[i - 1];
	}

	for (int i = desiredIndex + 1; i < studentAvgScale; i++)
		studentAvg[i] = tmpArr[i];
}
