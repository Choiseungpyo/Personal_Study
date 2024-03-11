#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>

int main()
{

}

void Problem_1()
{
	// 왜 switch 문의 '값' 부분에 정수를 써야할까?
	// 답 : if(값==n)처럼 관계연산자로 계산하기 때문에 실수형일 경우 정확하지 않게 측정된다.
	//		실수에서 크기 비교를 할때 ==을 쓰는 것보다 부등호(>=)를 쓰는 이유와 같다고 본다. 
}

void Problem_2() // 잘 모르겠음.
{
	/*case 1 ~ case 10일 경우 : 10과 비교하여 10보다 작으면 계속 찾고, 10보다 크면 defulat로 이동
	case 1 case 3 case 4 case10일 경우 :  case10과 비교하여 10보다 작으면 계속 찾고, 10보다 크면 default로 이동 */
}