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

void Problem_1() // �Է¹޴� �л����� ������ ���� ������ ���
{ 
	int studentGrade[5] = { 1,3,2,4,5 };

	// ���� �Է¹ޱ�
	for (int i = 0; i < 5; i++)
	{
		printf("�л� %d ���� �Է� : ", i+1);
		scanf("%d", &studentGrade[i]);
	}

	SetToHighGradeOrder(studentGrade, 5);

	for (int i = 0; i < 5; i++)
	{
		printf("%d \n", studentGrade[i]);
	}

}

// 1. �ڱ⺸�� ū ���� ã�´�.
// 2. ã�Ҵٸ� �ش� �ε��� ���� �ڸ��� ���� �ִ´�.

// 1. �ڱ⺸�� ���� ���� ã�Ҵٸ� �ش� �ε��� ���� �ڸ���  ���� �ִ´�. 

// ���ϴ� �ε���, ���� �޾Ƽ� ���ϴ� �迭�� �ε��� ��ġ�� ���� �־��ش�.

void SetToHighGradeOrder(int grade[], int n)
{
	int studentHighGradeOrder[5] = { 0 }; // ũ�⸦ �����Ҵ��ϴ°� ����Ʈ �� �� ����.

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

// �Ű� ���� : ���ĵ� �л� ���� �迭, �л� ���� �迭 ũ�� , ���� �ٲٰ� ���� �ε���, �ٲٰ� ���� ��
void StoreDesiredValueInArray(int orderedGrade[], int n, int desiredIndexNum, int desiredValue)
{
	int tmpGrade[5] = {0};

	for (int i = 0; i < n; i++)  
	{
		tmpGrade[i] = orderedGrade[i]; // ���ĵ� ���������� �ӽ� �迭�� �����Ѵ�.
	}

	for (int i = desiredIndexNum; i < n; i++) 
	{
		if (i == n - 1) // ���� ������ index�� ���� ���� x
			break;
		
		tmpGrade[i + 1] = orderedGrade[i]; // ���ϴ� ��ġ ������ �迭�� ��ĭ�� �о �����Ѵ�
	}
	
	tmpGrade[desiredIndexNum] = desiredValue;

	for (int i = 0; i < n; i++)
	{
		printf("%d ", tmpGrade[i]);
		orderedGrade[i] = tmpGrade[i]; // ��ĭ�� �̷� �迭���� ���� �迭�� �ٽ� �־��ֱ�
	}
		

	printf("\n");
}

void Problem_2()
{
	int studentGrade[5] = { 0 };

	for (int i = 0; i < 5; i ++ )
	{
		printf("�л� %d ���� �Է� : ", i+1);
		scanf("%d", &studentGrade[i]);
	}

	for (int i = 0; i < 5; i++)
	{
		printf("�л� %d : ", i+1);
		for (int a = 0; a < studentGrade[i]; a++)
		{
			printf("*");
		}
		printf("\n");
	}
}

// 11_2��

// ���� 1 : C����� ����Ʈ��� �� ��������
// �� : �� - ��		�� - ��		ȣ - �� 

