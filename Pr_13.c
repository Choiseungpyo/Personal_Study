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

// 13_1장

void Problem1_1() // f(x) = x+4
{
	printf("f(4) = %d", fx(4));
}

int fx(int x)
{
	return x + 4;
}

//----------------------------------------------------------------------------

void Problem1_2() // 기존 재산 + 수입 = 현재 재산 계산하기
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

void Problem1_3() // 1부터 n까지의 합 구하기
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

void Problem1_4() // n까지의 소수 구하기
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

void Problem1_5() // n의 소인수분해 값 출력
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


// 13_2장

// 문제 1 : 10개의 원소들 중 최대값 구하는 함수이용, 10개의 원소 입력받고 큰 순으로 출력하는 함수 만들기

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

void ChangeBigOrderArr(const int* originalArr, int* bigOrderArr, int n) // 배열, 크기
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

void SaveDesiredValue(int* arr, int n, int desiredNum, int desiredIndex) // 배열, 배열 크기, 원하는 값, 원하는 인덱스 위치
{
	int tmp[10] = { 0 }; // 동적할당으로 배열의 값을 정하면 좋을 것 같음. 

	for (int i = 0; i< desiredIndex; i++)
	{
		tmp[i] = arr[i];
	}

	for (int i = desiredIndex+1; i < n; i++)
	{
		if (arr[i - 1] == 0) // 0일 경우 뒤에 배열들도 0이므로 넘길 필요가 없으므로 종료
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

// 문제 2 : 2차원 배열의 각 원소에 1을 더하는 함수의 인자 모양은?
// int AddArrPlusOne(int arr[][상수]) or int (*arr)[상수]



//----------------------------------------------------------------------------

// 13-2장
void Problem3_1() // 학생 5명 : 1수학, 국어, 영어 -> 평균 순으로 정렬 후 출력 / 평균 이상 = 합격 
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
	//			printf("국어 점수 입력 : ");
	//			break;
	//		case 1:
	//			printf("수학 점수 입력 : ");
	//			break;
	//		case 2:
	//			printf("영어 점수 입력 : ");
	//			break;
	//		}
	//		scanf("%d", &studentGrade[row][col]);
	//	}
	//}

	CalculateAvg(studentGrade, 5, studentAvg);
	SetStudentGradeOrder(studentAvg, 5);

	for (int i = 0; i < 5; i++)
	{
		printf("%d번째 학생의 평균 : %f\n", i, studentAvg[i]);
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

void PutDesiredPos(int studentAvg[], int studentAvgScale, int desiredIndex, int desiredValue) // 원하는 자리에 놓는다.
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
