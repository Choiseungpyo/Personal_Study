#include <stdio.h>
#include <math.h>

void Problem_1();
void SetToHighGradeOrder(int grade[], int n);
void StoreDesiredValueInArray(int grade[], int n, int desiredIndexNum, int desiredValue);

void Problem_2();

int main()
{
	Problem_2();
}

void Problem_1() // 입력받는 학생들의 성적을 높은 순으로 출력
{ 
	int studentGrade[5] = { 1,3,2,4,5 };

	// 성적 입력받기
	for (int i = 0; i < 5; i++)
	{
		printf("학생 %d 성적 입력 : ", i+1);
		scanf("%d", &studentGrade[i]);
	}

	SetToHighGradeOrder(studentGrade, 5);

	for (int i = 0; i < 5; i++)
	{
		printf("%d \n", studentGrade[i]);
	}

}

// 1. 자기보다 큰 수를 찾는다.
// 2. 찾았다면 해당 인덱스 앞의 자리에 값을 넣는다.

// 1. 자기보다 작은 값을 찾았다면 해당 인덱스 앞의 자리에  값을 넣는다. 

// 원하는 인덱스, 값을 받아서 원하는 배열의 인덱스 위치에 값을 넣어준다.

void SetToHighGradeOrder(int grade[], int n)
{
	int studentHighGradeOrder[5] = { 0 }; // 크기를 동적할당하는게 베스트 일 것 같음.

	for (int i = 0; i < n; i++)
	{
		for (int a = 0; a < n; a++)
		{
			if (grade[i] > studentHighGradeOrder[a])
			{
				StoreDesiredValueInArray(studentHighGradeOrder, n, a, grade[i]);
				break;
			}
		}
	}

	for (int i = 0; i < n; i++)
	{
		grade[i] = studentHighGradeOrder[i];
	}
}

// 매개 변수 : 정렬된 학생 성적 배열, 학생 성적 배열 크기 , 값을 바꾸고 싶은 인덱스, 바꾸고 싶은 값
void StoreDesiredValueInArray(int orderedGrade[], int n, int desiredIndexNum, int desiredValue)
{
	int tmpGrade[5] = {0};

	for (int i = 0; i < n; i++)  
	{
		tmpGrade[i] = orderedGrade[i]; // 정렬된 성적값들을 임시 배열에 저장한다.
	}

	for (int i = desiredIndexNum; i < n; i++) 
	{
		if (i == n - 1) // 제일 마지막 index의 값은 설정 x
			break;
		
		tmpGrade[i + 1] = orderedGrade[i]; // 원하는 위치 이후의 배열을 한칸씩 밀어서 저장한다
	}
	
	tmpGrade[desiredIndexNum] = desiredValue;

	for (int i = 0; i < n; i++)
	{
		printf("%d ", tmpGrade[i]);
		orderedGrade[i] = tmpGrade[i]; // 한칸씩 미룬 배열값을 원래 배열에 다시 넣어주기
	}
		

	printf("\n");
}

void Problem_2()
{
	int studentGrade[5] = { 0 };

	for (int i = 0; i < 5; i ++ )
	{
		printf("학생 %d 성적 입력 : ", i+1);
		scanf("%d", &studentGrade[i]);
	}

	for (int i = 0; i < 5; i++)
	{
		printf("학생 %d : ", i+1);
		for (int a = 0; a < studentGrade[i]; a++)
		{
			printf("*");
		}
		printf("\n");
	}
}

// 11_2장

// 문제 1 : C언어의 아파트라고 왜 지었는지
// 답 : 동 - 층		층 - 행		호 - 열 

