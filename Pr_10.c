#include <stdio.h>
#include <math.h>

void Problem_1();

int main()
{
	Problem_1();
}

void Problem_1() // �Ҽ��� ���� ���ڸ����� �����Ͽ� ������ ������ ����
{
	float f;
	int i;

	printf("�Ǽ��� �Է��Ͻÿ� : ");
	scanf("%f", &f);
	i = abs(((f - (int)f) * 100));
	printf("i : %d", i);
}